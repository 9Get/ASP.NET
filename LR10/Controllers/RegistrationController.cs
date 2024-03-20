using Microsoft.AspNetCore.Mvc;
using LR10.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LR10.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public string Registration(Customer customer)
        {
            if (ModelState.IsValid)
            {
                return customer.ToString();
            }

            string errorMessages = "";

            foreach (var item in ModelState)
            {
                if (item.Value.ValidationState == ModelValidationState.Invalid)
                {
                    errorMessages = ($"{errorMessages}\nПомилки властивості {item.Key}:\n");

                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages = ($"{errorMessages}{error.ErrorMessage}\n");
                    }
                }
            }

            return errorMessages;
        }
    }
}