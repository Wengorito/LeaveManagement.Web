namespace LeaveManagement.Common.Models
{
    public class MyLeavesVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> ArchivalRequests { get; set; }
        public List<LeaveRequestVM> PendingRequests { get; set; }

        public MyLeavesVM(List<LeaveAllocationVM> allocations, List<LeaveRequestVM> archivalRequests, List<LeaveRequestVM> pendingRequests)
        {
            LeaveAllocations = allocations;
            ArchivalRequests = archivalRequests;
            PendingRequests = pendingRequests;
        }
    }
}