using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
