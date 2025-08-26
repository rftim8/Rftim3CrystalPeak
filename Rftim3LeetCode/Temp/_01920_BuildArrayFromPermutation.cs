using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01920_BuildArrayFromPermutation
    {
        /// <summary>
        /// Given a zero-based permutation nums (0-indexed), build an array ans of the same length where ans[i] = nums[nums[i]] for each 0 <= i < nums.length and return it.
        /// A zero-based permutation nums is an array of distinct integers from 0 to nums.length - 1 (inclusive).
        /// </summary>
        public _01920_BuildArrayFromPermutation()
        {
            int[] x = BuildArray([0, 2, 1, 5, 3, 4]);
            int[] x0 = BuildArray([5, 0, 1, 2, 3, 4]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] BuildArray(int[] nums)
        {
            int n = nums.Length;
            int[] r = new int[n];

            for (int i = 0; i < n; i++)
            {
                r[i] = nums[nums[i]];
            }

            return r;
        }
    }
}
