namespace Rftim3LeetCode.Temp
{
    public class _00583_DeleteOperationForTwoStrings
    {
        /// <summary>
        /// Given two strings word1 and word2, return the minimum number of steps required to make word1 and word2 the same.
        /// In one step, you can delete exactly one character in either string.
        /// </summary>
        public _00583_DeleteOperationForTwoStrings()
        {
            Console.WriteLine(MinDistance("sea", "eat"));
            Console.WriteLine(MinDistance("leetcode", "etco"));
        }

        private static int MinDistance(string word1, string word2)
        {
            int n = word1.Length;
            int m = word2.Length;
            int[] dp = new int[m + 1];

            for (int i = 0; i <= n; i++)
            {
                int[] temp = new int[m + 1];
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0 || j == 0) temp[j] = i + j;
                    else if (word1[i - 1] == word2[j - 1]) temp[j] = dp[j - 1];
                    else temp[j] = 1 + Math.Min(dp[j], temp[j - 1]);
                }
                dp = temp;
            }

            return dp[m];
        }

        private static int MinDistance0(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0) dp[i, j] = i + j;
                    else if (s1[i - 1] == s2[j - 1]) dp[i, j] = dp[i - 1, j - 1];
                    else dp[i, j] = 1 + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[s1.Length, s2.Length];
        }

        private static int MinDistance1(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0) continue;
                    if (s1[i - 1] == s2[j - 1]) dp[i, j] = 1 + dp[i - 1, j - 1];
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return s1.Length + s2.Length - 2 * dp[s1.Length, s2.Length];
        }

        private static int MinDistance2(string s1, string s2)
        {
            int[,] memo = new int[s1.Length + 1, s2.Length + 1];
            return s1.Length + s2.Length - 2 * Lcs(s1, s2, s1.Length, s2.Length, memo);
        }

        private static int Lcs(string s1, string s2, int m, int n, int[,] memo)
        {
            if (m == 0 || n == 0) return 0;
            if (memo[m, n] > 0) return memo[m, n];
            if (s1[m - 1] == s2[n - 1]) memo[m, n] = 1 + Lcs(s1, s2, m - 1, n - 1, memo);
            else memo[m, n] = Math.Max(Lcs(s1, s2, m, n - 1, memo), Lcs(s1, s2, m - 1, n, memo));

            return memo[m, n];
        }

        private static int MinDistance3(string word1, string word2)
        {
            int[] dp = new int[word2.Length + 1];

            for (int j = 0; j < word2.Length + 1; j++)
            {
                dp[j] = j;
            }

            for (int i = 0; i < word1.Length; i++)
            {
                int pre = dp[0];
                dp[0] = i + 1;

                for (int j = 0; j < word2.Length; j++)
                {
                    int temp = dp[j + 1];
                    if (word1[i] == word2[j]) dp[j + 1] = pre;
                    else dp[j + 1] = Math.Min(dp[j], dp[j + 1]) + 1;

                    pre = temp;
                }
            }

            return dp[word2.Length];
        }
    }
}
