
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Number of days")]
        [Required]
        [Range(1, 50, ErrorMessage = "Enter a number in range from 1 to 50")]
        public int NumberOfDays { get; set; }

        
        [Display(Name = "Allocation period")]
        [Required]
        public int Period { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }
    }
}