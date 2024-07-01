﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Models
{
    public class LeaveRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string AbsenceReason { get; set; }

        [Required]
        public DateTime StartDate{ get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Comment { get; set; }

        [Required]
        public string Status { get; set; }

        // Navigation property
        [ValidateNever]
        public Employee Employee { get; set; }
    }
}
