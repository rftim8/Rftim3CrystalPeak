using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00347_TopKFrequentElements
    {
        /// <summary>
        /// Given an integer array nums and an integer k, return the k most frequent elements. 
        /// You may return the answer in any order.
        /// </summary>
        public _00347_TopKFrequentElements()
        {
            int[] x = TopKFrequent([1, 1, 1, 2, 2, 3], 2);
            int[] x0 = TopKFrequent([-1, -1], 1);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] TopKFrequent(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 1) return [nums[0]];

            int[] c = new int[k];
            Array.Sort(nums);
            int x = nums[0];
            int y = 1;
            List<(int, int)> z = [];
            for (int i = 1; i < n; i++)
            {
                if (x == nums[i]) y++;
                else
                {
                    z.Add((x, y));
                    x = nums[i];
                    y = 1;
                }
                if (i == n - 1) z.Add((x, y));
            }
            z = [.. z.OrderByDescending(o => o.Item2)];
            for (int i = 0; i < k; i++)
            {
                c[i] = z[i].Item1;
            }

            return c;
        }
    }
}
