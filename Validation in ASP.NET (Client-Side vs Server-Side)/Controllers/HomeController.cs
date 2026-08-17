using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Validation_in_ASP.NET__Client_Side_vs_Server_Side_.Models;

namespace Validation_in_ASP.NET__Client_Side_vs_Server_Side_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
