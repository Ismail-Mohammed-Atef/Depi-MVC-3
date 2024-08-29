using Depi_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Depi_MVC.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            WebAppContext context = new WebAppContext();
            var courses = context.Courses.ToList();
            return View(courses);
        }
        public IActionResult Details(int id)
        {
            WebAppContext context = new WebAppContext();
            var courses = context.Courses.FirstOrDefault(x => x.Id == id);
            return View(courses);
        }
        [HttpGet]
        public IActionResult Add()
        {
           
            WebAppContext context = new WebAppContext();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Course model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    WebAppContext context = new WebAppContext();
                    context.Courses.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch (Exception ex)
            {
                ModelState.AddModelError("msg", ex.InnerException.Message);
            }
           
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {

            WebAppContext context = new WebAppContext();
            var course = context.Courses.FirstOrDefault(i => i.Id == id);
            return View(course);
        }
        [HttpPost]
        public IActionResult Update(Course model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WebAppContext context = new WebAppContext();
                    context.Courses.Update(model);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("msg", ex.InnerException.Message);
            }
            
            return View(model);
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            WebAppContext context = new WebAppContext();
            var model = context.Courses.FirstOrDefault(i => i.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Remove(Course model)
        {
            WebAppContext context = new WebAppContext();
            context.Courses.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CheckDegree(int maxdegree,int minDegree)
        {
            if(maxdegree < minDegree)
            {
                return Json("The Max Degree Cannot Be Lower Than the Min Degree");
            }else if(maxdegree > 100) 
            {
                return Json(false);
            }
            return Json(true);
        }
        public IActionResult CheckMinDegree(int mindegree)
        {
            if (mindegree != 25)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
    }
}
