namespace FarGalaxy.Entities.Weather
{
    public abstract class Day
    {
        public int DayNumber { get; set; }
        public double Perimeter { protected get; set; }

        public abstract void Sum(WeatherForecastSummary weatherForecastSummary);
    }
}
