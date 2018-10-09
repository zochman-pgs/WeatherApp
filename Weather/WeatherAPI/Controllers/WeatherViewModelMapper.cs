using Weather.Models;
using WeatherService;

namespace Weather.Controllers
{
    internal class WeatherViewModelMapper
    {
        public WeatherViewModel Map(WeatherData weatherData)
        {
            return new WeatherViewModel
            {
                location = new Location
                {
                    city = weatherData.City,
                    country = weatherData.Country
                },
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