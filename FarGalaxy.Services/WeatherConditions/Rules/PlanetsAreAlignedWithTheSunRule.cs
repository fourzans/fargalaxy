using FarGalaxy.Entities;
using FarGalaxy.Entities.Weather;
using FarGalaxy.Entities.Weather.Conditions;
using FarGalaxy.Entities.WeatherConditions.Rules;
using FarGalaxy.Mathematics;
using FarGalaxy.Mathematics.Geometry;

namespace FarGalaxy.Services.WeatherConditions.Rules
{
    public class PlanetsAreAlignedWithTheSunRule : BaseRule<SolarSystem>
    {
        public override Day Request(SolarSystem solarSystem)
        {
            return ThePlanetsAreAlignedWithTheSun(solarSystem) ? new DroughtDay() : Next.Request(solarSystem);
        }

        private bool ThePlanetsAreAlignedWithTheSun(SolarSystem solarSystem)
        {
            if (TheyAreOnAxes(solarSystem))
                return true;
            if (ThePlanetAreAlignedBetweenThem(solarSystem))
                if (TheyPassThroughTheSun(solarSystem))
                    return true;
            return false;
        }

        private bool TheyAreOnAxes(SolarSystem solarSystem)
        {
            var x1 = solarSystem.Ferengi.CoordinateX;
            var y1 = solarSystem.Ferengi.CoordinateY;
            var x2 = solarSystem.Betazoid.CoordinateX;
            var y2 = solarSystem.Betazoid.CoordinateY;
            var x3 = solarSystem.Vulcan.CoordinateX;
            var y3 = solarSystem.Vulcan.CoordinateY;

            return Vector.TheyAreOnAxes(x1, y1, x2, y2, x3, y3);
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

        private bool TheyPassThroughTheSun(SolarSystem solarSystem)
        {
            var x1 = solarSystem.Ferengi.CoordinateX;
            var y1 = solarSystem.Ferengi.CoordinateY;
            var x2 = solarSystem.Betazoid.CoordinateX;
            var y2 = solarSystem.Betazoid.CoordinateY;

            return Line.EquationForTwoPoints(x1, y1, x2, y2, 0, 0);
        }
    }
}
