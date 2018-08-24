using static System.Math;

namespace FarGalaxy.Mathematics
{
    public static class Vector
    {
        public static bool AreParallel(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return Abs(Round((x2 - x1) / (x3 - x2), Math.Decimals) - Round((y2 - y1) / (y3 - y2), Math.Decimals)) < Math.Tolerance;
        }

        public static bool TheyAreOnAxes(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            if (Abs(x1) < Math.Tolerance && Abs(x2) < Math.Tolerance && Abs(x3) < Math.Tolerance)
                return true;

            return Abs(y1) < Math.Tolerance && Abs(y2) < Math.Tolerance && Abs(y3) < Math.Tolerance;
        }
    }
}
