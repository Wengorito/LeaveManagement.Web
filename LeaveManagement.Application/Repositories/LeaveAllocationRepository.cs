using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Constants;
using LeaveManagement.Common.Models;
using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveAllocationRepository(
            ApplicationDbContext context,
            UserManager<Employee> userManager,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q =>
                                                            q.EmployeeId == employeeId &&
                                                            q.LeaveTypeId == leaveTypeId &&
                                                            q.Period == period);
        }

        public async Task AllocateLeave(int leaveTypeId)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(leaveTypeId);

            if (leaveType == null)
                return;

            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var allocations = new List<LeaveAllocation>();
            var employeesToNotify = new List<Employee>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });

                employeesToNotify.Add(employee);
            }

            await AddRangeAscync(allocations);

            leaveType.Allocated = true;
            await _leaveTypeRepository.UpdateAsync(leaveType);

            foreach (var employee in employeesToNotify)
            {
                await _emailSender.SendEmailAsync(employee.Email, $"Leave allocation for {period}",
                    $"Your {leaveType.Name} has been posted for the period of {period}. You have been give {leaveType.DefaultDays}.");
            }
        }

        public async Task<List<LeaveAllocationVM>> GetAllVMAsync(string employeeId)
        {
            return await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId)
                .ProjectTo<LeaveAllocationVM>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<EmployeeAllocationsVM> GetEmployeeAllocations(string employeeId)
        {
            var model = _mapper.Map<EmployeeAllocationsVM>(await _userManager.FindByIdAsync(employeeId));
            model.LeaveAllocations = GetAllVMAsync(employeeId).Result;

            return model;
        }

        public async Task<LeaveAllocationEditVM?> GetEmployeeAllocation(int allocationId)
        {
            var allocationModel = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .ProjectTo<LeaveAllocationEditVM>(_configurationProvider)
                .SingleOrDefaultAsync(q => q.Id == allocationId);

            if (allocationModel == null)
                return null;

            allocationModel.Employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(allocationModel.EmployeeId));

            return allocationModel;
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);

            if (leaveAllocation == null)
                return false;

            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;

            await UpdateAsync(leaveAllocation);

            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }
    }
}
