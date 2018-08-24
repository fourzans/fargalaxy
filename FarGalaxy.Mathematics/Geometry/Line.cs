using static System.Math;

namespace FarGalaxy.Mathematics.Geometry
{
    public static class Line
    {
        public static bool EquationForTwoPoints(double x1, double y1, double x2, double y2, double p1, double p2)
        {
            return Abs(Round(p1 - x1 / (x2 - x1), Math.Decimals) - Round(p2 - y1 / (y2 - y1), Math.Decimals)) < Math.Tolerance;
        }
    }
}
