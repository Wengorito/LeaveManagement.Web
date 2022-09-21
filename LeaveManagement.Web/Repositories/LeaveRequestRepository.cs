﻿using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public LeaveRequestRepository(
            ApplicationDbContext context,
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper,
            UserManager<Employee> userManager) : base(context)
        {
            _context = context;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _userManager = userManager;
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
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(model.RequestingEmployeeId!, model.LeaveTypeId);

            if (allocation == null)
                return;

            if (allocation.NumberOfDays < (int)(model.EndDate.Value - model.StartDate.Value)!.TotalDays)
                throw new ArgumentOutOfRangeException(null, "Requested number of days exceeds remaining allocation.");

            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;

            await AddAscync(leaveRequest);
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
                .ToListAsync();

            var model = _mapper.Map<List<LeaveRequestVM>>(requests);

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetPendingAsync(string employeeId)
        {
            var requests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .Where(q => q.RequestingEmployeeId == employeeId)
                .Where(q => q.Approved == null)
                .Where(q => q.Cancelled != true)
                .ToListAsync();

            var model = _mapper.Map<List<LeaveRequestVM>>(requests);

            return model;
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await _context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);

            if (leaveRequest == null)
                return null;

            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
            return model;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            if (leaveRequest != null)
            {
                leaveRequest.Cancelled = true;
                await UpdateAsync(leaveRequest);
            }
        }
    }
}
