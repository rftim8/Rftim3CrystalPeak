namespace Rftim3LeetCode.Temp
{
    public class _02068_CheckWhetherTwoStringsAreAlmostEquivalent
    {
        /// <summary>
        /// Two strings word1 and word2 are considered almost equivalent if the differences between the frequencies of each letter from 'a' to 'z' between word1 and word2 is at most 3.
        /// Given two strings word1 and word2, each of length n, return true if word1 and word2 are almost equivalent, or false otherwise.
        /// The frequency of a letter x is the number of times it occurs in the string.
        /// </summary>
        public _02068_CheckWhetherTwoStringsAreAlmostEquivalent()
        {
            Console.WriteLine(CheckAlmostEquivalent("aaaa", "bccb"));
            Console.WriteLine(CheckAlmostEquivalent("abcdeef", "abaaacc"));
            Console.WriteLine(CheckAlmostEquivalent("cccddabba", "babababab"));
        }

        private static bool CheckAlmostEquivalent(string word1, string word2)
        {
            char[] x0 = new char[26];
            char[] x1 = new char[26];

            for (int i = 0; i < word1.Length; i++)
            {
                x0[word1[i] - 97]++;
            }
            for (int i = 0; i < word2.Length; i++)
            {
                x1[word2[i] - 97]++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (Math.Abs(x0[i] - x1[i]) > 3) return false;
            }

            return true;
        }
    }
}
