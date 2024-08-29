using Depi_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Depi_MVC.Controllers
{
    public class CourseResultController : Controller
    {
        public IActionResult Index()
        {
            WebAppContext context = new WebAppContext();
            var cs = context.CourseResults.ToList();
            return View(cs);
        }
        public IActionResult Details(int id)
        {
            WebAppContext context = new WebAppContext();
            var cs = context.CourseResults.FirstOrDefault(x => x.Id == id);
            return View(cs);
        }
        [HttpGet]
        public IActionResult Add()
        {
            WebAppContext context = new WebAppContext();
            ViewBag.Courses = context.Courses.ToList();
            ViewBag.Trainees = context.Trainees.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(CourseResults model)
        {
            WebAppContext context = new WebAppContext();
            ViewBag.Trainees = context.Trainees.ToList();
            ViewBag.Courses = context.Courses.ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    context.CourseResults.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("msg", ex.InnerException.Message);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            WebAppContext context = new WebAppContext();
            CourseResults cs = context.CourseResults.FirstOrDefault(i => i.Id == id);
            ViewBag.Courses = context.Courses.ToList();
            ViewBag.Trainees = context.Trainees.ToList();
            return View(cs);
        }
        [HttpPost]
        public IActionResult Update(CourseResults model)
        {
            WebAppContext context = new WebAppContext();
            ViewBag.Trainees = context.Trainees.ToList();
            ViewBag.Courses = context.Courses.ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    context.CourseResults.Update(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("msg", ex.InnerException.Message);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            WebAppContext context = new WebAppContext();
            CourseResults model = context.CourseResults.FirstOrDefault(i => i.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Remove(CourseResults model)
        {
            WebAppContext context = new WebAppContext();
            context.CourseResults.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
