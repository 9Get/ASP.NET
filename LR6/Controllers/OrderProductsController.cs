using LR6.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
{
    public class OrderProductsController : Controller
    {
        [HttpPost]
        public IActionResult RedirectToAction(Product[] products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product Name: {product.Name}");
            }

            return View(products);
        }
    }
}
