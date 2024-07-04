using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.DataAccess.Data;
using OutOfOffice.Models;
using OutOfOffice.Models.ViewModels;

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

        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _context.Employee.ToList();
            
            return View(employees);
        }

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
