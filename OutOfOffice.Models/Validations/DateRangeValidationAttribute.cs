using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models.Validations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class DateRangeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var leaveRequest = value as LeaveRequest;

            // Check if StartDate is not earlier than today
            if (leaveRequest.StartDate < DateTime.Today)
            {
                return new ValidationResult("Start date cannot be earlier than today.");
            }

            // Check if StartDate is not later than EndDate
            if (leaveRequest.StartDate > leaveRequest.EndDate)
            {
                return new ValidationResult("Start date cannot be later than end date.");
            }

            // Check if the period between StartDate and EndDate is not over Employee's balance
            if ((leaveRequest.EndDate - leaveRequest.StartDate).TotalDays > leaveRequest.Employee.OutOfOfficeBalance)
            {
                return new ValidationResult($"The leave period cannot exceed your out-of-office balance ({leaveRequest.Employee.OutOfOfficeBalance} days).");
            }

            return ValidationResult.Success;
        }
    }
}
