using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using WeatherService.Interfaces;

namespace WeatherService
{
    public class WeatherService : IWeatherService
    {
        public WeatherData GetData(string country, string city)
        {
            try
            {
                var url =
                   $"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22{city}%22%20and%20country.content%3D%22{country}%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

                var json = GET(url);
                return ConvertToWeatherData(json);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private WeatherData ConvertToWeatherData(string json)
        {
            try
            {
                dynamic data = JObject.Parse(json);

                return new WeatherData()
                {
                    Humidity = (int)data["query"]["results"]["channel"]["atmosphere"]["humidity"],
                    Format = data["query"]["results"]["channel"]["units"]["temperature"],
                    Value = (int)data["query"]["results"]["channel"]["item"]["condition"]["temp"]
                };
            }
            catch (Exception)
            {
                return null;
            }

        }

        string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException)
            {
                return null;
            }
        }

    }
}
