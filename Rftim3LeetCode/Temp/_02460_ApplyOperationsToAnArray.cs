using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02460_ApplyOperationsToAnArray
    {
        /// <summary>
        /// You are given a 0-indexed array nums of size n consisting of non-negative integers.
        /// You need to apply n - 1 operations to this array where, in the ith operation(0-indexed), you will apply the following on the ith element of nums:
        /// If nums[i] == nums[i + 1], then multiply nums[i] by 2 and set nums[i + 1] to 0. Otherwise, you skip this operation.
        /// After performing all the operations, shift all the 0's to the end of the array.
        /// For example, the array[1, 0, 2, 0, 0, 1] after shifting all its 0's to the end, is [1,2,1,0,0,0].
        /// Return the resulting array.
        /// Note that the operations are applied sequentially, not all at once.
        /// </summary>
        public _02460_ApplyOperationsToAnArray()
        {
            int[] x = ApplyOperations([1, 2, 2, 1, 1, 0]);
            RftTerminal.RftReadResult(x);
            int[] x0 = ApplyOperations([0, 1]);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] ApplyOperations(int[] nums)
        {
            int n = nums.Length;
            int[] x = new int[n];
            Array.Fill(x, 0);
            int j = 0;

            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    nums[i] *= 2;
                    nums[i + 1] = 0;
                }
                if (nums[i] != 0)
                {
                    x[j] = nums[i];
                    j++;
                }
            }
            if (nums[n - 1] != 0) x[j] = nums[n - 1];

            return x;
        }
    }
}
