using ASP_Task_1.Models;
using Microsoft.AspNetCore.Mvc;

public class StudentsController : Controller
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context) {
        _context = context;
    }


    //READ
    public IActionResult Index() {
        var students = _context.Students.ToList(); 
        return View(students);
    }

    //CREATE
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }
        _context.Students.Add(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    //UPDATE
    public IActionResult Edit(int id)
    {
        var student = _context.Students.Find(id);
        return View(student);
    }
    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }
        _context.Students.Update(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    //DELETE
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var student = _context.Students.Find(id);
        _context.Students.Remove(student);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}

