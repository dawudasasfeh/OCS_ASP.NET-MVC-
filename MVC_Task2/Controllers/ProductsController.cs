using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task2.Data;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _iwebhost;
        public ProductsController(ApplicationDbContext context, IWebHostEnvironment iwebhost)
        {
            _context = context;
            _iwebhost = iwebhost;
        }

        //READ
        public IActionResult Index()

        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        //CREATE
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        private string ImageSavingWithPath(Product product, IFormFile imageFile)
        {
            string wwwrootpath = _iwebhost.WebRootPath;
            string imgPath = Path.Combine(wwwrootpath, "images", "Products");
            string fileName = product.Name + Path.GetExtension(imageFile.FileName);
            string filePath = Path.Combine(imgPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return "/images/Products/" + product.Name + Path.GetExtension(imageFile.FileName);
        }

        [HttpPost]
        public IActionResult Create(Product product,IFormFile imageFile)
        {
            string path = ImageSavingWithPath(product, imageFile);
            product.ImgPath = path;

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product,IFormFile imageFile)
        {

            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Category = product.Category;

            if (imageFile != null && imageFile.Length > 0)
            {
                existingProduct.ImgPath = ImageSavingWithPath(product, imageFile);
            }

            //_context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)

        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
