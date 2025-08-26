namespace Rftim3LeetCode.Temp
{
    public class _00076_MinimumWindowSubstring
    {
        /// <summary>
        /// Given two strings s and t of lengths m and n respectively, return the minimum window substring
        ///  of s such that every character in t(including duplicates) is included in the window.If there is no such substring, return the empty string "".
        /// The testcases will be generated such that the answer is unique.
        /// </summary>
        public _00076_MinimumWindowSubstring()
        {
            Console.WriteLine(MinWindow("ADOBECODEBANC", "ABC"));
            Console.WriteLine(MinWindow("a", "a"));
            Console.WriteLine(MinWindow("a", "aa"));
        }

        private static string MinWindow(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            if (m > n) return "";

            Dictionary<char, int> kvp = new();
            foreach (char item in t)
            {
                if (kvp.TryGetValue(item, out _)) kvp[item]++;
                else kvp.Add(item, 1);
            }

            int l = 0, r = 0, len = n + 1, c = kvp.Count;
            string x = "";

            while (r < n)
            {
                char rChar = s[r];
                if (kvp.TryGetValue(rChar, out int _))
                {
                    kvp[rChar]--;
                    if (kvp[rChar] == 0) c--;
                }
                r++;

                while (c == 0)
                {
                    if (r - l < len)
                    {
                        len = r - l;
                        x = s.Substring(l, len);
                    }
                    char lChar = s[l];
                    if (kvp.TryGetValue(lChar, out _))
                    {
                        kvp[lChar]++;
                        if (kvp[lChar] > 0) c++;
                    }
                    l++;
                }
            }

            return x;
        }

        private static string MinWindow0(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[] map = new int[128];
            foreach (char c in t) map[c]++;

            int counter = m, begin = 0, end = 0, d = int.MaxValue, head = 0;
            while (end < n)
            {
                if (map[s[end++]]-- > 0) counter--;
                while (counter == 0)
                {
                    if (end - begin < d) d = end - (head = begin);
                    if (map[s[begin++]]++ == 0) counter++;
                }
            }

            return d == int.MaxValue ? "" : s.Substring(head, d);
        }
    }
}
