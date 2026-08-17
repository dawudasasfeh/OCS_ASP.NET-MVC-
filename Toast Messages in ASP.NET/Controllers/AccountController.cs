using Microsoft.AspNetCore.Mvc;
using Toast_Messages_in_ASP.NET.Models;

namespace Toast_Messages_in_ASP.NET.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Simple mock credential check
                if (model.Email == "admin@example.com" && model.Password == "123456")
                {
                    TempData["Success"] = "Welcome back!";
                    return RedirectToAction("Index", "Products");
                }

                TempData["Error"] = "Invalid data!";
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }
    }
}
