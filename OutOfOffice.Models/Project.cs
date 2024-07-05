using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Manager")]
        public string ManagerId { get; set; }

        public string? Comment { get; set; }

        [Required]
        public string Status { get; set; }

        // Navigation property
        [ValidateNever]
        public Employee Manager { get; set; }

        // Navigation Collection
        [ValidateNever]
        public List<Employee> Members { get; set; }
    }
}
