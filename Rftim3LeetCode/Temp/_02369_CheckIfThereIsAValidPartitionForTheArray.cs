namespace Rftim3LeetCode.Temp
{
    public class _02369_CheckIfThereIsAValidPartitionForTheArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums. You have to partition the array into one or more contiguous subarrays.
        /// We call a partition of the array valid if each of the obtained subarrays satisfies one of the following conditions:
        /// The subarray consists of exactly 2 equal elements.For example, the subarray [2,2] is good.
        /// The subarray consists of exactly 3 equal elements. For example, the subarray [4,4,4] is good.
        /// The subarray consists of exactly 3 consecutive increasing elements, that is, the difference between adjacent elements is 1. 
        /// For example, the subarray [3,4,5] is good, but the subarray[1, 3, 5] is not.
        /// Return true if the array has at least one valid partition. Otherwise, return false.
        /// </summary>

        // Top-Down DP
        private static readonly Dictionary<int, bool> memo = [];

        private static bool PrefixIsValid(int[] nums, int i)
        {
            if (memo.TryGetValue(i, out bool value)) return value;
            bool ans = false;

            if (i > 0 && nums[i] == nums[i - 1]) ans |= PrefixIsValid(nums, i - 2);
            if (i > 1 && nums[i] == nums[i - 1] && nums[i - 1] == nums[i - 2]) ans |= PrefixIsValid(nums, i - 3);
            if (i > 1 && nums[i] == nums[i - 1] + 1 && nums[i - 1] == nums[i - 2] + 1) ans |= PrefixIsValid(nums, i - 3);
            memo.Add(i, ans);

            return ans;
        }

        private static bool ValidPartition(int[] nums)
        {
            int n = nums.Length;
            memo[-1] = true;

            return PrefixIsValid(nums, n - 1);
        }

        // Bottom-Up DP
        private static bool ValidPartition0(int[] nums)
        {
            int n = nums.Length;
            bool[] dp = new bool[n + 1];
            dp[0] = true;

            for (int i = 0; i < n; i++)
            {
                int dpIndex = i + 1;

                if (i > 0 && nums[i] == nums[i - 1]) dp[dpIndex] |= dp[dpIndex - 2];
                if (i > 1 && nums[i] == nums[i - 1] && nums[i] == nums[i - 2]) dp[dpIndex] |= dp[dpIndex - 3];
                if (i > 1 && nums[i] == nums[i - 1] + 1 && nums[i] == nums[i - 2] + 2) dp[dpIndex] |= dp[dpIndex - 3];
            }

            return dp[n];
        }

        // Bottom-Up DP Space Optimized
        private static bool ValidPartition1(int[] nums)
        {
            int n = nums.Length;
            bool[] dp = new bool[3];
            dp[0] = true;

            for (int i = 0; i < n; i++)
            {
                int dpIndex = i + 1;
                bool ans = false;

                if (i > 0 && nums[i] == nums[i - 1]) ans |= dp[(dpIndex - 2) % 3];
                if (i > 1 && nums[i] == nums[i - 1] && nums[i] == nums[i - 2]) ans |= dp[(dpIndex - 3) % 3];
                if (i > 1 && nums[i] == nums[i - 1] + 1 && nums[i] == nums[i - 2] + 2) ans |= dp[(dpIndex - 3) % 3];

                dp[dpIndex % 3] = ans;
            }

            return dp[n % 3];
        }
    }
}
