namespace FarGalaxy.Mathematics.Geometry
{
    public static class Triangle
    {
        public static bool PointInside(double x1, double y1, double x2, double y2, double x3, double y3, double p1,
            double p2)
        {
            var sign1 = Sign(p1, p2, x1, y1, x2, y2) < 0;
            var sign2 = Sign(p1, p2, x2, y2, x3, y3) < 0;
            var sign3 = Sign(p1, p2, x3, y3, x1, y1) < 0;

            return sign1 == sign2 && sign2 == sign3;
        }

        private static double Sign(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return (x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3);
        }
    }
}
