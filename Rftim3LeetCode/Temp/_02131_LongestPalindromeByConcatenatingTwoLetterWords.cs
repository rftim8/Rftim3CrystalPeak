namespace Rftim3LeetCode.Temp
{
    public class _02131_LongestPalindromeByConcatenatingTwoLetterWords
    {
        /// <summary>
        /// You are given an array of strings words. Each element of words consists of two lowercase English letters.
        /// Create the longest possible palindrome by selecting some elements from words and concatenating them in any order.Each element can be selected at most once.
        /// Return the length of the longest palindrome that you can create.If it is impossible to create any palindrome, return 0.
        /// A palindrome is a string that reads the same forward and backward.
        /// </summary>
        public _02131_LongestPalindromeByConcatenatingTwoLetterWords()
        {
            Console.WriteLine(LongestPalindrome(["lc", "cl", "gg"]));
            Console.WriteLine(LongestPalindrome(["ab", "ty", "yt", "lc", "cl", "ab"]));
            Console.WriteLine(LongestPalindrome(["cc", "ll", "xx"]));
        }

        private static int LongestPalindrome(string[] words)
        {
            int alpha = 26;
            int[,] count = new int[alpha, alpha];

            foreach (string word in words)
            {
                count[word[0] - 'a', word[1] - 'a']++;
            }

            int x = 0;
            bool mid = false;
            for (int i = 0; i < alpha; i++)
            {
                if (count[i, i] % 2 == 0) x += count[i, i];
                else
                {
                    x += count[i, i] - 1;
                    mid = true;
                }

                for (int j = i + 1; j < alpha; j++)
                {
                    x += 2 * Math.Min(count[i, j], count[j, i]);
                }
            }

            if (mid) x++;

            return 2 * x;
        }
    }
}
