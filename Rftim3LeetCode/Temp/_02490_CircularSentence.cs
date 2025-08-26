namespace Rftim3LeetCode.Temp
{
    public class _02490_CircularSentence
    {
        /// <summary>
        /// A sentence is a list of words that are separated by a single space with no leading or trailing spaces.
        /// For example, "Hello World", "HELLO", "hello world hello world" are all sentences.
        /// Words consist of only uppercase and lowercase English letters.Uppercase and lowercase English letters are considered different.
        /// A sentence is circular if:
        /// The last character of a word is equal to the first character of the next word.
        /// The last character of the last word is equal to the first character of the first word.
        /// For example, "leetcode exercises sound delightful", "eetcode", "leetcode eats soul" are all circular sentences. 
        /// However, "Leetcode is cool", "happy Leetcode", "Leetcode" and "I like Leetcode" are not circular sentences.
        /// Given a string sentence, return true if it is circular.Otherwise, return false.
        /// </summary>
        public _02490_CircularSentence()
        {
            Console.WriteLine(IsCircularSentence("leetcode exercises sound delightful"));
            Console.WriteLine(IsCircularSentence("eetcode"));
            Console.WriteLine(IsCircularSentence("Leetcode is cool"));
        }

        private static bool IsCircularSentence(string sentence)
        {
            List<string> r = [.. sentence.Split(' ')];
            int n = r.Count;

            if (r[0][0] != r[^1][^1]) return false;

            for (int i = 0; i < n - 1; i++)
            {
                if (r[i][^1] != r[i + 1][0]) return false;
            }

            return true;
        }
    }
}
