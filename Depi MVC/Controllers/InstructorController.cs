using Depi_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Depi_MVC.Controllers
{
    public class InstructorController : Controller
    {
        //Instructor/Index

        public IActionResult Index()
        {
            WebAppContext context = new WebAppContext();
            var instructors = context.Instructors.ToList();
            return View(instructors);
        }
        public IActionResult Details(int id)
        {
            WebAppContext context = new WebAppContext();
            var instructor = context.Instructors.FirstOrDefault(x => x.Id == id);
            return View(instructor);
        }
        [HttpGet]
        public IActionResult Add()
        {
            WebAppContext context = new WebAppContext();
            ViewBag.Courses = context.Courses.ToList();
            ViewBag.Departments = context.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Instructor model)
        {
            WebAppContext context = new WebAppContext();
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            if (model is not null)
            {
                context.Instructors.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            WebAppContext context = new WebAppContext();
            Instructor instructor = context.Instructors.FirstOrDefault(i => i.Id == id);
            ViewBag.Courses = context.Courses.ToList();
            ViewBag.Departments = context.Departments.ToList();
            return View(instructor);
        }
        [HttpPost]
        public IActionResult Update(Instructor model)
        {
            WebAppContext context = new WebAppContext();
            ViewBag.Departments = context.Departments.ToList();
            ViewBag.Courses = context.Courses.ToList();
            if (model is not null)
            {
                context.Instructors.Update(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            WebAppContext context = new WebAppContext();
            Instructor model = context.Instructors.FirstOrDefault(i=>i.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Remove(Instructor model)
        {
            WebAppContext context = new WebAppContext();
            context.Instructors.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}