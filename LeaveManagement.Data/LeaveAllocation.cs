namespace LeaveManagement.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }

        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        public string EmployeeId { get; set; }

        public int Period { get; set; }
    }
}
