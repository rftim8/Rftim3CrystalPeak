namespace Rftim3LeetCode.Temp
{
    public class _00812_LargestTriangleArea
    {
        /// <summary>
        /// Given an array of points on the X-Y plane points where points[i] = [xi, yi], 
        /// return the area of the largest triangle that can be formed by any three different points. 
        /// Answers within 10-5 of the actual answer will be accepted.
        /// </summary>
        public _00812_LargestTriangleArea()
        {
            Console.WriteLine(LargestTriangleArea(
            [
                [0,0],
                [0,1],
                [1,0],
                [0,2],
                [2,0]
            ]));

            Console.WriteLine(LargestTriangleArea(
            [
                [1,0],
                [0,0],
                [0,1]
            ]));
        }

        private static double LargestTriangleArea(int[][] points)
        {
            return points.Max(
                a => points.Max(
                    b => points.Max(
                        c => a[0] * b[1] + b[0] * c[1] + c[0] * a[1] -
                             a[1] * b[0] - b[1] * c[0] - c[1] * a[0]
            ))) / 2D;
        }

        // Heron
        private static double CalculateTriangleArea(int[] p1, int[] p2, int[] p3)
        {
            return 0.5 * Math.Abs(p1[0] * (p2[1] - p3[1]) + p2[0] * (p3[1] - p1[1]) + p3[0] * (p1[1] - p2[1]));
        }

        private static double LargestTriangleArea0(int[][] points)
        {
            double largestArea = 0;

            for (int i = 0; i < points.Length - 2; i++)
            {
                for (int j = i + 1; j < points.Length - 1; j++)
                {
                    for (int k = j + 1; k < points.Length; k++)
                    {
                        double area = CalculateTriangleArea(points[i], points[j], points[k]);
                        largestArea = Math.Max(largestArea, area);
                    }
                }
            }

            return largestArea;
        }
    }
}
