using LR6.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }
    }
}
