namespace Rftim3LeetCode.Temp
{
    public class _02707_ExtraCharactersInAString
    {
        /// <summary>
        /// You are given a 0-indexed string s and a dictionary of words dictionary. 
        /// You have to break s into one or more non-overlapping substrings such that each substring is present in dictionary. 
        /// There may be some extra characters in s which are not present in any of the substrings.
        /// Return the minimum number of extra characters left over if you break up s optimally.
        /// </summary>
        public _02707_ExtraCharactersInAString()
        {
            Console.WriteLine(MinExtraChar(
                "leetsacode",
                ["leet", "code", "leetcode"]
            ));
            Console.WriteLine(MinExtraChar(
                "sayhelloworld",
                ["hello", "world"]
            ));
            Console.WriteLine(MinExtraChar(
                "dwmodizxvvbosxxw",
                ["ox", "lb", "diz", "gu", "v", "ksv", "o", "nuq", "r", "txhe", "e", "wmo", "cehy", "tskz", "ds", "kzbu"]
            ));
            Console.WriteLine(MinExtraChar(
                "kevlplxozaizdhxoimmraiakbak",
                ["yv", "bmab", "hv", "bnsll", "mra", "jjqf", "g", "aiyzi", "ip", "pfctr", "flr", "ybbcl", "biu", "ke", "lpl", "iak", "pirua", "ilhqd", "zdhx", "fux", "xaw", "pdfvt", "xf", "t", "wq", "r", "cgmud", "aokas", "xv", "jf", "cyys", "wcaz", "rvegf", "ysg", "xo", "uwb", "lw", "okgk", "vbmi", "v", "mvo", "fxyx", "ad", "e"]
            ));
            Console.WriteLine(MinExtraChar(
                "eglglxa",
                ["rs", "j", "h", "g", "fy", "l", "fc", "s", "zf", "i", "k", "x", "gl", "qr", "qj", "b", "m", "cm", "pe", "y", "ei", "wg", "e", "c", "ll", "u", "lb", "kc", "r", "gs", "p", "ga", "pq", "o", "wq", "mp", "ms", "vp", "kg", "cu"]
            ));
            Console.WriteLine(MinExtraChar(
                "jhuc",
                ["ns", "d", "y", "ru", "q", "z", "jh"]
            ));
            Console.WriteLine(MinExtraChar(
                "zl",
                ["r", "a", "x", "f", "c", "l", "k", "v", "i", "u", "p", "d", "o", "h", "q", "j", "s", "g", "e", "b", "m", "y", "n", "w"]
            ));
            Console.WriteLine(MinExtraChar(
                "nbxhpyyawmcsnuycfvoxhmxjclqadablucgikep",
                ["yaw", "nbxhpy", "arpqfg", "bluc", "thxpp", "ox", "a", "zdaru", "kmd", "flckz", "hnnn", "dldal", "yqssxn", "ycf", "lctpj", "hmxjc", "dv", "cs", "sxt", "am", "irfij", "dbtg", "cjnybn", "ab", "dngs", "azbq", "qa", "mrx", "mljbq", "hphmy", "b", "hu", "s", "g"]
            ));
        }

        private static int MinExtraChar(string s, string[] dictionary)
        {
            int n = s.Length;
            int[] r = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                r[i] = r[i - 1] + 1;
                foreach (string item in dictionary)
                {
                    if (i >= item.Length && s.Substring(i - item.Length, item.Length).Equals(item)) r[i] = Math.Min(r[i], r[i - item.Length]);
                }
            }

            return r[n];
        }

        private static int MinExtraChar0(string s, string[] dictionary)
        {
            int n = s.Length;
            int[] r = new int[n + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                r[i] = r[i + 1] + 1;
                for (int j = i; j < n; j++)
                {
                    string c = s[i..(j + 1)];
                    if (dictionary.Contains(c)) r[i] = Math.Min(r[i], r[j + 1]);
                }
            }

            return r[0];
        }
    }
}
