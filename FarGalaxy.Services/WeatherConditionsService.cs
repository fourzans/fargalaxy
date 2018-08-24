using FarGalaxy.Entities;
using FarGalaxy.Entities.Objects;
using FarGalaxy.Entities.Weather;
using FarGalaxy.Entities.WeatherConditions.Rules;
using FarGalaxy.Mathematics.Geometry;
using FarGalaxy.Repositories;
using FarGalaxy.Services.WeatherConditions.Rules;
using FarGalaxy.Services.WeatherConditions.Weather;
using System.Collections.Generic;

namespace FarGalaxy.Services
{
    public class WeatherConditionsService : IWeatherConditionsService
    {
        private readonly IGalaxyRepository _galaxyRepository;

        private readonly BaseRule<SolarSystem> _rule = new PlanetsAreAlignedWithTheSunRule();

        public WeatherConditionsService(IGalaxyRepository galaxyRepository)
        {
            _galaxyRepository = galaxyRepository;

            _rule
                .SetNext(new PlanetsAreAlignedBetweenThemRule()
                    .SetNext(new SunIsInsideTheTriangleRule()
                        .SetNext(new UnknownRule())));
        }

        public WeatherForecast GetWeatherForecast(int days)
        {
            WeatherForecast weatherForecast = new WeatherForecast { Days = new List<Day>() };

            var solarSystem = _galaxyRepository.GetSolarSystem();

            for (var i = 0; i <= days; i++)
            {
                Day day = GetDayFromNumberOfTheDay(solarSystem, i);
                weatherForecast.Days.Add(day);
            }

            return weatherForecast;
        }

        public WeatherForecastSummary GetWeatherForecastSummary(int days)
        {
            WeatherForecastSummary summary = new WeatherForecastSummary();

            var solarSystem = _galaxyRepository.GetSolarSystem();

            for (var number = 0; number <= days; number++)
            {
                Day day = GetDayFromNumberOfTheDay(solarSystem, number);
                summary.IncrementDay(day);
            }

            return summary;
        }

        private Day GetSpecificDay(SolarSystem solarSystem)
        {
            return _rule.Request(solarSystem);
        }

        private Day GetDayFromNumberOfTheDay(SolarSystem solarSystem, int i)
        {
            StartSimulation(solarSystem, i);

            Day day = GetSpecificDay(solarSystem);
            day.Perimeter = DegreeOfInstability(solarSystem);
            day.DayNumber = i;

            return day;
        }

        private void StartSimulation(SolarSystem solarSystem, int day)
        {
            foreach (Planet planet in solarSystem.Planets)
                planet.Move(day);
        }

        private double DegreeOfInstability(SolarSystem solarSystem)
        {
            var x1 = solarSystem.Ferengi.CoordinateX;
            var y1 = solarSystem.Ferengi.CoordinateY;
            var x2 = solarSystem.Betazoid.CoordinateX;
            var y2 = solarSystem.Betazoid.CoordinateY;
            var x3 = solarSystem.Vulcan.CoordinateX;
            var y3 = solarSystem.Vulcan.CoordinateY;

            return Perimeter.Triangle(x1, y1, x2, y2, x3, y3);
        }
    }
}
