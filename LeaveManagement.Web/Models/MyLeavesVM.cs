namespace LeaveManagement.Web.Models
{
    public class MyLeavesVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }

        public MyLeavesVM(List<LeaveAllocationVM> allocations, List<LeaveRequestVM> requests)
        {
            LeaveAllocations = allocations;
            LeaveRequests = requests;
        }
    }
}