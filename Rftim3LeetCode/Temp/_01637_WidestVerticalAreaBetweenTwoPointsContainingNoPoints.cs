namespace Rftim3LeetCode.Temp
{
    public class _01637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints
    {
        /// <summary>
        /// Given n points on a 2D plane where points[i] = [xi, yi], 
        /// Return the widest vertical area between two points such that no points are inside the area.
        /// 
        /// A vertical area is an area of fixed-width extending infinitely along the y - axis(i.e., infinite height).
        /// The widest vertical area is the one with the maximum width.
        /// 
        /// Note that points on the edge of a vertical area are not considered included in the area.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public _01637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints()
        {
            Console.WriteLine(MaxWidthOfVerticalArea0([[8, 7], [9, 9], [7, 4], [9, 7]]));
            Console.WriteLine(MaxWidthOfVerticalArea0([[3, 1], [9, 0], [1, 0], [1, 4], [5, 3], [8, 8]]));
        }

        public static int MaxWidthOfVerticalArea0(int[][] input) => RftMaxWidthOfVerticalArea0(input);

        public static int MaxWidthOfVerticalArea1(int[][] input) => RftMaxWidthOfVerticalArea1(input);

        private static int RftMaxWidthOfVerticalArea0(int[][] points)
        {
            int n = points.Length;
            int a = int.MinValue;
            Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));

            for (int i = 0; i < n - 1; i++)
            {
                a = Math.Max(a, points[i + 1][0] - points[i][0]);
            }

            return a;
        }

        private static int RftMaxWidthOfVerticalArea1(int[][] points)
        {
            int[] xpoints = new int[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                xpoints[i] = points[i][0];
            }

            Array.Sort(xpoints);
            int maxWidth = 0;
            for (int i = 1; i < xpoints.Length; i++)
            {
                maxWidth = Math.Max(maxWidth, xpoints[i] - xpoints[i - 1]);
            }

            return maxWidth;

        }
    }
}