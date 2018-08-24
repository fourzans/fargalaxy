using FarGalaxy.Entities.Weather;

namespace FarGalaxy.Services.WeatherConditions.Weather
{
    public interface IWeatherConditionsService
    {
        WeatherForecast GetWeatherForecast(int days);

        WeatherForecastSummary GetWeatherForecastSummary(int days);
    }
}
