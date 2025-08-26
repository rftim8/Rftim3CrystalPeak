using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02032_TwoOutOfThree
    {
        /// <summary>
        /// Given three integer arrays nums1, nums2, and nums3, return a distinct array containing all the values that are present in at least two out of the three arrays.
        /// You may return the values in any order.
        /// </summary>
        public _02032_TwoOutOfThree()
        {
            IList<int> x = TwoOutOfThree([1, 1, 3, 2], [2, 3], [3]);
            RftTerminal.RftReadResult(x);
            IList<int> x0 = TwoOutOfThree([3, 1], [2, 3], [1, 2]);
            RftTerminal.RftReadResult(x0);
            IList<int> x1 = TwoOutOfThree([1, 2, 2], [4, 3, 3], [5]);
            RftTerminal.RftReadResult(x1);
        }

        private static List<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            HashSet<int> a0 = [.. nums1];
            HashSet<int> a1 = [.. nums2];
            HashSet<int> a2 = [.. nums3];

            Dictionary<int, int> r = [];
            foreach (int item in a0)
            {
                r[item] = 1;
            }
            foreach (int item in a1)
            {
                if (!r.TryGetValue(item, out int value)) r[item] = 1;
                else r[item] = ++value;
            }
            foreach (int item in a2)
            {
                if (!r.TryGetValue(item, out int value)) r[item] = 1;
                else r[item] = ++value;
            }

            return r.Where(o => o.Value > 1).Select(o => o.Key).ToList();
        }
    }
}
