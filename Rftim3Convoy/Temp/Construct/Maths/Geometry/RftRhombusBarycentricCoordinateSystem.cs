using Rftim3Convoy.Temp.Construct.Maths.Geometry.TwoDShapes;

namespace Rftim3Convoy.Temp.Construct.Maths.Geometry
{
    public class RftRhombusBarycentricCoordinateSystem
    {
        public RftRhombusBarycentricCoordinateSystem()
        {
            Rft2DPoint p = new(-5, -4);
            //int equilateralDiagonal = 20;
            //int longDiagonal = 20;
            //int smallDiagonal = 10;
            //int diameter = 20;
            int radius = 10;

            PointInRhombusArea(radius, p);
        }

        private static void PointInRhombusArea(int radius, Rft2DPoint p)
        {
            RftRhombus r = new(
                new RftTriangle(0, 0, 0, -radius, radius, 0),
                new RftTriangle(0, 0, radius, 0, 0, radius),
                new RftTriangle(0, 0, 0, radius, -radius, 0),
                new RftTriangle(0, 0, -radius, 0, 0, -radius)
                );

            bool ur = PointInTriangleArea(r.tNE, p);
            bool dr = PointInTriangleArea(r.tSE, p);
            bool dl = PointInTriangleArea(r.tSW, p);
            bool ul = PointInTriangleArea(r.tNW, p);

            if (ur || dr || dl || ul)
            {
                Console.WriteLine("Point is inside Rhombus");
            }

            Console.WriteLine($"ur: {ur}\ndr: {dr}\ndl: {dl}\nul: {ul}");
        }

        private static bool PointInTriangleArea(RftTriangle t, Rft2DPoint p)
        {
            double a = ((t.aY - t.bY) * (p.x - t.bX) + (t.bX - t.aX) * (p.y - t.bY)) / ((t.aY - t.bY) * (t.oX - t.bX) + (t.bX - t.aX) * (t.oY - t.bY));
            double b = ((t.bY - t.oX) * (p.x - t.bX) + (t.oX - t.bX) * (p.y - t.bY)) / ((t.aY - t.bY) * (t.oX - t.bX) + (t.bX - t.aX) * (t.oY - t.bY));
            double c = 1 - a - b;

            if (a >= 0 && a <= 1 && b >= 0 && b <= 1 && c >= 0 && c <= 1) return true; // Point is inside of the triangle
            else return false; // Point is outside of the triangle
        }
    }
}
