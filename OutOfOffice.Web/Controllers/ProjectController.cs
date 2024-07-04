using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using OutOfOffice.DataAccess.Data;
using OutOfOffice.Models;
using OutOfOffice.Models.ViewModels;

namespace OutOfOffice.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Project> projects = _context.Project.Include("Manager").ToList(); 
            return View(projects);
        }

        public IActionResult Upsert(int? id) 
        {
            ProjectVM projectVM = new();

            // getting the list of project managers out of db
            string roleName = "Project manager";

            var roleId = _context.Roles.FirstOrDefault(r => r.Name == roleName).Id;

            var managerIds = _context.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToList();

            projectVM.ProjectManagerList = _context.Users
                .Where(u => managerIds.Contains(u.Id))
                .Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                })
                .ToList();

            // getting the list of employees out of db
            roleName = "Employee";

            roleId = _context.Roles.FirstOrDefault(r => r.Name == roleName).Id;

            var employeeIds = _context.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToList();

            projectVM.EmployeeList = _context.Users
                .Where(u => employeeIds.Contains(u.Id))
                .Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                })
                .ToList();

            // create new entry
            if (id == null || id == 0)
            {
                projectVM.Project = new();
                return View(projectVM);
            }
            // update existing entry
            else
            {
                projectVM.Project = _context.Project.Include("Members").FirstOrDefault(p => p.Id == id);
                if (projectVM.Project == null)
                {
                    return NotFound();
                }
                projectVM.Project.Members.ForEach(x => projectVM.SelectedEmployees.Add(x.Id.ToString()));
                return View(projectVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProjectVM projectVM)
        {
            // updating existing entry
            var id = projectVM.Project.Id;
            if (id != null && id != 0) 
            {
                var project = _context.Project.Include("Members").FirstOrDefault(p => p.Id == id);
                project.Type = projectVM.Project.Type;
                project.StartDate = projectVM.Project.StartDate;
                project.EndDate = projectVM.Project.EndDate;
                project.ManagerId = projectVM.Project.ManagerId;
                project.Comment = projectVM.Project.Comment;
                project.Status = projectVM.Project.Status;

                // removing existing connections from join table
                for (int i = project.Members.Count - 1; i >= 0; i--)
                {
                    project.Members.Remove(project.Members[i]);
                }

                // adding newly selected connections to join table
                foreach (string s in projectVM.SelectedEmployees)
                {
                    project.Members.Add(_context.Employee.FirstOrDefault(e => e.Id == s));
                }

                _context.Project.Update(project);
            }
            // adding new entry
            else
            {
                projectVM.Project.Members = new();

                // adding selected connetions to join table
                foreach (string s in projectVM.SelectedEmployees)
                {
                    projectVM.Project.Members.Add(_context.Employee.FirstOrDefault(e => e.Id == s));
                }

                _context.Project.Add(projectVM.Project);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
