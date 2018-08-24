using Newtonsoft.Json;

namespace FarGalaxy.Entities.Weather.Conditions
{
    [JsonObject(Title = "Optimo")]
    public class OptimalDay : Day
    {
        public override void Sum(WeatherForecastSummary weatherForecastSummary)
        {
            weatherForecastSummary.OptimalDays++;
        }

        public override string ToString()
        {
            return "Optimo";
        }
    }
}
