using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestVM // Better create one parent viewmodel and inherit it by subsequents
    {
        public int Id { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }


        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Leave type")]
        public LeaveTypeVM LeaveType { get; set; }

        [Display(Name = "Date requested")]
        public DateTime DateRequested { get; set; }

        [Display(Name = "Request comment")]
        public string? RequestComments { get; set; }

        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }

        public EmployeeVM Employee { get; set; }
        public string? RequestingEmployeeId { get; set; }
    }
}