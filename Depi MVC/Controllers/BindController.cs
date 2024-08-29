using Microsoft.AspNetCore.Mvc;

namespace Depi_MVC.Controllers
{
    public class BindController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //domain/bind/testprimitive/1?name=ismail
        public IActionResult TestPrimitive(int id , string name) 
        {
            return Content($"{id},{name}");
        }
    }
}
