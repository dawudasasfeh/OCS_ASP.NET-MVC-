using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tuple_and_async_await_in_ASP.NET.Models;
using Tuple_and_async_await_in_ASP.NET.Data;

namespace Tuple_and_async_await_in_ASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            var student = new Student
            { 
                Name = "Ahmad Omar",
                Age = 22
            };

            var course = new Course
            {
                Name = "ASP.NET Core MVC",
                Instructor = "Eng. Dawud"
            };

            _context.Students.Add(student);
            _context.Courses.Add(course);
            _context.SaveChanges();

            var tuple = new Tuple<Student, Course>(student, course);

            return View(tuple);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
