using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.DataAccess.Data;
using OutOfOffice.Models;
using OutOfOffice.Models.ViewModels;
using System.Security.Claims;

namespace OutOfOffice.Web.Controllers
{
    public class LeaveRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,HR manager,Project manager,Employee")]
        public IActionResult Index()
        {
            List<LeaveRequest> leaveRequests;
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {
                leaveRequests = _context.LeaveRequest.Include("Employee").ToList();
            }
            else if (User.IsInRole("HR manager"))
            {
                leaveRequests = new();
                IEnumerable<Employee> subordinates = _context.Employee
                    .Include("LeaveRequests")
                    .Where(s => s.PeoplePartnerId == userId);
                foreach (var s in subordinates)
                    s.LeaveRequests.ForEach(lr => leaveRequests.Add(lr));
            }   
            else if (User.IsInRole("Project manager"))
            {
                IEnumerable<Project> projects = 
                    _context.Project
                        .Include("Manager")
                        .Include("Members.LeaveRequests")
                        .Where(p => p.ManagerId == userId)
                        .ToList();
                List<Employee> subordinates = new();
                foreach (var p in projects)
                    p.Members.ForEach(m => { if (!subordinates.Contains(m)) subordinates.Add(m); });
                leaveRequests = new();
                foreach (var s in subordinates)
                    s.LeaveRequests.ForEach(lr => leaveRequests.Add(lr));
            }
            else
            {
                leaveRequests = _context.Employee
                    .Include("LeaveRequests")
                    .FirstOrDefault(e => e.Id == userId)
                    .LeaveRequests
                    .ToList();
            }
            
            return View(leaveRequests);
        }

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Upsert(int? id)
        {
            LeaveRequestVM leaveRequestVM = new();

            // create new entry
            if (id == null || id == 0)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                leaveRequestVM.LeaveRequest = new()
                {
                    EmployeeId = userId,
                    Employee = _context.Employee.Find(userId),
                    Status = "New"
                };
                
                return View(leaveRequestVM);
            }
            // update existing entry
            else
            {
                leaveRequestVM.LeaveRequest = _context.LeaveRequest.Include("Employee").FirstOrDefault(lr => lr.Id == id);
                if (leaveRequestVM.LeaveRequest == null)
                {
                    return NotFound();
                }
                return View(leaveRequestVM);
            }
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpPost]
        public IActionResult Upsert(LeaveRequestVM leaveRequestVM)
        {
            if (ModelState.IsValid)
            {
                leaveRequestVM.LeaveRequest.Employee = null;
                // updating existing entry
                var id = leaveRequestVM.LeaveRequest.Id;
                if (id != 0)
                {
                    _context.LeaveRequest.Update(leaveRequestVM.LeaveRequest);
                }
                // adding new entry
                else
                {
                    _context.LeaveRequest.Add(leaveRequestVM.LeaveRequest);
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(leaveRequestVM);
            }
        }

        [Authorize(Roles = "Admin,HR manager,Project manager,Employee")]
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            LeaveRequest leaveRequest = _context.LeaveRequest.Include("Employee").FirstOrDefault(lr => lr.Id == id);

            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Submit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            LeaveRequest leaveRequest = _context.LeaveRequest.Include("Employee").FirstOrDefault(lr => lr.Id == id);
            leaveRequest.Status = "Submitted";

            LeaveRequestApproval leaveRequestApproval = new()
            {
                ApproverId = leaveRequest.Employee.PeoplePartnerId,
                LeaveRequestId = leaveRequest.Id,
                Status = "New"
            };

            _context.LeaveRequest.Update(leaveRequest);
            _context.LeaveRequestApproval.Add(leaveRequestApproval);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Cancel(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            LeaveRequest leaveRequest = _context.LeaveRequest.Include("Employee").FirstOrDefault(lr => lr.Id == id);
            leaveRequest.Status = "Canceled";

            LeaveRequestApproval leaveRequestApproval = _context.LeaveRequestApproval.FirstOrDefault(lra => lra.LeaveRequestId == leaveRequest.Id);
            if (leaveRequestApproval != null) 
            {
                leaveRequestApproval.Status = "Canceled";
                _context.LeaveRequestApproval.Update(leaveRequestApproval);
            }

            _context.LeaveRequest.Update(leaveRequest);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
