namespace Rftim3LeetCode.Temp
{
    public class _00149_MaxPointsOnALine
    {
        /// <summary>
        /// Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.
        /// </summary>
        public _00149_MaxPointsOnALine()
        {
            Console.WriteLine(MaxPoints(new int[][]
            {
                new int[] { 1,1 },
                new int[] { 2,2 },
                new int[] { 3,3 }
            }));
            Console.WriteLine(MaxPoints(new int[][]
            {
                new int[] { 1,1 },
                new int[] { 3,2 },
                new int[] { 5,3 },
                new int[] { 4,1 },
                new int[] { 2,3 },
                new int[] { 1,4 }
            }));
        }

        private static int MaxPoints(int[][] points)
        {
            int n = points.Length;
            if (n == 1) return 1;

            int c = 2;
            for (int i = 0; i < n; i++)
            {
                Dictionary<double, int> kvp = new();
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        double y = Math.Atan2(points[j][1] - points[i][1], points[j][0] - points[i][0]);
                        if (!kvp.ContainsKey(y)) kvp.Add(y, 1);
                        else kvp[y]++;
                    }
                }

                foreach (KeyValuePair<double, int> item in kvp)
                {
                    c = Math.Max(c, item.Value + 1);
                }
            }

            return c;
        }

        private static int MaxPoints0(int[][] points)
        {
            int max = int.MinValue;

            for (int i = 0; i < points.Length - 1; i++)
            {
                Dictionary<double, int> dict = new();
                double x1 = points[i][0];
                double y1 = points[i][1];
                int overlap = 0;

                for (int j = i + 1; j < points.Length; j++)
                {
                    double x2 = points[j][0];
                    double y2 = points[j][1];

                    double slope = 0;

                    if (x1 == x2 && y1 == y2) overlap++;
                    else if (x1 == x2) slope = int.MaxValue;
                    else slope = (y2 - y1) / (x2 - x1);

                    if (!dict.ContainsKey(slope)) dict.Add(slope, 1);
                    else dict[slope]++;

                }
                int localMax = 0;
                foreach (double item in dict.Keys)
                {
                    localMax = Math.Max(dict[item], localMax);
                }

                localMax += overlap;
                max = Math.Max(max, localMax);

            }

            return max == int.MinValue ? 1 : max + 1;
        }
    }
}
