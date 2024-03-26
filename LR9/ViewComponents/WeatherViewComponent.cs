using LR9.Views.Main.Components.Weather;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LR9.ViewComponents
{
    public class WeatherViewComponent : ViewComponent
    {
        static async Task<dynamic> GetWeatherData(string latitude, string longitude, string apiKey)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}");
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(jsonString);
                return data;
            }
        }

        public async Task<IViewComponentResult> InvokeAsync(string lat, string lng)
        {
            var api_key = Environment.GetEnvironmentVariable("b612cb38fe400d10eefe47823eff9197");

            dynamic weatherData = await GetWeatherData(lat, lng, api_key);

            double temperature = Math.Round((double)weatherData.main.temp - 273.15);
            int humidity = (int)weatherData.main.humidity;
            double pressure = (double)weatherData.main.pressure;

            var model = new WeatherModel
            {
                Temperature = temperature,
                Humidity = humidity,
                Pressure = pressure,
            };

            return View("Weather", model);
        }
    }
}
