﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public class ApprovalRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ApproverId { get; set; }

        [Required]
        public int LeaveRequestId { get; set; }

        [Required]
        public string Status { get; set; }

        public string Comment { get; set; }

        // Navigation properties
        [ForeignKey("ApproverId")]
        [ValidateNever]
        public Employee Approver { get; set; }

        [ForeignKey("LeaveRequestId")]
        [ValidateNever]
        public LeaveRequest LeaveRequest { get; set; }
    }
}
