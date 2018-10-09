using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService
{
    public class WeatherData
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Format { get; set; }
        public int Value { get; set; }
        public int Humidity { get; set; }
    }
}
