namespace Rftim3LeetCode.Temp
{
    public class _00003_LongestSubstringWithoutRepeatingCharacters
    {
        /// <summary>
        /// Given a string s, find the length of the longest substring without repeating characters.
        /// </summary>
        public _00003_LongestSubstringWithoutRepeatingCharacters()
        {
            Console.WriteLine(LongestSubstringWithoutRepeatingCharacters0("abcabcbb"));
            Console.WriteLine(LongestSubstringWithoutRepeatingCharacters0("pwwkew"));
            Console.WriteLine(LongestSubstringWithoutRepeatingCharacters0("bbbbbb"));
            Console.WriteLine(LongestSubstringWithoutRepeatingCharacters0("tmmzuxt"));
        }

        public static int LongestSubstringWithoutRepeatingCharacters0(string a0) => RftLongestSubstringWithoutRepeatingCharacters0(a0);

        private static int RftLongestSubstringWithoutRepeatingCharacters0(string s)
        {
            int n = s.Length;
            int c = 0;
            HashSet<(char, int)> kvp = [];

            int x = 0;
            for (int i = 0; i < n; i++)
            {
                foreach ((char, int) item in kvp)
                {
                    if (item.Item1 == s[i]) x = Math.Max(item.Item2, x);
                }

                c = Math.Max(c, i - x + 1);
                kvp.Add((s[i], i + 1));
            }

            return c;
        }
    }
}
