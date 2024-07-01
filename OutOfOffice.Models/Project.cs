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
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public int ManagerId { get; set; }

        public string Comment { get; set; }

        [Required]
        public string Status { get; set; }

        // Navigation property
        [ValidateNever]
        public Employee Manager { get; set; }

        // Navigation Collection
        [ValidateNever]
        public ICollection<Employee> Members { get; set; }
    }
}
