using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01929_ConcatenationOfArray
    {
        /// <summary>
        /// Given an integer array nums of length n, you want to create an array ans of length 2n where ans[i] == nums[i] and ans[i + n] == nums[i] for 0 <= i < n (0-indexed).
        /// Specifically, ans is the concatenation of two nums arrays.
        /// Return the array ans.
        /// </summary>
        public _01929_ConcatenationOfArray()
        {
            int[] x = GetConcatenation([1, 2, 1]);
            int[] x0 = GetConcatenation([1, 3, 2, 1]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] GetConcatenation(int[] nums)
        {
            int n = nums.Length;
            int m = n * 2;
            int[] r = new int[m];

            for (int i = 0; i < n; i++)
            {
                r[i] = nums[i];
                r[i + n] = nums[i];
            }

            return r;
        }
    }
}
