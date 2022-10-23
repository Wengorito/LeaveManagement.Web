using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
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