using FarGalaxy.Mathematics.Geometry;

namespace FarGalaxy.Entities.Objects.Movements
{
    public class Clockwise : Movement
    {
        public override void Move(Planet planet, double theta, int interval)
        {
            Point point = Circle.ClockwisePoint(planet.Radius, theta * interval);
            planet.CoordinateX = point.X;
            planet.CoordinateY = point.Y;
        }
    }
}
