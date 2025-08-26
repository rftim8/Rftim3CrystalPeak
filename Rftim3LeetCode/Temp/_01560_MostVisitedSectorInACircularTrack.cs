using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01560_MostVisitedSectorInACircularTrack
    {
        /// <summary>
        /// Given an integer n and an integer array rounds. We have a circular track which consists of n sectors labeled from 1 to n. 
        /// A marathon will be held on this track, the marathon consists of m rounds. 
        /// The ith round starts at sector rounds[i - 1] and ends at sector rounds[i]. 
        /// For example, round 1 starts at sector rounds[0] and ends at sector rounds[1]
        /// Return an array of the most visited sectors sorted in ascending order.
        /// Notice that you circulate the track in ascending order of sector numbers in the counter-clockwise direction (See the first example).
        /// </summary>
        public _01560_MostVisitedSectorInACircularTrack()
        {
            IList<int> x = MostVisited(4, [1, 3, 1, 2]);
            IList<int> x0 = MostVisited(2, [2, 1, 2, 1, 2, 1, 2, 1, 2]);
            IList<int> x1 = MostVisited(7, [1, 3, 5, 7]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static List<int> MostVisited(int n, int[] rounds)
        {
            List<int> result = [];

            int start = rounds[0];
            int end = rounds[^1];

            if (start <= end)
            {
                for (int i = start; i <= end; i++)
                {
                    result.Add(i);
                }
            }
            else
            {
                for (int i = 1; i <= end; i++)
                {
                    result.Add(i);
                }

                for (int i = start; i <= n; i++)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
