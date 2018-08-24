using FarGalaxy.Contracts.Weather;

namespace FarGalaxy.Entities.Weather
{
    public class WeatherForecastSummary : IWeatherForecastSummary
    {
        public int RainyDays { get; set; }
        public int OptimalDays { get; set; }
        public int DroughtDays { get; set; }
        public int DayOfMaximumInstability { get; set; }
        public double Perimeter { get; set; }

        public void IncrementDay(Day day)
        {
            day.Sum(this);
        }
    }
}
