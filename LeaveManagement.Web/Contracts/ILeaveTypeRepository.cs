using LeaveManagement.Web.Data;
using System.Collections;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<IEnumerable<LeaveType>> GetEmployeeLeaveTypes(string employeeId);
    }
}
