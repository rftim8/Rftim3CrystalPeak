namespace Rftim3LeetCode.Temp
{
    public class _01312_MinimumInsertionStepsToMakeAStringPalindrome
    {
        /// <summary>
        /// Given a string s. In one step you can insert any character at any index of the string.
        /// Return the minimum number of steps to make s palindrome.
        /// A Palindrome String is one that reads the same backward as well as forward.
        /// </summary>
        public _01312_MinimumInsertionStepsToMakeAStringPalindrome()
        {
            Console.WriteLine(MinInsertions("zzazz"));
            Console.WriteLine(MinInsertions("mbadm"));
            Console.WriteLine(MinInsertions("leetcode"));
        }

        private static int MinInsertions(string s)
        {
            int n = s.Length;
            string sReverse = string.Join("", s.ToCharArray().Reverse());
            int[,] memo = new int[n + 1, n + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    memo[i, j] = -1;
                }
            }

            return n - Lcs(s, sReverse, n, n, memo);
        }

        private static int Lcs(string s1, string s2, int m, int n, int[,] memo)
        {
            if (m == 0 || n == 0) return 0;
            if (memo[m, n] != -1) return memo[m, n];
            if (s1[m - 1] == s2[n - 1]) return memo[m, n] = 1 + Lcs(s1, s2, m - 1, n - 1, memo);

            return memo[m, n] = Math.Max(Lcs(s1, s2, m - 1, n, memo), Lcs(s1, s2, m, n - 1, memo));
        }

        private static int MinInsertions0(string s)
        {
            int n = s.Length;
            string sReverse = string.Join("", s.ToCharArray().Reverse());

            return n - Lcs0(s, sReverse, n, n);
        }

        private static int Lcs0(string s1, string s2, int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0) dp[i, j] = 0;
                    else if (s1[i - 1] == s2[j - 1]) dp[i, j] = 1 + dp[i - 1, j - 1];
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[m, n];
        }

        private static int MinInsertions1(string s)
        {
            int n = s.Length;
            string sReverse = string.Join("", s.ToCharArray().Reverse());

            return n - Lcs1(s, sReverse, n, n);
        }

        private static int Lcs1(string s1, string s2, int m, int n)
        {
            int[] dp = new int[n + 1];
            int[] dpPrev = new int[n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[j] = 0;
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        dp[j] = 1 + dpPrev[j - 1];
                    }
                    else
                    {
                        dp[j] = Math.Max(dpPrev[j], dp[j - 1]);
                    }
                }
                Array.Copy(dp, dpPrev, n + 1);
            }

            return dp[n];
        }

        private static int MinInsertions2(string s)
        {
            string s1 = string.Join("", s.ToCharArray().Reverse());
            int n = s1.Length;
            int[,] dp = new int[n + 1, n + 1];

            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 0;
                dp[0, i] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s[i - 1] == s1[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return n - dp[n, n];
        }
    }
}
