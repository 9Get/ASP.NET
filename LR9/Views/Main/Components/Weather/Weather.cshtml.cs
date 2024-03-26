using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LR9.Views.Main.Components.Weather
{
    public class WeatherModel : PageModel
    {
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double Pressure { get; set; }
        public void OnGet()
        {
        }
    }
}
