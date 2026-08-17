using Microsoft.AspNetCore.Mvc;
using Validation_in_ASP.NET__Client_Side_vs_Server_Side_.Data;
using Validation_in_ASP.NET__Client_Side_vs_Server_Side_.Models;
namespace Validation_in_ASP.NET__Client_Side_vs_Server_Side_.Controllers
{
    public class Employees : Controller
    {
        private readonly ApplicationDbContext _context;

        public Employees(ApplicationDbContext context) { 
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee) {
            if (!ModelState.IsValid)
                return View(employee);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
