using Newtonsoft.Json;

namespace FarGalaxy.Entities.Weather.Conditions
{
    [JsonObject(Title = "Sequía")]
    public class DroughtDay : Day
    {
        public override void Sum(WeatherForecastSummary weatherForecastSummary)
        {
            weatherForecastSummary.DroughtDays++;
        }

        public override string ToString()
        {
            return "Sequía";
        }
    }
}
