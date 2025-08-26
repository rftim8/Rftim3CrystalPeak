using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01480_RunningSumOf1DArray
    {
        /// <summary>
        /// Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
        /// Return the running sum of nums.
        /// </summary>
        public _01480_RunningSumOf1DArray()
        {
            int[] x = RunningSum([1, 2, 3, 4]);
            int[] x0 = RunningSum([1]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] RunningSum(int[] nums)
        {
            int n = nums.Length;

            for (int i = 1; i < n; i++)
            {
                nums[i] += nums[i - 1];
            }

            return nums;
        }
    }
}
