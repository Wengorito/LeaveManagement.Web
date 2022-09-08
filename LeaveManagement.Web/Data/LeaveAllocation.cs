namespace LeaveManagement.Web.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public string NumberOfDays { get; set; }

        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public string EmployeeId { get; set; }
    }
}
