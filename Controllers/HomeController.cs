using Microsoft.AspNetCore.Mvc;

namespace MySqlDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
