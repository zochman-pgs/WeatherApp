using Weather.Models;
using WeatherService;

namespace Weather.Controllers
{
    internal class WeatherViewModelMapper
    {
        public WeatherViewModel Map(WeatherData weatherData, Location location)
        {
            return new WeatherViewModel
            {
                location = location,
                temperature = new Temperature
                {
                    format = weatherData.Format,
                    humidity = weatherData.Humidity,
                    value = weatherData.Value
                }
            };
        }
    }
}