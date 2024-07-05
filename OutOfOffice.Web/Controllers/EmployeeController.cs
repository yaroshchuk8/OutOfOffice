using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OutOfOffice.DataAccess.Data;
using OutOfOffice.Models;
using OutOfOffice.Models.ViewModels;
using System.Security.Claims;

namespace OutOfOffice.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Admin,HR manager,Project manager")]
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Employee> employees;
            // admin can access everybody
            if (User.IsInRole("Admin"))
            {
                employees = _context.Employee.ToList();
            }
            // hr can access their subordinates
            else if (User.IsInRole("HR manager"))
            {
                employees = _context.Employee.Include("PeoplePartner").Where(e => e.PeoplePartnerId == userId).ToList();                
            }
            // project manager can access their project(s) members
            else
            {
                IEnumerable<Project> projects = _context.Project.Include("Members.PeoplePartner").Where(p => p.ManagerId == userId).ToList();
                employees = new();
                foreach (var p in projects)
                    p.Members.ForEach(m => { if (!employees.Contains(m)) employees.Add(m); } );               
            }
            return View(employees);
        }
        
        // only admin and hr are allowed to modify user information
        [Authorize(Roles = "Admin,HR manager")]
        public IActionResult Update(string? id) 
        {
            Employee employee = _context.Employee.Find(id);

            if (employee == null) 
            {
                return NotFound();
            }

            EmployeeVM employeeVM = new();
            employeeVM.Employee = employee;

            // getting the list of hr managers out of db
            string roleName = "HR manager";

            var roleId = _context.Roles.FirstOrDefault(r => r.Name == roleName).Id;

            var managerIds = _context.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToList();

            employeeVM.HrManagerList = _context.Users
                .Where(u => managerIds.Contains(u.Id))
                .Select(u => new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                })
                .ToList();

            return View(employeeVM);
        }

        // only admin and hr are allowed to modify user information
        [Authorize(Roles = "Admin,HR manager")]
        [HttpPost]
        public IActionResult Update(EmployeeVM employeeVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string photoPath = Path.Combine(wwwRootPath, @"photos");

                    if (!string.IsNullOrEmpty(employeeVM.Employee.PhotoUrl))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, employeeVM.Employee.PhotoUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(photoPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    employeeVM.Employee.PhotoUrl = @"\photos\" + fileName;
                }

                _context.Employee.Update(employeeVM.Employee);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }
    }
}
