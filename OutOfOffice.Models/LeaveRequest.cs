using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OutOfOffice.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    [DateRangeValidation]
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }

        [Required]
        public string AbsenceReason { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string? Comment { get; set; }

        [Required]
        public string Status { get; set; }

        // Navigation property
        [ValidateNever]
        public Employee Employee { get; set; }
    }
}
