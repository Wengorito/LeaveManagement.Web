using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task AllocateLeave(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
    }
}
