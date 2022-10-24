using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task AllocateLeave(int leaveTypeId);
        Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
        Task<List<LeaveAllocationVM>> GetAllVMAsync(string employeeId); // This and below 2 methods are doing basically the same lol
        Task<EmployeeAllocationsVM> GetEmployeeAllocations(string employeeId); // What a clutter.
        Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId); // Append Get VM methods with suffixes to differntiate
        Task<LeaveAllocationEditVM?> GetEmployeeAllocation(int allocationId);
        Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model);
    }
}
