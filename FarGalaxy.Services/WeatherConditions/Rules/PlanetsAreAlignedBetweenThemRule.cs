using FarGalaxy.Entities;
using FarGalaxy.Entities.Weather;
using FarGalaxy.Entities.Weather.Conditions;
using FarGalaxy.Entities.WeatherConditions.Rules;
using FarGalaxy.Mathematics;

namespace FarGalaxy.Services.WeatherConditions.Rules
{
    public class PlanetsAreAlignedBetweenThemRule : BaseRule<SolarSystem>
    {
        public override Day Request(SolarSystem solarSystem)
        {
            
            return ThePlanetAreAlignedBetweenThem(solarSystem) ? new OptimalDay() : Next.Request(solarSystem);
        }

        private bool ThePlanetAreAlignedBetweenThem(SolarSystem solarSystem)
        {
            var x1 = solarSystem.Ferengi.CoordinateX;
            var y1 = solarSystem.Ferengi.CoordinateY;
            var x2 = solarSystem.Betazoid.CoordinateX;
            var y2 = solarSystem.Betazoid.CoordinateY;
            var x3 = solarSystem.Vulcan.CoordinateX;
            var y3 = solarSystem.Vulcan.CoordinateY;

            return Vector.AreParallel(x1, y1, x2, y2, x3, y3);
        }
    }
}
