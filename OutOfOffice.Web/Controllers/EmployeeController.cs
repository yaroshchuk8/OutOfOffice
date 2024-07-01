using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DataAccess.Data;
using OutOfOffice.Models;

namespace OutOfOffice.Web.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> employee = from e in _context.Employee select e;
            return View();
        }
    }
}
