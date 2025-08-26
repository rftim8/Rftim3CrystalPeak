namespace Rftim3LeetCode.Temp
{
    public class _01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisons
    {
        /// <summary>
        /// You are given three integers n, m and k. Consider the following algorithm to find the maximum element of an array of positive integers:
        /// You should build the array arr which has the following properties:
        /// arr has exactly n integers.
        /// 1 <= arr[i] <= m where(0 <= i<n).
        /// After applying the mentioned algorithm to arr, the value search_cost is equal to k.
        /// Return the number of ways to build the array arr under the mentioned conditions.
        /// As the answer may grow large, the answer must be computed modulo 109 + 7.
        /// </summary>
        public _01420_BuildArrayWhereYouCanFindTheMaximumExactlyKComparisons()
        {
            Console.WriteLine(NumOfArrays(2, 3, 1));
            Console.WriteLine(NumOfArrays(5, 2, 3));
            Console.WriteLine(NumOfArrays(9, 1, 1));
        }

        // Bottom-Up DP
        private static int NumOfArrays(int n, int m, int k)
        {
            int[][][] dp = new int[n + 1][][];
            int MOD = (int)1e9 + 7;

            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[m + 1][];
                for (int j = 0; j < m + 1; j++)
                {
                    dp[i][j] = new int[k + 1];
                }
            }

            for (int num = 0; num < dp[0].Length; num++)
            {
                dp[n][num][0] = 1;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int maxSoFar = m; maxSoFar >= 0; maxSoFar--)
                {
                    for (int remain = 0; remain <= k; remain++)
                    {
                        int ans = 0;
                        for (int num = 1; num <= maxSoFar; num++)
                        {
                            ans = (ans + dp[i + 1][maxSoFar][remain]) % MOD;
                        }

                        if (remain > 0)
                        {
                            for (int num = maxSoFar + 1; num <= m; num++)
                            {
                                ans = (ans + dp[i + 1][num][remain - 1]) % MOD;
                            }
                        }

                        dp[i][maxSoFar][remain] = ans;
                    }
                }
            }

            return dp[0][0][k];
        }

        // Top-Down DP
        private static int[][][]? memo;
        private static readonly int MOD = (int)1e9 + 7;
        private static int o;
        private static int p;

        private static int NumOfArrays0(int n, int m, int k)
        {
            memo = new int[n][][];
            for (int i = 0; i < n; i++)
            {
                memo[i] = new int[m + 1][];
                for (int j = 0; j < m + 1; j++)
                {
                    memo[i][j] = new int[k + 1];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    Array.Fill(memo[i][j], -1);
                }
            }

            o = n;
            p = m;

            return Dp(0, 0, k);
        }

        private static int Dp(int i, int maxSoFar, int remain)
        {
            if (i == o)
            {
                if (remain == 0) return 1;

                return 0;
            }

            if (remain < 0) return 0;

            if (memo![i][maxSoFar][remain] != -1) return memo[i][maxSoFar][remain];

            int ans = 0;
            for (int num = 1; num <= maxSoFar; num++)
            {
                ans = (ans + Dp(i + 1, maxSoFar, remain)) % MOD;
            }

            for (int num = maxSoFar + 1; num <= p; num++)
            {
                ans = (ans + Dp(i + 1, num, remain - 1)) % MOD;
            }

            memo[i][maxSoFar][remain] = ans;

            return ans;
        }
    }
}
