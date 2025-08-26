namespace Rftim3LeetCode.Temp
{
    public class _00486_PredictTheWinner
    {
        /// <summary>
        /// You are given an integer array nums. Two players are playing a game with this array: player 1 and player 2.
        /// Player 1 and player 2 take turns, with player 1 starting first.
        /// Both players start the game with a score of 0. 
        /// At each turn, the player takes one of the numbers from either end of the array (i.e., nums[0] or nums[nums.length - 1]) which reduces the size of the array by 1. 
        /// The player adds the chosen number to their score.The game ends when there are no more elements in the array.
        /// Return true if Player 1 can win the game. 
        /// If the scores of both players are equal, then player 1 is still the winner, and you should also return true. 
        /// You may assume that both players are playing optimally.
        /// </summary>

        // Recursion
        private static bool PredictTheWinner(int[] nums)
        {
            int n = nums.Length;

            return MaxDiff(nums, 0, n - 1, n) >= 0;
        }

        private static int MaxDiff(int[] nums, int left, int right, int n)
        {
            if (left == right) return nums[left];

            int scoreByLeft = nums[left] - MaxDiff(nums, left + 1, right, n);
            int scoreByRight = nums[right] - MaxDiff(nums, left, right - 1, n);

            return Math.Max(scoreByLeft, scoreByRight);
        }

        // Top-Down DP
        private static int[][]? memo;

        private static bool PredictTheWinner1(int[] nums)
        {
            int n = nums.Length;
            memo = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                memo[i] = new int[n];
                Array.Fill(memo[i], -1);
            }

            return MaxDiff1(nums, 0, n - 1, n) >= 0;
        }

        private static int MaxDiff1(int[] nums, int left, int right, int n)
        {
            if (memo?[left][right] != -1) return memo![left][right];
            if (left == right) return nums[left];

            int scoreByLeft = nums[left] - MaxDiff1(nums, left + 1, right, n);
            int scoreByRight = nums[right] - MaxDiff1(nums, left, right - 1, n);
            memo[left][right] = Math.Max(scoreByLeft, scoreByRight);

            return memo[left][right];
        }

        // Bottom-Up DP
        private static bool PredictTheWinner2(int[] nums)
        {
            int n = nums.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                dp[i] = new int[n];
                dp[i][i] = nums[i];
            }

            for (int diff = 1; diff < n; ++diff)
            {
                for (int left = 0; left < n - diff; ++left)
                {
                    int right = left + diff;
                    dp[left][right] = Math.Max(nums[left] - dp[left + 1][right], nums[right] - dp[left][right - 1]);
                }
            }

            return dp[0][n - 1] >= 0;
        }

        // Space-Optimized DP
        private static bool PredictTheWinner3(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n];
            Array.Copy(nums, dp, n);

            for (int diff = 1; diff < n; ++diff)
            {
                for (int left = 0; left < n - diff; ++left)
                {
                    int right = left + diff;
                    dp[left] = Math.Max(nums[left] - dp[left + 1], nums[right] - dp[left]);
                }
            }

            return dp[0] >= 0;
        }
    }
}
