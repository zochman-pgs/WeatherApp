namespace WeatherService.Interfaces
{
    public interface IWeatherService
    {
        WeatherData GetData(string country, string city);
    }
}
