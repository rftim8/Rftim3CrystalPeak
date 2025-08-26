namespace Rftim3LeetCode.Temp
{
    public class _01639_NumberOfWaysToFormATargetStringGivenADictionary
    {
        /// <summary>
        /// You are given a list of strings of the same length words and a string target.
        /// Your task is to form target using the given words under the following rules:
        /// target should be formed from left to right.
        /// To form the ith character (0-indexed) of target, you can choose the kth character of the jth string in words if target[i] = words[j][k].
        /// Once you use the kth character of the jth string of words, you can no longer use the xth character of any string in words where x <= k.
        /// In other words, all characters to the left of or at index k become unusuable for every string.
        /// Repeat the process until you form the string target.
        /// Notice that you can use multiple characters from the same string in words provided the conditions above are met.
        /// Return the number of ways to form target from words. Since the answer may be too large, return it modulo 109 + 7.
        /// </summary>
        public _01639_NumberOfWaysToFormATargetStringGivenADictionary()
        {
            Console.WriteLine(NumWays(["acca", "bbbb", "caca"], "aba")); // 6
            Console.WriteLine(NumWays(["abba", "baab"], "bab")); // 4
        }

        private static int NumWays(string[] words, string target)
        {
            int n = words.Length;
            int m = words[0].Length;
            int l = target.Length;
            int mod = 1000000007;
            int alphabet = 26;
            int[,] cnt = new int[alphabet, m];

            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    cnt[words[i][j] - 'a', j]++;
                }
            }

            long[,] dp = new long[l + 1, m + 1];
            dp[0, 0] = 1;

            for (int i = 0; i <= l; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i < l)
                    {
                        dp[i + 1, j + 1] += cnt[target[i] - 'a', j] * dp[i, j];
                        dp[i + 1, j + 1] %= mod;
                    }
                    dp[i, j + 1] += dp[i, j];
                    dp[i, j + 1] %= mod;
                }
            }

            return (int)dp[l, m];
        }

        private static int NumWays0(string[] words, string target)
        {
            const long mod = 1_000_000_007;

            int m = target.Length;
            int n = words[0].Length;

            if (m > n) return 0;

            long[,] count = new long[26, n];

            foreach (string word in words)
            {
                for (int j = 0; j < n; j++)
                {
                    count[word[j] - 'a', j]++;
                }
            }

            long[,] dp = new long[m, n];

            dp[0, 0] = count[target[0] - 'a', 0];
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = (dp[0, j - 1] + count[target[0] - 'a', j]) % mod;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = i; j < n; j++)
                {
                    dp[i, j] = (dp[i, j - 1] + count[target[i] - 'a', j] * dp[i - 1, j - 1]) % mod;
                }
            }

            return (int)dp[m - 1, n - 1];
        }
    }
}
