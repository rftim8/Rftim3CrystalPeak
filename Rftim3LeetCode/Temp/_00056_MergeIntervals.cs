using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00056_MergeIntervals
    {
        /// <summary>
        /// Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, 
        /// and return an array of the non-overlapping intervals that cover all the intervals in the input.
        /// </summary>
        public _00056_MergeIntervals()
        {
            int[][] x = MergeIntervals0([
                [1, 3],
                [2, 6],
                [8, 10],
                [15, 18]
            ]);
            RftTerminal.RftReadResult<int>(x);

            int[][] x0 = MergeIntervals0([
                [1, 4],
                [0, 0]
            ]);

            RftTerminal.RftReadResult<int>(x0);
        }

        public static int[][] MergeIntervals0(int[][] a0) => RftMergeIntervals0(a0);

        private static int[][] RftMergeIntervals0(int[][] intervals)
        {
            int n = intervals.Length;
            if (n == 1) return intervals;

            Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });
            List<(int, int)> x = [];

            int y = intervals[0][0], z = intervals[0][1];
            for (int i = 1; i < n; i++)
            {
                if (intervals[i][0] < y)
                {
                    y = intervals[i][0];
                    if (intervals[i][1] > z) z = intervals[i][1];
                }

                if (intervals[i][0] > z)
                {
                    x.Add((y, z));
                    y = intervals[i][0];
                    z = intervals[i][1];
                }
                else if (intervals[i][1] > z) z = intervals[i][1];

                Console.WriteLine($"{y}: {z}");
            }
            if (!x.Contains((y, z))) x.Add((y, z));

            int[][] x0 = new int[x.Count][];

            for (int i = 0; i < x.Count; i++)
            {
                x0[i] = [x[i].Item1, x[i].Item2];
            }

            return x0;
        }
    }
}
