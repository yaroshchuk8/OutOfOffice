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

        public IActionResult Index()
        {
            IEnumerable<LeaveRequestApproval> leaveRequestApprovals = _context.LeaveRequestApproval.Include("Approver").ToList();

            return View(leaveRequestApprovals);
        }

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
