namespace Rftim3LeetCode.Temp
{
    public class _02255_CountPrefixesOfAGivenString
    {
        /// <summary>
        /// You are given a string array words and a string s, where words[i] and s comprise only of lowercase English letters.
        /// Return the number of strings in words that are a prefix of s.
        /// A prefix of a string is a substring that occurs at the beginning of the string.
        /// A substring is a contiguous sequence of characters within a string.
        /// </summary>
        public _02255_CountPrefixesOfAGivenString()
        {
            Console.WriteLine(CountPrefixes(["a", "b", "c", "ab", "bc", "abc"], "abc"));
            Console.WriteLine(CountPrefixes(["a", "a"], "aa"));
        }

        private static int CountPrefixes(string[] words, string s)
        {
            int r = 0;

            foreach (string item in words)
            {
                if (s.StartsWith(item)) r++;
            }

            return r;
        }
    }
}
