using Microsoft.AspNetCore.Mvc;

namespace LR11.Controllers
{
    [UniqueUsersFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
