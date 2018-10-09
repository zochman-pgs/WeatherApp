using System;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Weather.Models;
using WeatherService;
using WeatherService.Interfaces;

namespace Weather.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherService weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [HttpGet]
        [Route("api/weather/{country}/{city}")]
        public JsonResult<WeatherViewModel> Get(string country, string city)
        {
            var result = weatherService.GetData(country, city);
            if (result == null)
                throw new Exception("Something went wrong");
            var viewModel = new WeatherViewModelMapper().Map(result);
            return Json(viewModel);
        }
    }
}
