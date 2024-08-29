using Depi_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Depi_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            WebAppContext context = new WebAppContext();
            var departments = context.Departments.ToList();
            return View(departments);
        }
        public IActionResult Details(int id)
        {
            WebAppContext context = new WebAppContext();
            var department = context.Departments.FirstOrDefault(x => x.Id == id);
            return View(department);
        }
        [HttpGet]
        public IActionResult Add()
        {
            WebAppContext context = new WebAppContext();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Department model)
        {
            WebAppContext context = new WebAppContext();
            if (model is not null)
            {
                context.Departments.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            WebAppContext context = new WebAppContext();
            Department department = context.Departments.FirstOrDefault(i => i.Id == id);
            return View(department);
        }
        [HttpPost]
        public IActionResult Update(Department model)
        {
            WebAppContext context = new WebAppContext();
            if (model is not null)
            {
                context.Departments.Update(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            WebAppContext context = new WebAppContext();
            Department model = context.Departments.FirstOrDefault(i => i.Id == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Remove(Department model)
        {
            WebAppContext context = new WebAppContext();
            context.Departments.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
