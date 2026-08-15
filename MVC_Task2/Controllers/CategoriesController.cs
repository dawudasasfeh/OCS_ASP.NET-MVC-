using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using MVC_Task2.Data;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _iwebhost;
        public CategoriesController(ApplicationDbContext context, IWebHostEnvironment iwebhost)
        {
            _context = context;
            _iwebhost = iwebhost;
        }
        //READ
        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }
        //CREATE
        public IActionResult Create() {
            return View();
        }

        private string ImageSavingWithPath(Category category, IFormFile imageFile) {
            string wwwrootpath = _iwebhost.WebRootPath;
            string imgPath = Path.Combine(wwwrootpath, "images", "Categories");
            string fileName = category.Name + Path.GetExtension(imageFile.FileName);
            string filePath = Path.Combine(imgPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return "/images/Categories/" + category.Name + Path.GetExtension(imageFile.FileName);
        }
        [HttpPost]
        public IActionResult Create(Category category , IFormFile imageFile) {
            string path = ImageSavingWithPath(category, imageFile);

            category.ImgPath = path;

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Update
        public IActionResult Edit(int id)
        {

            var category = _context.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category,IFormFile imageFile)
        {
            var existingCategory = _context.Categories.Find(category.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;

            if (imageFile != null && imageFile.Length > 0)
            {
                existingCategory.ImgPath = ImageSavingWithPath(category, imageFile);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //DELETE
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
