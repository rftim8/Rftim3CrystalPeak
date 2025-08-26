namespace Rftim3LeetCode.Temp
{
    public class _01143_LongestCommonSubsequence
    {
        /// <summary>
        /// Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.
        /// A subsequence of a string is a new string generated from the original string with some characters(can be none) 
        /// deleted without changing the relative order of the remaining characters.
        /// For example, "ace" is a subsequence of "abcde".
        /// A common subsequence of two strings is a subsequence that is common to both strings.
        /// </summary>
        public _01143_LongestCommonSubsequence()
        {
            Console.WriteLine(LongestCommonSubsequence("abcde", "ace"));
            Console.WriteLine(LongestCommonSubsequence("abc", "abc"));
            Console.WriteLine(LongestCommonSubsequence("abc", "def"));
        }

        private static int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length, n = text2.Length;
            int[,] dp = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (text1[i - 1] == text2[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[m, n];
        }

        private static int LongestCommonSubsequence0(string text1, string text2)
        {
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];

            for (int i = 0; i < text1.Length; i++)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    int cur = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                    if (text1[i] == text2[j]) dp[i + 1, j + 1] = dp[i, j] + 1;
                    else dp[i + 1, j + 1] = cur;
                }
            }

            return dp[text1.Length, text2.Length];
        }
    }
}
