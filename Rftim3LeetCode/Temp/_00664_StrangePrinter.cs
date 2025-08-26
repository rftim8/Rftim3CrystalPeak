namespace Rftim3LeetCode.Temp
{
    public class _00664_StrangePrinter
    {
        /// <summary>
        /// There is a strange printer with the following two special properties:
        /// <para>
        /// The printer can only print a sequence of the same character each time.
        /// </para>
        ///  - At each turn, the printer can print new characters starting from and ending at any place and will cover the original existing characters.
        ///  <para>
        ///  - Given a string s, return the minimum number of turns the printer needed to print it.
        ///  </para>
        /// </summary>

        private readonly int a0;
        private readonly int a1;

        private readonly int b0;
        private readonly int b1;

        // Bottom-Up DP
        private static int StrangePrinter(string s)
        {
            int n = s.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
            }

            for (int length = 1; length <= n; length++)
            {
                for (int left = 0; left <= n - length; left++)
                {
                    int right = left + length - 1;
                    int j = -1;
                    dp[left][right] = n;
                    for (int i = left; i < right; i++)
                    {
                        if (s[i] != s[right] && j == -1) j = i;
                        if (j != -1) dp[left][right] = Math.Min(dp[left][right], 1 + dp[j][i] + dp[i + 1][right]);
                    }

                    if (j == -1) dp[left][right] = 0;
                }
            }

            return dp[0][n - 1] + 1;
        }

        // Top-down DP
        private static int[][]? dp;

        private static int StrangePrinter1(string s)
        {
            int n = s.Length;
            dp = new int[n][];
            for (int left = 0; left < n; left++)
            {
                dp[left] = new int[n];
                for (int right = 0; right < n; right++)
                {
                    dp[left][right] = -1;
                }
            }

            return Solve(s, n, 0, n - 1) + 1;
        }

        private static int Solve(string s, int n, int left, int right)
        {
            if (dp![left][right] != -1) return dp[left][right];

            dp[left][right] = n;
            int j = -1;
            for (int i = left; i < right; i++)
            {
                if (s[i] != s[right] && j == -1) j = i;
                if (j != -1) dp[left][right] = Math.Min(dp[left][right], 1 + Solve(s, n, j, i) + Solve(s, n, i + 1, right));
            }

            if (j == -1) dp[left][right] = 0;

            return dp[left][right];
        }
    }
}
