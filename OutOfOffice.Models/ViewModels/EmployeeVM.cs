using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOffice.Models.ViewModels
{
    // Creating dummy lists to populate fields in db
    public class EmployeeVM
    {
        public EmployeeVM() 
        {
            SubdivisionList = new[] 
            {
                new SelectListItem
                {
                    Text = "Human Resources",
                    Value = "Human Resources"
                },
                new SelectListItem
                {
                    Text = "IT",
                    Value = "IT"
                },
                new SelectListItem
                {
                    Text = "Marketing",
                    Value = "Marketing"
                },
                new SelectListItem
                {
                    Text = "Sales",
                    Value = "Sales"
                },
                new SelectListItem
                {
                    Text = "Finance",
                    Value = "Finance"
                },
                new SelectListItem
                {
                    Text = "Sales",
                    Value = "Sales"
                }
            };

            StatusList = new[]
            {
                new SelectListItem
                {
                    Text = "Active",
                    Value = "Active"
                },
                new SelectListItem
                {
                    Text = "Inactive",
                    Value = "Inactive"
                }
            };

            PositionList = new[]
            {
                new SelectListItem
                {
                    Text = "Front-end developer",
                    Value = "Front-end developer"
                },
                new SelectListItem
                {
                    Text = "Back-end developer",
                    Value = "Back-end developer"
                },
                new SelectListItem
                {
                    Text = "Accountant",
                    Value = "Accountant"
                },
                new SelectListItem
                {
                    Text = "Sales manager",
                    Value = "Sales manager"
                },
                new SelectListItem
                {
                    Text = "Receptionist",
                    Value = "Receptionist"
                },
                new SelectListItem
                {
                    Text = "Designer",
                    Value = "Designer"
                },
                new SelectListItem
                {
                    Text = "Data analyst",
                    Value = "Data analyst"
                }
            };
        }

        public Employee Employee { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> SubdivisionList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> StatusList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> PositionList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> HrManagerList { get; set; }
    }
}
