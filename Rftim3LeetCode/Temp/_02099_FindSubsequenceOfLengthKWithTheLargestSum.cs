using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02099_FindSubsequenceOfLengthKWithTheLargestSum
    {
        /// <summary>
        /// You are given an integer array nums and an integer k. 
        /// You want to find a subsequence of nums of length k that has the largest sum.
        /// Return any such subsequence as an integer array of length k.
        /// A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
        /// </summary>
        public _02099_FindSubsequenceOfLengthKWithTheLargestSum()
        {
            int[] x = MaxSubsequence([2, 1, 3, 3], 2);
            RftTerminal.RftReadResult(x);
            int[] x0 = MaxSubsequence([-1, -2, 3, 4], 3);
            RftTerminal.RftReadResult(x0);
            int[] x1 = MaxSubsequence([3, 4, 3, 3], 2);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] MaxSubsequence(int[] nums, int k)
        {
            int n = nums.Length;
            int[] q = new int[n];
            Array.Copy(nums, q, n);
            Array.Sort(q);
            int[] x = q[^k..];

            List<int> r = [];
            Dictionary<int, int> t = [];

            for (int i = 0; i < x.Length; i++)
            {
                if (t.TryGetValue(x[i], out int value)) t[x[i]] = ++value;
                else t[x[i]] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                if (t.TryGetValue(nums[i], out int value))
                {
                    r.Add(nums[i]);
                    t[nums[i]] = --value;
                    if (value == 0) t.Remove(nums[i]);
                }
            }

            return [.. r];
        }

        private static int[] MaxSubsequence0(int[] nums, int k)
        {
            int len = nums.Length, index = 0;
            int[] copy = new int[len];
            Array.Copy(nums, copy, len);
            Array.Sort(nums);
            List<int> excludes = [.. nums[0..(len - k)]];
            int[] res = new int[k];
            foreach (int c in copy)
            {
                if (!excludes.Remove(c)) res[index++] = c;
            }

            return res;
        }
    }
}
