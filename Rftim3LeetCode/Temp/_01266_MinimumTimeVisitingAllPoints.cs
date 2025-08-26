namespace Rftim3LeetCode.Temp
{
    public class _01266_MinimumTimeVisitingAllPoints
    {
        /// <summary>
        /// On a 2D plane, there are n points with integer coordinates points[i] = [xi, yi]. 
        /// Return the minimum time in seconds to visit all the points in the order given by points.
        /// You can move according to these rules:
        /// In 1 second, you can either:
        /// move vertically by one unit,
        /// move horizontally by one unit, or
        /// move diagonally sqrt(2) units(in other words, move one unit vertically then one unit horizontally in 1 second).
        /// You have to visit the points in the same order as they appear in the array.
        /// You are allowed to pass through points that appear later in the order, but these do not count as visits.
        /// </summary>
        public _01266_MinimumTimeVisitingAllPoints()
        {
            Console.WriteLine(MinTimeToVisitAllPoints(
            [
                [1,1],
                [3,4],
                [-1,0]
            ]));

            Console.WriteLine(MinTimeToVisitAllPoints(
            [
                [3,2],
                [-2,2]
            ]));
        }

        private static int MinTimeToVisitAllPoints(int[][] points)
        {
            int c = 0;

            for (int i = 1; i < points.Length; i++)
            {
                c += Math.Max(Math.Abs(points[i][0] - points[i - 1][0]), Math.Abs(points[i][1] - points[i - 1][1]));
            }

            return c;
        }
    }
}
