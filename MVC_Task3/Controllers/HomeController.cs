using Microsoft.AspNetCore.Mvc;
using MVC_Task3.Models;
using System.Diagnostics;

namespace MVC_Task3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return RedirectToPage("/Account/Login", new { area = "Identity" });
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
