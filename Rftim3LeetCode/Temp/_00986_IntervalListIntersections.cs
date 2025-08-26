using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00986_IntervalListIntersections
    {
        /// <summary>
        /// You are given two lists of closed intervals, firstList and secondList, where firstList[i] = [starti, endi] and secondList[j] = [startj, endj]. 
        /// Each list of intervals is pairwise disjoint and in sorted order.
        /// Return the intersection of these two interval lists.
        /// A closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.
        /// The intersection of two closed intervals is a set of real numbers that are either empty or represented as a closed interval.
        /// For example, the intersection of[1, 3] and[2, 4] is [2, 3].
        /// </summary>
        public _00986_IntervalListIntersections()
        {
            int[][] x = IntervalIntersection(
                [
                    [0,2],
                    [5,10],
                    [13,23],
                    [24,25]
                ],
                [
                    [1,5],
                    [8,12],
                    [15,24],
                    [25,26]
                ]
            );

            RftTerminal.RftReadResult<int>(x);
        }

        private static int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            List<int[]> x = [];
            int i = 0, j = 0;

            while (i < firstList.Length && j < secondList.Length)
            {
                int l = Math.Max(firstList[i][0], secondList[j][0]);
                int r = Math.Min(firstList[i][1], secondList[j][1]);
                if (l <= r) x.Add([l, r]);

                if (firstList[i][1] < secondList[j][1]) i++;
                else j++;
            }

            return [.. x];
        }
    }
}
