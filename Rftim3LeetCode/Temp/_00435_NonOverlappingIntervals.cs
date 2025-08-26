namespace Rftim3LeetCode.Temp
{
    public class _00435_NonOverlappingIntervals
    {
        /// <summary>
        /// Given an array of intervals intervals where intervals[i] = [starti, endi], return the minimum number of intervals 
        /// you need to remove to make the rest of the intervals non-overlapping.
        /// </summary>
        public _00435_NonOverlappingIntervals()
        {
            Console.WriteLine(EraseOverlapIntervals([
                [1,2],
                [2,3],
                [3,4],
                [1,3]
            ]));

            Console.WriteLine(EraseOverlapIntervals([
                [1,2],
                [1,2],
                [1,2]
            ]));

            Console.WriteLine(EraseOverlapIntervals([
                [1,2],
                [2,3]
            ]));

            Console.WriteLine(EraseOverlapIntervals([
                [1,100],
                [11,22],
                [1,11],
                [2,12]
            ]));
        }

        private static int EraseOverlapIntervals(int[][] intervals)
        {
            int n = intervals.Length;
            if (n == 1) return 0;

            Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
            int l = 0, r = intervals[0][1];

            for (int i = 1; i < n; i++)
            {
                if (intervals[i][0] < r) l++;
                else r = intervals[i][1];
            }

            return l;
        }
    }
}
