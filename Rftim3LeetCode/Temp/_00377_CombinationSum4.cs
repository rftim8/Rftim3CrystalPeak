namespace Rftim3LeetCode.Temp
{
    public class _00377_CombinationSum4
    {
        /// <summary>
        /// Given an array of distinct integers nums and a target integer target, return the number of possible combinations that add up to target.
        /// The test cases are generated so that the answer can fit in a 32-bit integer.
        /// </summary>
        public _00377_CombinationSum4()
        {
            Console.WriteLine(CombinationSum4([1, 2, 3], 4));
            Console.WriteLine(CombinationSum4([9], 3));
        }

        private static int CombinationSum4(int[] nums, int target)
        {
            int n = nums.Length;
            int[] combo = new int[target + 1];
            combo[0] = 1;

            for (int i = 1; i <= target; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i - nums[j] >= 0) combo[i] += combo[i - nums[j]];
                }
            }

            return combo[target];
        }

        private static int CombinationSum40(int[] nums, int target)
        {
            int[] dp = new int[target + 1];
            dp[0] = 1;
            Array.Sort(nums);

            for (int i = 1; i < target + 1; i++)
            {
                foreach (int num in nums)
                {
                    if (i - num >= 0) dp[i] += dp[i - num];
                    else continue;
                }
            }

            return dp[^1];
        }
    }
}
