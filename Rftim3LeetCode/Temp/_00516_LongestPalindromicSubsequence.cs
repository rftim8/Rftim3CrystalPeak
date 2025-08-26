namespace Rftim3LeetCode.Temp
{
    public class _00516_LongestPalindromicSubsequence
    {
        /// <summary>
        /// Given a string s, find the longest palindromic subsequence's length in s.
        /// A subsequence is a sequence that can be derived from another sequence by deleting some or no elements without changing the order of the remaining elements.
        /// </summary>
        public _00516_LongestPalindromicSubsequence()
        {
            Console.WriteLine(LongestPalindromeSubseq("bbbab"));
            Console.WriteLine(LongestPalindromeSubseq("cbbd"));
        }

        private static int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[][] x = new int[n][];

            for (int i = 0; i < n; i++)
            {
                x[i] = new int[n];
            }

            for (int i = n - 1; i > -1; i--)
            {
                x[i][i] = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (s[i] == s[j]) x[i][j] = x[i + 1][j - 1] + 2;
                    else x[i][j] = Math.Max(x[i + 1][j], x[i][j - 1]);
                }
            }

            return x[0][n - 1];
        }
    }
}
