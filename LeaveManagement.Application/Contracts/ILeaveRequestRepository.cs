using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Application.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model);
        Task CancelLeaveRequest(int leaveRequestId);
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);
        Task<List<LeaveRequestVM>> GetPendingAsync(string employeeId);
        Task<List<LeaveRequestVM>> GetArchivalAsync(string employeeId);
        Task<AdminLeaveRequestVM> GetAdminLeaveRequestList();
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
    }
}