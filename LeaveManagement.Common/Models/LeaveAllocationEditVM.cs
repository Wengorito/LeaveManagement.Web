namespace LeaveManagement.Common.Models
{
    public class LeaveAllocationEditVM : LeaveAllocationVM
    {
        public string EmployeeId { get; set; }
        public EmployeeVM? Employee { get; set; }
    }
}
