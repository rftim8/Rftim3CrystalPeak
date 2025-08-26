using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00057_InsertInterval
    {
        /// <summary>
        /// You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval 
        /// and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.
        /// Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have 
        /// any overlapping intervals(merge overlapping intervals if necessary).
        /// Return intervals after the insertion.
        /// </summary>
        public _00057_InsertInterval()
        {
            int[][] x = InsertInterval0(
            [
                [1, 3],
                [6, 9]
            ],
            [2, 5]
            );

            RftTerminal.RftReadResult<int>(x);
        }

        public static int[][] InsertInterval0(int[][] a0, int[] a1) => RftInsertInterval0(a0, a1);

        private static int[][] RftInsertInterval0(int[][] intervals, int[] newInterval)
        {
            int n = intervals.Length;
            Array.Resize(ref intervals, n + 1);
            intervals[n] = newInterval;
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> ans = [intervals[0]];

            for (int i = 1; i < intervals.Length; i++)
            {
                if (ans[^1][1] >= intervals[i][0]) ans[^1][1] = Math.Max(ans[^1][1], intervals[i][1]);
                else ans.Add(intervals[i]);
            }

            return [.. ans];
        }

        private static int[][] RftInsertInterval1(int[][] intervals, int[] newInterval)
        {
            int Len = intervals.Length;
            int[] Starts = new int[Len + 1];
            int[] Ends = new int[Len + 1];
            for (int i = 0; i < Len; i++)
            {
                Starts[i] = intervals[i][0];
                Ends[i] = intervals[i][1];
            }

            Starts[Len] = newInterval[0];
            Ends[Len] = newInterval[1];
            Array.Sort(Starts);
            Array.Sort(Ends);
            List<int[]> Result = [];

            for (int i = 0, j = 0; i < Len + 1; i++)
            {
                if (i == Len || Starts[i + 1] > Ends[i])
                {
                    Result.Add([Starts[j], Ends[i]]);
                    j = i + 1;
                }
            }

            return Result.Select(i => i).ToArray();
        }
    }
}
