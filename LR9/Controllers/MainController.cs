using LR9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LR9.Controllers
{
    public class MainController : Controller
    {
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProductPut(string name, string price)
        {
            bool result = false;
            Product product = new Product(name, double.Parse(price, CultureInfo.InvariantCulture), DateTime.Now);
            result = ProductRepository.AddProduct(product);
        
            TempData["Status"] = result;

            return View("AddProduct");
        }

        [HttpGet]
        [HttpPost]
        [Route("ProductView")]
        public IActionResult ProductView(string? mode)
        {
            if (mode == null)
            {
                TempData["mode"] = "list";
            }
            else
            {
                TempData["mode"] = mode;

            }
            TempData["Products"] = ProductRepository.GetProductList();
            return View();
        }

        [HttpPost]
        [Route("WeatherView")]
        public IActionResult WeatherView()
        {
            return View();
        }
    }
}
