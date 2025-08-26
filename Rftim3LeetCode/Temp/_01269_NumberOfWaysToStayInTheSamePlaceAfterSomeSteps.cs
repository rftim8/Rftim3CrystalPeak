namespace Rftim3LeetCode.Temp
{
    public class _01269_NumberOfWaysToStayInTheSamePlaceAfterSomeSteps
    {
        /// <summary>
        /// You have a pointer at index 0 in an array of size arrLen. 
        /// At each step, you can move 1 position to the left, 1 position to the right in the array, 
        /// or stay in the same place (The pointer should not be placed outside the array at any time).
        /// Given two integers steps and arrLen, return the number of ways such that your pointer is still 
        /// at index 0 after exactly steps steps.
        /// Since the answer may be too large, return it modulo 109 + 7.
        /// </summary>
        public _01269_NumberOfWaysToStayInTheSamePlaceAfterSomeSteps()
        {
            Console.WriteLine(NumWays(3, 2));
            Console.WriteLine(NumWays(2, 4));
            Console.WriteLine(NumWays(4, 2));
        }

        // Bottom-Up DP
        private static int NumWays(int steps, int arrLen)
        {
            int MOD = (int)1e9 + 7;
            arrLen = Math.Min(arrLen, steps);
            int[][] dp = new int[arrLen][];
            for (int i = 0; i < arrLen; i++)
            {
                dp[i] = new int[steps + 1];
            }

            dp[0][0] = 1;

            for (int remain = 1; remain <= steps; remain++)
            {
                for (int curr = arrLen - 1; curr >= 0; curr--)
                {
                    int ans = dp[curr][remain - 1];

                    if (curr > 0) ans = (ans + dp[curr - 1][remain - 1]) % MOD;

                    if (curr < arrLen - 1) ans = (ans + dp[curr + 1][remain - 1]) % MOD;

                    dp[curr][remain] = ans;
                }
            }

            return dp[0][steps];
        }

        // Bottom-Up DP space optimized
        private static int NumWays0(int steps, int arrLen)
        {
            int MOD = (int)1e9 + 7;
            arrLen = Math.Min(arrLen, steps);
            int[] dp = new int[arrLen];
            int[] prevDp = new int[arrLen];
            prevDp[0] = 1;

            for (int remain = 1; remain <= steps; remain++)
            {
                dp = new int[arrLen];

                for (int curr = arrLen - 1; curr >= 0; curr--)
                {
                    int ans = prevDp[curr];
                    if (curr > 0) ans = (ans + prevDp[curr - 1]) % MOD;

                    if (curr < arrLen - 1) ans = (ans + prevDp[curr + 1]) % MOD;

                    dp[curr] = ans;
                }

                prevDp = dp;
            }

            return dp[0];
        }

        // Top-Down DP
        private static int[][]? memo;
        private static readonly int MOD = (int)1e9 + 7;
        private static int arrLen;

        private static int Dp(int curr, int remain)
        {
            if (remain == 0)
            {
                if (curr == 0) return 1;

                return 0;
            }

            if (memo![curr][remain] != -1) return memo[curr][remain];

            int ans = Dp(curr, remain - 1);
            if (curr > 0) ans = (ans + Dp(curr - 1, remain - 1)) % MOD;
            if (curr < arrLen - 1) ans = (ans + Dp(curr + 1, remain - 1)) % MOD;

            memo[curr][remain] = ans;

            return ans;
        }

        private static int NumWays1(int steps, int arrLen0)
        {
            arrLen0 = Math.Min(arrLen0, steps);
            arrLen = arrLen0;
            memo = new int[arrLen0][];
            for (int i = 0; i < arrLen0; i++)
            {
                memo[i] = new int[steps + 1];
            }

            foreach (int[] row in memo)
            {
                Array.Fill(row, -1);
            }

            return Dp(0, steps);
        }
    }
}
