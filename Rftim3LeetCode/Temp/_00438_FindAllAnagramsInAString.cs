using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00438_FindAllAnagramsInAString
    {
        /// <summary>
        /// Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.
        /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
        /// </summary>
        public _00438_FindAllAnagramsInAString()
        {
            IList<int> x = FindAnagrams1("cbaebabacd", "abc");

            RftTerminal.RftReadResult(x);
        }

        private static IList<int> FindAnagrams(string s, string p)
        {
            var c = p.GroupBy(o => o).Select(o => new { o.Key, total = o.Count() });
            c = c.OrderBy(o => o.Key).ToList();

            List<int> x = [];
            int pl = p.Length;
            int sl = s.Length;
            int a = sl - (pl - 1);

            if (p.Length > s.Length) return x;

            for (int i = 0; i < a; i++)
            {
                string y = s[..pl];
                if (y == p) x.Add(i);
                else
                {
                    var b = y.GroupBy(o => o).Select(o => new { o.Key, total = o.Count() });
                    b = [.. b.OrderBy(o => o.Key)];

                    if (b.SequenceEqual(c)) x.Add(i);
                }
                s = s[1..];
            }

            return x;
        }

        private static IList<int> FindAnagrams1(string s, string p)
        {
            List<int> x = [];
            int sl = s.Length;
            int pl = p.Length;
            int a = sl - pl;

            if (pl > sl) return x;

            string alpha = "abcdefghijklmnopqrstuvwxyz";

            int[] c = new int[26];
            foreach (char item in p)
            {
                c[alpha.IndexOf(item)]++;
            }

            int[] b = new int[26];
            for (int j = 0; j < pl; j++)
            {
                b[alpha.IndexOf(s[j])]++;
            }

            for (int i = 0; i <= a; i++)
            {
                if (b.SequenceEqual(c)) x.Add(i);
                b[alpha.IndexOf(s[0])]--;
                if (i < a) b[alpha.IndexOf(s[pl])]++;
                s = s[1..];
            }

            return x;
        }

        private static IList<int> FindAnagramsArray(string s, string p)
        {
            int[] sArray = new int[26];
            int[] pArray = new int[26];
            List<int> output = [];

            for (int i = 0; i < p.Length; ++i)
            {
                ++pArray[p[i] - 'a'];
            }

            for (int i = 0; i < s.Length; ++i)
            {
                ++sArray[s[i] - 'a'];
                if (i >= p.Length - 1)
                {
                    if (CompareArrays(sArray, pArray)) output.Add(i - p.Length + 1);

                    --sArray[s[i - p.Length + 1] - 'a'];
                }
            }

            return output;
        }

        private static bool CompareArrays(int[] s, int[] p)
        {
            return s.SequenceEqual(p);
        }
    }
}
