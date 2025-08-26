using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01272_RemoveInterval
    {
        /// <summary>
        /// A set of real numbers can be represented as the union of several disjoint intervals, where each interval is in the form [a, b). 
        /// A real number x is in the set if one of its intervals [a, b) contains x (i.e. a <= x < b).
        /// 
        /// You are given a sorted list of disjoint intervals intervals representing a set of real numbers as described above, 
        /// where intervals[i] = [ai, bi] represents the interval[ai, bi). 
        /// You are also given another interval toBeRemoved.
        /// 
        /// Return the set of real numbers with the interval toBeRemoved removed from intervals.
        /// In other words, return the set of real numbers such that every x in the set is in intervals but not in toBeRemoved.
        /// Your answer should be a sorted list of disjoint intervals as described above.
        /// </summary>
        public _01272_RemoveInterval()
        {
            IList<IList<int>> a0 = RemoveInterval0([[0, 2], [3, 4], [5, 7]], [1, 6]);
            RftTerminal.RftReadResult(a0);

            IList<IList<int>> b0 = RemoveInterval0([[0, 5]], [2, 3]);
            RftTerminal.RftReadResult(b0);

            IList<IList<int>> c0 = RemoveInterval0([[-5, -4], [-3, -2], [1, 2], [3, 5], [8, 9]], [-1, 4]);
            RftTerminal.RftReadResult(c0);
        }

        public static IList<IList<int>> RemoveInterval0(int[][] a0, int[] a1) => RftRemoveInterval0(a0, a1);

        // Sweep line, one pass
        private static List<IList<int>> RftRemoveInterval0(int[][] intervals, int[] toBeRemoved)
        {
            List<IList<int>> result = [];
            foreach (int[] interval in intervals)
            {
                if (interval[0] > toBeRemoved[1] || interval[1] < toBeRemoved[0]) result.Add([interval[0], interval[1]]);
                else
                {
                    if (interval[0] < toBeRemoved[0]) result.Add([interval[0], toBeRemoved[0]]);
                    if (interval[1] > toBeRemoved[1]) result.Add([toBeRemoved[1], interval[1]]);
                }
            }

            return result;
        }
    }
}
