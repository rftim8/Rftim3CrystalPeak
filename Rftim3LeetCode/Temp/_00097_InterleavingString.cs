namespace Rftim3LeetCode.Temp
{
    public class _00097_InterleavingString
    {
        /// <summary>
        /// Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.
        /// An interleaving of two strings s and t is a configuration where s and t are divided into n and m
        /// substrings
        ///  respectively, such that:
        /// s = s1 + s2 + ... + sn
        /// t = t1 + t2 + ... + tm
        /// |n - m| <= 1
        /// The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...
        /// Note: a + b is the concatenation of strings a and b.
        /// </summary>
        public _00097_InterleavingString()
        {
            Console.WriteLine(IsInterleave("aabcc", "dbbca", "aadbbcbcac"));
            Console.WriteLine(IsInterleave("aabcc", "dbbca", "aadbbbaccc"));
            Console.WriteLine(IsInterleave("", "", ""));
        }

        private static bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            int n = s1.Length, m = s2.Length;
            bool[,] x = new bool[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0 && j == 0) x[i, j] = true;
                    else if (i == 0) x[i, j] = x[i, j - 1] && s2[j - 1] == s3[i + j - 1];
                    else if (j == 0) x[i, j] = x[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                    else x[i, j] = x[i, j - 1] && s2[j - 1] == s3[i + j - 1] || x[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                }
            }

            return x[n, m];
        }

        private static bool IsInterleave0(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            bool[,] DP = new bool[s1.Length + 1, s2.Length + 1];

            DP[s1.Length, s2.Length] = true;

            for (int i = s1.Length; i >= 0; i--)
            {
                for (int j = s2.Length; j >= 0; j--)
                {
                    if (i < s1.Length && s1[i] == s3[i + j] && DP[i + 1, j]) DP[i, j] = true;

                    if (j < s2.Length && s2[j] == s3[i + j] && DP[i, j + 1]) DP[i, j] = true;
                }
            }

            return DP[0, 0];
        }
    }
}
