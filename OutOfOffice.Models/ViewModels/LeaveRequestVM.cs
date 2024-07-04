using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OutOfOffice.Models.ViewModels
{
    public class LeaveRequestVM
    {
        public LeaveRequestVM() 
        {
            AbsenceReasonList = new[]
            {
                new SelectListItem
                {
                    Text = "Health problem",
                    Value = "Health problem"
                },
                new SelectListItem
                {
                    Text = "Home emergency",
                    Value = "Home emergency"
                },
                new SelectListItem
                {
                    Text = "Child care",
                    Value = "Child care"
                },
                new SelectListItem
                {
                    Text = "Holiday",
                    Value = "Holiday"
                },
                new SelectListItem
                {
                    Text = "Other reason",
                    Value = "Other reason"
                }
            };
        }

        public LeaveRequest LeaveRequest { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> AbsenceReasonList { get; set; }
    }
}
