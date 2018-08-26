using FarGalaxy.Contracts;

namespace FarGalaxy.Dto
{
    public class WeatherForecastSummaryDto : BaseDto
    {
        public int RainyDays { get; set; }

        public int OptimalDays { get; set; }

        public int DroughtDays { get; set; }

        public int DayOfMaximumInstability { get; set; }

        public double Perimeter { get; set; }
    }
}
