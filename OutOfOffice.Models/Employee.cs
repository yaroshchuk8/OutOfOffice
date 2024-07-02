using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Subdivision { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Status { get; set; }        

        public int? PeoplePartnerId { get; set; }

        [Required]
        [Range(0, 30)]
        public int OutOfOfficeBalance { get; set; }

        [ValidateNever]
        [Display(Name = "Photo")]
        public string? PhotoUrl { get; set; }

        // Navigation properties
        [ValidateNever]
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }

        [ValidateNever]
        public Employee PeoplePartner { get; set; }

        // Navigation collections
        [ValidateNever]
        public ICollection<Project> Projects { get; set; }

        [ValidateNever]
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
