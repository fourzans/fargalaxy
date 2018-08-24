using Newtonsoft.Json;

namespace FarGalaxy.Entities.Weather.Conditions
{
    [JsonObject(Title = "Lluvioso")]
    public class RainyDay : Day
    {
        public override void Sum(WeatherForecastSummary weatherForecastSummary)
        {
            weatherForecastSummary.RainyDays++;
            if (Perimeter > weatherForecastSummary.Perimeter)
            {
                weatherForecastSummary.Perimeter = Perimeter;
                weatherForecastSummary.DayOfMaximumInstability = DayNumber;
            }
        }

        public override string ToString()
        {
            return "Lluvioso";
        }
    }
}
