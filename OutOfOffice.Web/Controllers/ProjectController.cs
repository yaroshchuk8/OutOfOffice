﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Graph;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using OutOfOffice.DataAccess.Data;
using OutOfOffice.Models;
using OutOfOffice.Models.ViewModels;
using System.Security.Claims;

namespace OutOfOffice.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,HR manager,Project manager,Employee")]
        public IActionResult Index()
        {
            List<Project> projects;
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {
                projects = _context.Project.Include("Manager").Include("Members").ToList();
            }
            else if (User.IsInRole("Project manager"))
            {
                projects = _context.Project
                    .Include("Manager")
                    .Include("Members")
                    .Where(p => p.ManagerId == userId)
                    .ToList();
            }
            else if (User.IsInRole("HR manager"))
            {
                projects = new List<Project>();
                IEnumerable<Employee> subordinates = _context.Employee
                    .Include("Projects.Manager")
                    .Where(e => e.PeoplePartnerId == userId)
                    .ToList();
                foreach (var s in subordinates)
                    s.Projects.ForEach(p => { if (!projects.Contains(p)) projects.Add(p); });
            }
            else
            {
                projects = _context.Employee
                    .Include("Projects.Manager")
                    .FirstOrDefault(e => e.Id == userId)
                    .Projects
                    .ToList();
            }
                        
            return View(projects);
        }

        [Authorize(Roles = "Admin,Project manager")]
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

        [Authorize(Roles = "Admin,Project manager")]
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
