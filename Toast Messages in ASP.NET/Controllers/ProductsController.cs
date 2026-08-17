using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Toast_Messages_in_ASP.NET.Data;
using Toast_Messages_in_ASP.NET.Models;

namespace Toast_Messages_in_ASP.NET.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.OrderByDescending(p => p.Id).ToListAsync();
            return View(products);
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                _context.Products.Add(model);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Product created successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Invalid data!";
            return View(model);
        }

        // POST: /Products/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                TempData["Warning"] = "Product has been deleted!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
