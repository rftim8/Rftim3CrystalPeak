namespace Rftim3LeetCode.Temp
{
    public class _00409_LongestPalindrome
    {
        /// <summary>
        /// Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.
        /// Letters are case sensitive, for example, "Aa" is not considered a palindrome here.
        /// </summary>
        public _00409_LongestPalindrome()
        {
            Console.WriteLine(LongestPalindrome0("abccccdd"));
            Console.WriteLine(LongestPalindrome0("a"));
        }

        public static int LongestPalindrome0(string a0) => RftLongestPalindrome0(a0);

        private static int RftLongestPalindrome0(string s)
        {
            int n = s.Length;
            if (n == 1) return 1;

            int r = 0;
            Dictionary<char, int> kvp = [];
            for (int i = 0; i < n; i++)
            {
                if (kvp.TryGetValue(s[i], out int value)) kvp[s[i]] = ++value;
                else kvp.Add(s[i], 1);
            }

            bool mid = true;
            foreach (KeyValuePair<char, int> item in kvp)
            {
                if (item.Value % 2 == 0) r += item.Value;
                else
                {
                    if (mid)
                    {
                        r += item.Value;
                        mid = false;
                    }
                    else r += item.Value - 1;
                }
            }

            return r;
        }
    }
}
