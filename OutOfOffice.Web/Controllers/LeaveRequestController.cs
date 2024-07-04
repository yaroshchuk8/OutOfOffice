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
            if (id != null && id != 0)
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
    }
}
