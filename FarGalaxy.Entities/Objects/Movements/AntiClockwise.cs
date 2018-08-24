using FarGalaxy.Mathematics.Geometry;

namespace FarGalaxy.Entities.Objects.Movements
{
    public class AntiClockwise : Movement
    {
        public override void Move(Planet planet, double theta, int interval)
        {
            Point point = Circle.AntiClockwisePoint(planet.Radius, theta * interval);
            planet.CoordinateX = point.X;
            planet.CoordinateY = point.Y;
        }
    }
}
