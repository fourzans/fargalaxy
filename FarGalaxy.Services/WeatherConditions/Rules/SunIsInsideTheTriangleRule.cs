using FarGalaxy.Entities;
using FarGalaxy.Entities.Weather;
using FarGalaxy.Entities.Weather.Conditions;
using FarGalaxy.Entities.WeatherConditions.Rules;
using FarGalaxy.Mathematics.Geometry;

namespace FarGalaxy.Services.WeatherConditions.Rules
{
    public class SunIsInsideTheTriangleRule : BaseRule<SolarSystem>
    {
        public override Day Request(SolarSystem solarSystem)
        {
            return TheSunIsInsideTheTriangle(solarSystem) ? new RainyDay() : Next.Request(solarSystem);
        }

        private bool TheSunIsInsideTheTriangle(SolarSystem solarSystem)
        {
            var x1 = solarSystem.Ferengi.CoordinateX;
            var y1 = solarSystem.Ferengi.CoordinateY;
            var x2 = solarSystem.Betazoid.CoordinateX;
            var y2 = solarSystem.Betazoid.CoordinateY;
            var x3 = solarSystem.Vulcan.CoordinateX;
            var y3 = solarSystem.Vulcan.CoordinateY;
            var p1 = solarSystem.Sun.CoordinateX;
            var p2 = solarSystem.Sun.CoordinateY;

            return Triangle.PointInside(x1, y1, x2, y2, x3, y3, p1, p2);
        }
    }
}
