
using System;
using NSubstitute;
using Weather.Controllers;
using WeatherService;
using WeatherService.Interfaces;
using Xunit;

namespace WeatherTests
{
    public class WeatherControllerTests
    {

        [Fact]
        public void NullValuesTest()
        {
            var weatherService = Substitute.For<IWeatherService>();

            var result = new WeatherData
            {
                Format = "F",
                Humidity = 88,
                Value = 49
            };

            weatherService.GetData(Arg.Any<string>(), Arg.Any<string>()).Returns((WeatherData)null);

            var weatherController = new WeatherController(weatherService);
            Assert.Throws<Exception>(() => weatherController.Get("A","B"));
        }

        [Fact]
        public void PolandWarsawTest()
        {
            var weatherService = Substitute.For<IWeatherService>();

            var result = new WeatherData
            {
                Format = "F",
                Humidity = 88,
                Value = 49
            };

            weatherService.GetData("Poland", "Warsaw").Returns(result);

            var weatherController = new WeatherController(weatherService);
            Assert.NotNull(weatherController.Get("Poland", "Warsaw"));
        }

        [Fact]
        public void PolandGdanskTest()
        {
            var weatherService = Substitute.For<IWeatherService>();

            var result = new WeatherData
            {
                Format = "F",
                Humidity = 90,
                Value = 44
            };

            weatherService.GetData("Poland", "Gdansk").Returns(result);


            var weatherController = new WeatherController(weatherService);
            Assert.NotNull(weatherController.Get("Poland", "Gdansk"));
        }

        [Fact]
        public void GermanyBerlinTest()
        {
            var weatherService = Substitute.For<IWeatherService>();

            var result = new WeatherData
            {
                Format = "C",
                Humidity = 70,
                Value = 19
            };

            weatherService.GetData("Germany", "Berlin").Returns(result);


            var weatherController = new WeatherController(weatherService);
            Assert.NotNull(weatherController.Get("Germany", "Berlin"));
        }
    }
}
