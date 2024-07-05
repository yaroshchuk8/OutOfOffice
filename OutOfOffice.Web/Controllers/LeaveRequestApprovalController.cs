using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.DataAccess.Data;
using OutOfOffice.Models;
using OutOfOffice.Models.ViewModels;
using System.Security.Claims;

namespace OutOfOffice.Web.Controllers
{
    public class LeaveRequestApprovalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestApprovalController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin,HR manager,Project manager")]
        public IActionResult Index()
        {
            //List<LeaveRequest> leaveRequests;
            IEnumerable<LeaveRequestApproval> leaveRequestApprovals;
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Admin"))
            {
                leaveRequestApprovals = _context.LeaveRequestApproval.Include("Approver").ToList();
            }
            else if (User.IsInRole("HR manager"))
            {
                List<int> lrIds = new();
                IEnumerable<Employee> subordinates = _context.Employee
                    .Include("LeaveRequests")
                    .Where(s => s.PeoplePartnerId == userId);
                foreach (var s in subordinates)
                    s.LeaveRequests.ForEach(lr => lrIds.Add(lr.Id));
                leaveRequestApprovals = _context.LeaveRequestApproval
                                            .Include("Approver")
                                            .Where(lra => lrIds.Contains(lra.LeaveRequestId))
                                            .ToList();
            }
            // project manager
            else 
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
                List<int> lrIds = new();
                foreach (var s in subordinates)
                    s.LeaveRequests.ForEach(lr => lrIds.Add(lr.Id));
                leaveRequestApprovals = _context.LeaveRequestApproval
                                            .Include("Approver")
                                            .Where(lra => lrIds.Contains(lra.LeaveRequestId))
                                            .ToList();
            }

            return View(leaveRequestApprovals);
        }

        [Authorize(Roles = "Admin,HR manager,Project manager")]
        public IActionResult Update(int? id) 
        {
            LeaveRequestApproval leaveRequestApproval = 
                _context.LeaveRequestApproval
                    .Include("LeaveRequest.Employee")
                    .FirstOrDefault(lra => lra.Id == id);
            leaveRequestApproval.ApproverId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (leaveRequestApproval == null)
            {
                return NotFound();
            }

            return View(leaveRequestApproval);
        }

        [Authorize(Roles = "Admin,HR manager,Project manager,Employee")]
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            LeaveRequestApproval lra = 
                _context.LeaveRequestApproval
                    .Include("Approver")
                    .FirstOrDefault(lra => lra.LeaveRequestId == id);

            if (lra == null)
            {
                return NotFound();
            }

            return View(lra);
        }

        [Authorize(Roles = "Admin,HR manager,Project manager")]
        [HttpPost]
        public IActionResult Approve(LeaveRequestApproval lra)
        {
            lra.Status = "Approved";
            
            LeaveRequest lr = _context.LeaveRequest.Include("Employee").FirstOrDefault(lr => lr.Id == lra.LeaveRequestId);
            lr.Status = "Approved";

            var totalDaysAbsence = lr.EndDate.Subtract(lr.StartDate).TotalDays;
            lr.Employee.OutOfOfficeBalance -= (int)totalDaysAbsence;
            if (lr.Employee.OutOfOfficeBalance < 0)
            {
                return NotFound();
            }

            _context.Employee.Update(lr.Employee);
            _context.LeaveRequest.Update(lr);
            _context.LeaveRequestApproval.Update(lra);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,HR manager,Project manager")]
        [HttpPost]
        public IActionResult Reject(LeaveRequestApproval lra)
        {
            lra.Status = "Rejected";

            LeaveRequest lr = _context.LeaveRequest.Include("Employee").FirstOrDefault(lr => lr.Id == lra.LeaveRequestId);
            lr.Status = "Rejected";

            if (lr.Employee.OutOfOfficeBalance < 0)
            {
                return NotFound();
            }

            _context.LeaveRequest.Update(lr);
            _context.LeaveRequestApproval.Update(lra);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
