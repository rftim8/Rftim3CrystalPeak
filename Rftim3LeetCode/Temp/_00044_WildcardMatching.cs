namespace Rftim3LeetCode.Temp
{
    public class _00044_WildcardMatching
    {
        /// <summary>
        /// Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:
        /// '?' Matches any single character.
        /// '*' Matches any sequence of characters (including the empty sequence).
        /// The matching should cover the entire input string (not partial).
        /// </summary>
        public _00044_WildcardMatching()
        {
            Console.WriteLine(WildcardMatching0("aa", "a"));
            Console.WriteLine(WildcardMatching0("aa", "*"));
            Console.WriteLine(WildcardMatching0("cb", "?a"));
        }

        public static bool WildcardMatching0(string a0, string a1) => RftWildcardMatching0(a0, a1);

        private static bool RftWildcardMatching0(string s, string p)
        {
            int n = s.Length;
            int m = p.Length;
            Dictionary<(int, char), int> r = [];
            int t = 0;

            for (int i = 0; i < m; i++)
            {
                if (p[i] == '*') r.TryAdd((t, '*'), t);
                else r.TryAdd((t, p[i]), ++t);
            }

            HashSet<int> h = [0];
            int j = 0;
            while (j < n)
            {
                HashSet<int> hs = [];
                foreach (int item in h)
                {
                    if (r.TryGetValue((item, s[j]), out int c)) hs.Add(c);
                    if (r.TryGetValue((item, '*'), out c)) hs.Add(c);
                    if (r.TryGetValue((item, '?'), out c)) hs.Add(c);
                }

                j++;
                h = hs;
            }

            return h.Contains(t);
        }

        private static bool WildcardMatching1(string s, string p)
        {
            int n = s.Length, m = p.Length;
            int i = 0, j = 0;
            int star = -1;
            int o = -1;

            while (i < n)
            {
                if (j < m && (p[j] == '?' || p[j] == s[i]))
                {
                    i++;
                    j++;

                    continue;
                }

                if (j < m && p[j] == '*')
                {
                    star = j++;
                    o = i;

                    continue;
                }

                if (star >= 0)
                {
                    j = star + 1;
                    i = ++o;

                    continue;
                }

                return false;
            }

            while (j < m && p[j] == '*')
            {
                j++;
            }

            return j == m;
        }
    }
}
