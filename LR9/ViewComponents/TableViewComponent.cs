using LR9.Models;
using Microsoft.AspNetCore.Mvc;

namespace LR9.ViewComponents
{
    public class TableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Product> products)
        {
            return View(products);
        }
    }
}
