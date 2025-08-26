namespace Rftim3LeetCode.Temp
{
    public class _00791_CustomSortString
    {
        /// <summary>
        /// You are given two strings order and s. 
        /// All the characters of order are unique and were sorted in some custom order previously.
        /// 
        /// Permute the characters of s so that they match the order that order was sorted.
        /// More specifically, if a character x occurs before a character y in order, then x should occur before y in the permuted string.
        /// 
        /// Return any permutation of s that satisfies this property.
        /// </summary>
        public _00791_CustomSortString()
        {
            Console.WriteLine(CustomSortString1("cba", "abcd"));
            Console.WriteLine(CustomSortString1("bcafg", "abcd"));
        }

        public static string CustomSortString0(string a0, string a1) => RftCustomSortString0(a0, a1);

        public static string CustomSortString1(string a0, string a1) => RftCustomSortString1(a0, a1);

        private static string RftCustomSortString0(string order, string s)
        {
            int n = s.Length;
            string res = "";

            Dictionary<char, int> kvp = [];
            for (int i = 0; i < n; i++)
            {
                if (kvp.TryGetValue(s[i], out int value)) kvp[s[i]] = ++value;
                else kvp[s[i]] = 1;
            }

            foreach (char item in order)
            {
                if (kvp.TryGetValue(item, out int value))
                {
                    for (int i = 0; i < value; i++)
                    {
                        res += item;
                    }
                    kvp.Remove(item);
                }
            }

            foreach (KeyValuePair<char, int> item in kvp)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    res += item.Key;
                }
            }

            return res;
        }

        private static string RftCustomSortString1(string order, string s)
        {
            int[] precedence = new int[26];
            for (int i = 0; i < order.Length; i++)
            {
                precedence[order[i] - 'a'] = i;
            }

            char[] arr = s.ToCharArray();
            Array.Sort(arr, (a, b) => precedence[a - 'a'].CompareTo(precedence[b - 'a']));

            return new string(arr);
        }
    }
}

