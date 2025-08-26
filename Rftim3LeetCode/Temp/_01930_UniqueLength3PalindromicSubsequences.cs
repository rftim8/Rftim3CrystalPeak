namespace Rftim3LeetCode.Temp
{
    public class _01930_UniqueLength3PalindromicSubsequences
    {
        /// <summary>
        /// Given a string s, return the number of unique palindromes of length three that are a subsequence of s.
        /// Note that even if there are multiple ways to obtain the same subsequence, it is still only counted once.
        /// A palindrome is a string that reads the same forwards and backwards.
        /// A subsequence of a string is a new string generated from the original string with some characters(can be none) deleted without changing 
        /// the relative order of the remaining characters.
        /// For example, "ace" is a subsequence of "abcde".
        /// </summary>
        public _01930_UniqueLength3PalindromicSubsequences()
        {
            Console.WriteLine(CountPalindromicSubsequence0("aabca"));
            Console.WriteLine(CountPalindromicSubsequence0("adc"));
            Console.WriteLine(CountPalindromicSubsequence0("bbcbaba"));
        }

        public static int CountPalindromicSubsequence0(string a0) => RftCountPalindromicSubsequence0(a0);

        private static int RftCountPalindromicSubsequence0(string s)
        {
            HashSet<char> letters = [.. s];

            int ans = 0;
            foreach (char letter in letters)
            {
                int i = -1;
                int j = 0;

                for (int k = 0; k < s.Length; k++)
                {
                    if (s[k] == letter)
                    {
                        if (i == -1) i = k;

                        j = k;
                    }
                }

                HashSet<char> between = [];
                for (int k = i + 1; k < j; k++)
                {
                    between.Add(s[k]);
                }

                ans += between.Count;
            }

            return ans;
        }
    }
}
