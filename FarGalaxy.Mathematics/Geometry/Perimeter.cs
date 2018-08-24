using static System.Math;

namespace FarGalaxy.Mathematics.Geometry
{
    public static class Perimeter
    {
        public static double Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return Sqrt(Pow(x1 - x2, 2) + Pow(y2 - y1, 2)) + Sqrt(Pow(x2 - x3, 2) + Pow(y3 - y2, 2)) + Sqrt(Pow(x3 - x1, 2) + Pow(y1 - y3, 2));
        }
    }
}
