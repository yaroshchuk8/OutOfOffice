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

        public IActionResult Index()
        {
            IEnumerable<LeaveRequest> leaveRequests = _context.LeaveRequest.Include("Employee").ToList();
            return View(leaveRequests);
        }

        public IActionResult Upsert(int? id)
        {
            LeaveRequestVM leaveRequestVM = new();

            // create new entry
            if (id == null || id == 0)
            {
                leaveRequestVM.LeaveRequest = new()
                {
                    EmployeeId = User.FindFirstValue(ClaimTypes.NameIdentifier),
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

        [HttpPost]
        public IActionResult Upsert(LeaveRequestVM leaveRequestVM)
        {
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
