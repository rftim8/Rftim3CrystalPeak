namespace Rftim3LeetCode.Temp
{
    public class _00010_RegularExpressionMatching
    {
        /// <summary>
        /// Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:
        /// '.' Matches any single character.​​​​
        /// '*' Matches zero or more of the preceding element.
        /// The matching should cover the entire input string (not partial).
        /// </summary>
        public _00010_RegularExpressionMatching()
        {
            Console.WriteLine(RegularExpressionMatching0("aa", "a"));
            Console.WriteLine(RegularExpressionMatching0("aa", "a*"));
            Console.WriteLine(RegularExpressionMatching0("ab", ".*"));
        }

        public static bool RegularExpressionMatching0(string a0, string a1) => RftRegularExpressionMatching0(a0, a1);

        private static bool RftRegularExpressionMatching0(string s, string p)
        {
            int n = s.Length;
            int m = p.Length;
            bool[,] r = new bool[n + 1, m + 1];
            r[0, 0] = true;

            for (int i = 2; i <= m; i++)
            {
                r[0, i] = p[i - 1] == '*' && r[0, i - 2];
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.') r[i, j] = r[i - 1, j - 1];
                    else if (p[j - 1] == '*') r[i, j] = r[i, j - 2] || (s[i - 1] == p[j - 2] || p[j - 2] == '.') && r[i - 1, j];
                }
            }

            return r[n, m];
        }
    }
}
