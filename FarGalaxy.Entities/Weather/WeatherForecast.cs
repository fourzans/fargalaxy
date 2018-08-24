using FarGalaxy.Contracts.Weather;
using System.Collections.Generic;

namespace FarGalaxy.Entities.Weather
{
    public class WeatherForecast : IWeatherForecast
    {
        public List<Day> Days { get; set; }
    }
}
