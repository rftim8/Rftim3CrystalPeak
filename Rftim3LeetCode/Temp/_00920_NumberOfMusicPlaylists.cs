namespace Rftim3LeetCode.Temp
{
    public class _00920_NumberOfMusicPlaylists
    {
        /// <summary>
        /// Your music player contains n different songs. You want to listen to goal songs (not necessarily different) during your trip. 
        /// To avoid boredom, you will create a playlist so that:
        /// Every song is played at least once.
        /// A song can only be played again only if k other songs have been played.
        /// Given n, goal, and k, return the number of possible playlists that you can create.
        /// Since the answer can be very large, return it modulo 109 + 7.
        /// </summary>

        // Bottom-Up DP
        private static int NumMusicPlaylists(int n, int goal, int k)
        {
            int MOD = 1_000_000_007;

            long[][] dp = new long[goal + 1][];
            for (int i = 0; i < goal + 1; i++)
            {
                dp[i] = new long[n + 1];
            }

            dp[0][0] = 1;

            for (int i = 1; i <= goal; i++)
            {
                for (int j = 1; j <= Math.Min(i, n); j++)
                {
                    dp[i][j] = dp[i - 1][j - 1] * (n - j + 1) % MOD;
                    if (j > k) dp[i][j] = (dp[i][j] + dp[i - 1][j] * (j - k)) % MOD;
                }
            }

            return (int)dp[goal][n];
        }

        // Top-Down DP Memoization
        private static readonly int MOD0 = 1_000_000_007;
        private static long[][]? dp;

        private static int NumMusicPlaylists0(int n, int goal, int k)
        {
            dp = new long[goal + 1][];
            for (int i = 0; i < goal + 1; i++)
            {
                dp[i] = new long[n + 1];
                Array.Fill(dp[i], -1L);
            }

            return (int)NumberOfPlaylists0(goal, n, k, n);
        }

        private static long NumberOfPlaylists0(int i, int j, int k, int n)
        {
            if (i == 0 && j == 0) return 1;
            if (i == 0 || j == 0) return 0;
            if (dp![i][j] != -1) return dp[i][j];

            dp[i][j] = NumberOfPlaylists0(i - 1, j - 1, k, n) * (n - j + 1) % MOD0;
            if (j > k)
            {
                dp[i][j] += NumberOfPlaylists0(i - 1, j, k, n) * (j - k) % MOD0;
                dp[i][j] %= MOD0;
            }

            return dp[i][j];
        }

        // Combinatorics
        private static readonly long MOD1 = 1_000_000_007;

        private static long[]? factorial;
        private static long[]? invFactorial;

        private static int NumMusicPlaylists1(int n, int goal, int k)
        {
            PrecalculateFactorials1(n);

            int sign = 1;
            long answer = 0;

            for (int i = n; i >= k; i--)
            {
                long temp = Power1(i - k, goal - k);
                temp = temp * invFactorial![n - i] % MOD1;
                temp = temp * invFactorial[i - k] % MOD1;

                answer = (answer + sign * temp + MOD1) % MOD1;

                sign *= -1;
            }

            return (int)(factorial![n] * answer % MOD1);
        }

        private static void PrecalculateFactorials1(int n)
        {
            factorial = new long[n + 1];
            invFactorial = new long[n + 1];
            factorial[0] = invFactorial[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial[i] = factorial[i - 1] * i % MOD1;
                invFactorial[i] = Power1(factorial[i], (int)(MOD1 - 2));
            }
        }

        private static long Power1(long base1, int exponent)
        {
            long result = 1L;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1) result = result * base1 % MOD1;
                exponent >>= 1;
                base1 = base1 * base1 % MOD1;
            }

            return result;
        }
    }
}
