using Microsoft.AspNetCore.Mvc;
 using ToDoListWithType.Models;

namespace  ToDoListWithType.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}