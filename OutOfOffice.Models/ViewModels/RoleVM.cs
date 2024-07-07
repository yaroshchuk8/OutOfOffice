using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OutOfOffice.Models.ViewModels
{
    public class RoleVM
    {
        public Employee Employee { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public string SelectedRole { get; set; }
    }
}
