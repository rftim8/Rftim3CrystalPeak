namespace Rftim3LeetCode.Temp
{
    public class _00115_DistinctSubsequences
    {
        /// <summary>
        /// Given two strings s and t, return the number of distinct subsequences of s which equals t.
        /// The test cases are generated so that the answer fits on a 32-bit signed integer.
        /// </summary>
        public _00115_DistinctSubsequences()
        {
            Console.WriteLine(NumDistinct("rabbbit", "rabbit"));
            Console.WriteLine(NumDistinct("babgbag", "bag"));
        }

        private static int NumDistinct(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            if (n < m) return 0;

            int[,] r = new int[m + 1, n + 1];

            for (int i = 0; i <= n; i++)
            {
                r[0, i] = 1;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s[j - 1] != t[i - 1]) r[i, j] = r[i, j - 1];
                    else r[i, j] = r[i - 1, j - 1] + r[i, j - 1];
                }
            }

            return r[m, n];
        }

        private static int NumDistinct0(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] dp = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 1;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1]) dp[i, j] = dp[i - 1, j] + dp[i - 1, j - 1];
                    else dp[i, j] = dp[i - 1, j];
                }
            }

            return dp[n, m];
        }
    }
}
