using LeaveManagement.Data;
using System.Collections;

namespace LeaveManagement.Application.Contracts
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<IEnumerable<LeaveType>> GetEmployeeLeaveTypes(string employeeId);
    }
}
