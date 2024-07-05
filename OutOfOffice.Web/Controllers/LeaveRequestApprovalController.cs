using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.DataAccess.Data;
using OutOfOffice.Models;

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
    }
}
