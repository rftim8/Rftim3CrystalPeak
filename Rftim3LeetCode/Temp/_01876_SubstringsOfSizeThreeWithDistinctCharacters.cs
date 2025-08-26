namespace Rftim3LeetCode.Temp
{
    public class _01876_SubstringsOfSizeThreeWithDistinctCharacters
    {
        /// <summary>
        /// A string is good if there are no repeated characters.
        /// Given a string s​​​​​, return the number of good substrings of length three in s​​​​​​.
        /// Note that if there are multiple occurrences of the same substring, every occurrence should be counted.
        /// A substring is a contiguous sequence of characters in a string.
        /// </summary>
        public _01876_SubstringsOfSizeThreeWithDistinctCharacters()
        {
            Console.WriteLine(CountGoodSubstrings("xyzzaz"));
            Console.WriteLine(CountGoodSubstrings("aababcabc"));
        }

        private static int CountGoodSubstrings(string s)
        {
            int n = s.Length;
            if (n < 3) return 0;

            List<string> r = [];
            for (int i = 0; i < n - 2; i++)
            {
                string t = s[i..(i + 3)];

                HashSet<char> x = [];
                for (int j = 0; j < 3; j++)
                {
                    x.Add(t[j]);
                }
                if (x.Count == 3) r.Add(t);
            }

            return r.Count;
        }
    }
}
