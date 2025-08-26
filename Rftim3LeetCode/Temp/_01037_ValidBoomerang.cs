namespace Rftim3LeetCode.Temp
{
    public class _01037_ValidBoomerang
    {
        /// <summary>
        /// Given an array points where points[i] = [xi, yi] represents a point on the X-Y plane, return true if these points are a boomerang.
        /// A boomerang is a set of three points that are all distinct and not in a straight line.
        /// </summary>
        public _01037_ValidBoomerang()
        {
            Console.WriteLine(IsBoomerang(
            [
                [1,1],
                [2,3],
                [3,2]
            ]));

            Console.WriteLine(IsBoomerang(
            [
                [1,1],
                [2,2],
                [3,3]
            ]));
        }

        private static bool IsBoomerang(int[][] p)
        {
            return (p[1][1] - p[0][1]) * (p[2][0] - p[1][0]) != (p[1][0] - p[0][0]) * (p[2][1] - p[1][1]);
        }

        private static bool IsBoomerang0(int[][] points)
        {
            int x1 = points[0][0], y1 = points[0][1];
            int x2 = points[1][0], y2 = points[1][1];
            int x3 = points[2][0], y3 = points[2][1];

            return (y2 - y1) * (x3 - x1) != (y3 - y1) * (x2 - x1);
        }
    }
}
