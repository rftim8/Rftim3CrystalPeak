namespace Rftim3LeetCode.Temp
{
    public class _02287_RearrangeCharactersToMakeTargetString
    {
        /// <summary>
        /// You are given two 0-indexed strings s and target. 
        /// You can take some letters from s and rearrange them to form new strings.
        /// Return the maximum number of copies of target that can be formed by taking letters from s and rearranging them.
        /// </summary>
        public _02287_RearrangeCharactersToMakeTargetString()
        {
            Console.WriteLine(RearrangeCharactersToMakeTargetString0("ilovecodingonleetcode", "code"));
            Console.WriteLine(RearrangeCharactersToMakeTargetString0("abcba", "abc"));
            Console.WriteLine(RearrangeCharactersToMakeTargetString0("abbaccaddaeea", "aaaaa"));
        }

        public static int RearrangeCharactersToMakeTargetString0(string a0, string a1) => RftRearrangeCharactersToMakeTargetString0(a0, a1);

        private static int RftRearrangeCharactersToMakeTargetString0(string s, string target)
        {
            int n = s.Length;
            int m = target.Length;

            Dictionary<char, int> l = [];
            for (int i = 0; i < n; i++)
            {
                if (target.Contains(s[i]))
                {
                    if (l.TryGetValue(s[i], out int value)) l[s[i]] = ++value;
                    else l[s[i]] = 1;
                }
            }

            Dictionary<char, int> r = [];
            for (int i = 0; i < m; i++)
            {
                if (!l.ContainsKey(target[i])) return 0;
                if (r.TryGetValue(target[i], out int value)) r[target[i]] = ++value;
                else r[target[i]] = 1;
            }

            List<int> x = [];
            foreach (KeyValuePair<char, int> item in l.ToList())
            {
                x.Add(item.Value / r[item.Key]);
            }

            return x.Min();
        }
    }
}