using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OutOfOffice.Models.ViewModels
{
    public class ProjectVM
    {
        // Creating dummy lists to populate fields in db
        public ProjectVM()
        {
            TypeList = new[]
            {
                new SelectListItem
                {
                    Text = "IT and Software Development",
                    Value = "IT and Software Development"
                },
                new SelectListItem
                {
                    Text = "Healthcare",
                    Value = "Healthcare"
                },
                new SelectListItem
                {
                    Text = "Marketing and Advertising",
                    Value = "Marketing and Advertising"
                },
                new SelectListItem
                {
                    Text = "Research and Development",
                    Value = "Research and Development"
                },
                new SelectListItem
                {
                    Text = "Maintenance and Support",
                    Value = "Maintenance and Support"
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

            SelectedEmployees = new();
        }

        public Project Project { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TypeList { get; set; }
        
        [ValidateNever]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        
        [ValidateNever]
        public IEnumerable<SelectListItem> ProjectManagerList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        [ValidateNever]
        public List<string> SelectedEmployees { get; set; }
    }
}
