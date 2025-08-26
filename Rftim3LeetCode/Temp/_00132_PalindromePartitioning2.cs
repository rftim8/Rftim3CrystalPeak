namespace Rftim3LeetCode.Temp
{
    public class _00132_PalindromePartitioning2
    {
        /// <summary>
        /// Given a string s, partition s such that every substring of the partition is a palindrome.
        /// Return the minimum cuts needed for a palindrome partitioning of s.
        /// </summary>
        public _00132_PalindromePartitioning2()
        {
            Console.WriteLine(MinCut("aab"));
            Console.WriteLine(MinCut("a"));
            Console.WriteLine(MinCut("ab"));
        }

        private static int MinCut(string s)
        {
            int n = s.Length;
            if (n <= 1) return 0;

            bool[,] b = new bool[n, n];
            int[] r = new int[n + 1];
            r[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                r[i] = i;
                for (int j = 1; j <= i; j++)
                {
                    if (s[i - 1] == s[j - 1] && (i - j <= 1 || b[j, i - 2]))
                    {
                        b[j - 1, i - 1] = true;
                        r[i] = Math.Min(r[i], r[j - 1] + 1);
                    }
                }
            }

            return r.Last() - 1;
        }
    }
}
