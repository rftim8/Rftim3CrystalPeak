using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01282_GroupThePeopleGivenTheGroupSizeTheyBelongTo
    {
        /// <summary>
        /// There are n people that are split into some unknown number of groups. 
        /// Each person is labeled with a unique ID from 0 to n - 1.
        /// You are given an integer array groupSizes, where groupSizes[i] is the size of the group that person i is in. 
        /// For example, if groupSizes[1] = 3, then person 1 must be in a group of size 3.
        /// Return a list of groups such that each person i is in a group of size groupSizes[i].
        /// Each person should appear in exactly one group, and every person must be in a group.
        /// If there are multiple answers, return any of them.
        /// It is guaranteed that there will be at least one valid solution for the given input.
        /// </summary>
        public _01282_GroupThePeopleGivenTheGroupSizeTheyBelongTo()
        {
            IList<IList<int>> x = GroupThePeople([3, 3, 3, 3, 3, 1, 3]);
            IList<IList<int>> x0 = GroupThePeople([2, 1, 3, 3, 3, 2]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static List<IList<int>> GroupThePeople(int[] groupSizes)
        {
            int n = groupSizes.Length;

            Dictionary<int, List<int>> x = [];
            List<IList<int>> r = [];

            for (int i = 0; i < n; i++)
            {
                if (!x.ContainsKey(groupSizes[i])) x[groupSizes[i]] = [];
                x[groupSizes[i]].Add(i);

                if (x[groupSizes[i]].Count == groupSizes[i])
                {
                    r.Add(x[groupSizes[i]]);
                    x[groupSizes[i]] = [];
                }
            }

            return r;
        }
    }
}
