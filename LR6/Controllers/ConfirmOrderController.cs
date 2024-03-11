using LR6.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
{
    public class ConfirmOrderController : Controller
    {
        [HttpPost]
        public IActionResult ConfirmOrder(User user)
        {
            if (user.Age > 16)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
