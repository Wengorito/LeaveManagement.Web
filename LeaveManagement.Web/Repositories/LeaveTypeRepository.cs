using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveType>> GetEmployeeLeaveTypes(string employeeId)
        {
            var leaveTypeIds = _context.LeaveAllocations.Where(q => q.EmployeeId == employeeId).Select(q => q.LeaveTypeId);

            return await _context.LeaveTypes.Where(q => leaveTypeIds.Contains(q.Id)).ToListAsync();
        }
    }
}
