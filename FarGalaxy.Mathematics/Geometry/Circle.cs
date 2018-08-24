using static System.Math;

namespace FarGalaxy.Mathematics.Geometry
{
    public static class Circle
    {
        public static Point ClockwisePoint(double radius, double theta)
        {
            Point point = new Point
            {
                X = Round(radius * Sin(theta), Math.Decimals),
                Y = Round(radius * Cos(theta), Math.Decimals)
            };

            return point;
        }

        public static Point AntiClockwisePoint(double radius, double theta)
        {
            Point point = new Point
            {
                X = Round(radius * Cos(theta + PI / 2), Math.Decimals),
                Y = Round(radius * Sin(theta + PI / 2), Math.Decimals)
            };

            return point;
        }
    }
}
