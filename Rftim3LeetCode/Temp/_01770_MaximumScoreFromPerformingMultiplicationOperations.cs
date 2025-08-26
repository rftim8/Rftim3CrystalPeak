namespace Rftim3LeetCode.Temp
{
    public class _01770_MaximumScoreFromPerformingMultiplicationOperations
    {
        /// <summary>
        /// You are given two 0-indexed integer arrays nums and multipliers 
        /// of size n and m respectively, where n >= m.
        /// 
        /// You begin with a score of 0. You want to perform exactly m operations.
        /// On the ith operation(0-indexed) you will:
        /// 
        /// Choose one integer x from either the start or the end of the array nums.
        /// Add multipliers[i] * x to your score.
        /// Note that multipliers[0] corresponds to the first operation, 
        /// multipliers[1] to the second operation, and so on.
        /// Remove x from nums.
        /// Return the maximum score after performing m operations.
        /// </summary>
        public _01770_MaximumScoreFromPerformingMultiplicationOperations()
        {
            Console.WriteLine(MaximumScoreFromPerformingMultiplicationOperations0([1, 2, 3], [3, 2, 1]));
            Console.WriteLine(MaximumScoreFromPerformingMultiplicationOperations0([-5, -3, -3, -2, 7, 1], [-10, -5, 3, 4, 6]));
        }

        public static int MaximumScoreFromPerformingMultiplicationOperations0(int[] a0, int[] a1) => RftMaximumScoreFromPerformingMultiplicationOperations0(a0, a1);

        public static int MaximumScoreFromPerformingMultiplicationOperations1(int[] a0, int[] a1) => RftMaximumScoreFromPerformingMultiplicationOperations1(a0, a1);

        public static int MaximumScoreFromPerformingMultiplicationOperations2(int[] a0, int[] a1) => RftMaximumScoreFromPerformingMultiplicationOperations2(a0, a1);

        public static int MaximumScoreFromPerformingMultiplicationOperations3(int[] a0, int[] a1) => RftMaximumScoreFromPerformingMultiplicationOperations3(a0, a1);

        // Brute Force
        private static int RftMaximumScoreFromPerformingMultiplicationOperations0(int[] nums, int[] multipliers)
        {
            return Helper(nums, multipliers, 0, nums.Length - 1, 0);
        }

        private static int Helper(int[] nums, int[] multipliers, int left, int right, int op)
        {
            if (op == multipliers.Length) return 0;

            int l = nums[left] * multipliers[op] + Helper(nums, multipliers, left + 1, right, op + 1);
            int r = nums[right] * multipliers[op] + Helper(nums, multipliers, left, right - 1, op + 1);

            return Math.Max(l, r);
        }

        // Top-Down DP
        private static int RftMaximumScoreFromPerformingMultiplicationOperations1(int[] nums, int[] multipliers)
        {
            int[][] memo = new int[multipliers.Length + 1][];
            for (int i = 0; i < multipliers.Length + 1; i++)
            {
                memo[i] = new int[multipliers.Length + 1];
            }

            return Dp(memo, nums, multipliers, 0, 0);
        }

        private static int Dp(int[][] memo, int[] nums, int[] multipliers, int op, int left)
        {
            int n = nums.Length;
            if (op == multipliers.Length) return 0;

            int l = nums[left] * multipliers[op] + Dp(memo, nums, multipliers, op + 1, left + 1);
            int r = nums[n - 1 - (op - left)] * multipliers[op] + Dp(memo, nums, multipliers, op + 1, left);

            return memo[op][left] = Math.Max(l, r);
        }

        // Bottom-Up DP
        private static int RftMaximumScoreFromPerformingMultiplicationOperations2(int[] nums, int[] multipliers)
        {
            int n = nums.Length;
            int m = multipliers.Length;
            int[][] dp = new int[m + 1][];
            for (int i = 0; i < m + 1; i++)
            {
                dp[i] = new int[m + 1];
            }

            for (int i = 0; i <= m; i++)
            {
                Array.Fill(dp[i], 0);
            }

            for (int op = m - 1; op >= 0; op--)
            {
                for (int left = op; left >= 0; left--)
                {
                    dp[op][left] = Math.Max(
                        multipliers[op] * nums[left] + dp[op + 1][left + 1],
                        multipliers[op] * nums[n - 1 - (op - left)] + dp[op + 1][left]
                        );
                }
            }

            return dp[0][0];
        }

        // Space optimized DP
        private static int RftMaximumScoreFromPerformingMultiplicationOperations3(int[] nums, int[] multipliers)
        {
            int n = nums.Length;
            int m = multipliers.Length;
            int[] dp = new int[m + 1];

            for (int op = m - 1; op >= 0; op--)
            {
                for (int left = 0; left <= op; left++)
                {
                    dp[left] = Math.Max(
                        multipliers[op] * nums[left] + dp[left + 1],
                        multipliers[op] * nums[n - 1 - (op - left)] + dp[left]
                        );
                }
            }

            return dp[0];
        }
    }
}
