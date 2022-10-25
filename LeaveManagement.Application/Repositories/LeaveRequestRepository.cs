using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Employee> _userManager;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveRequestRepository(
            ApplicationDbContext context,
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Employee> userManager,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender) : base(context)
        {
            _context = context;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);

            if (leaveRequest == null)
                return;

            leaveRequest.Approved = approved;

            if (approved)
            {
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);

                if (allocation == null)
                    return;

                allocation.NumberOfDays -= (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

                await _leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);

            var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

            var approvalStatus = approved ? "approved" : "declined";

            await _emailSender.SendEmailAsync(user.Email, $"Leave request {approvalStatus}", $"Your leave request from " +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been {approvalStatus}.");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);

            if (allocation == null || allocation.NumberOfDays < model.EndDate!.Value.Subtract(model.StartDate!.Value).Days)
                return false;

            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;

            await AddAscync(leaveRequest);

            await _emailSender.SendEmailAsync(user.Email, "Leave request created", $"Your leave request from " +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for approval.");

            return true;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);

            if (leaveRequest != null)
            {
                leaveRequest.Cancelled = true;
                await UpdateAsync(leaveRequest);

                var user = await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);

                await _emailSender.SendEmailAsync(user.Email, $"Leave request cancelled", $"Your leave request from " +
                    $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been cancelled successfully.");
            }
        }

        public async Task<AdminLeaveRequestVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await _context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();

            var model = new AdminLeaveRequestVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                RejecetedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetArchivalAsync(string employeeId)
        {
            var requests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .Where(q => q.RequestingEmployeeId == employeeId)
                .Where(q => q.Approved != null || q.Cancelled == true)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();

            foreach (var request in requests)
            {
                request.DaysRequested = request.EndDate.Subtract(request.StartDate).Days;
            }

            return requests;
        }

        public async Task<List<LeaveRequestVM>> GetPendingAsync(string employeeId)
        {
            var requests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .Where(q => q.RequestingEmployeeId == employeeId)
                .Where(q => q.Approved == null)
                .Where(q => q.Cancelled != true)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();

            foreach (var request in requests)
            {
                request.DaysRequested = request.EndDate.Subtract(request.StartDate).Days;
            }

            return requests;
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);

            if (leaveRequest == null)
                return null;

            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            return model;
        }
    }
}