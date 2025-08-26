using Rftim3Convoy.Temp.Construct.Maths.Geometry.TwoDShapes;

namespace Rftim3Convoy.Temp.Construct.Maths.Geometry
{
    public class RftTriangleBarycentricCoordinateSystem
    {
        public RftTriangleBarycentricCoordinateSystem()
        {
            RftTriangle x = new(0, 0, 10, 0, 0, 10);
            Rft2DPoint y = new(4, 5);

            Console.WriteLine(PointInTriangleArea(x, y) ? "Point is inside the triangle." : "Point is outside the triangle.");
        }

        private static bool PointInTriangleArea(RftTriangle x, Rft2DPoint y)
        {
            double a = ((x.aY - x.bY) * (y.x - x.bX) + (x.bX - x.aX) * (y.y - x.bY)) / ((x.aY - x.bY) * (x.oX - x.bX) + (x.bX - x.aX) * (x.oY - x.bY));
            double b = ((x.bY - x.oX) * (y.x - x.bX) + (x.oX - x.bX) * (y.y - x.bY)) / ((x.aY - x.bY) * (x.oX - x.bX) + (x.bX - x.aX) * (x.oY - x.bY));
            double c = 1 - a - b;

            if (a >= 0 && a <= 1 && b >= 0 && b <= 1 && c >= 0 && c <= 1) return true; // Point is inside of the triangle
            else return false; // Point is outside of the triangle
        }
    }
}
