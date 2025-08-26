namespace Rftim3LeetCode.Temp
{
    public class _01684_CountTheNumberOfConsistentStrings
    {
        /// <summary>
        /// You are given a string allowed consisting of distinct characters and an array of strings words.
        /// A string is consistent if all characters in the string appear in the string allowed.
        /// Return the number of consistent strings in the array words.
        /// </summary>
        public _01684_CountTheNumberOfConsistentStrings()
        {
            Console.WriteLine(CountConsistentStrings("ab", ["ad", "bd", "aaab", "baa", "badab"]));
            Console.WriteLine(CountConsistentStrings("abc", ["a", "b", "c", "ab", "ac", "bc", "abc"]));
            Console.WriteLine(CountConsistentStrings("cad", ["cc", "acd", "b", "ba", "bac", "bad", "ac", "d"]));
        }

        private static int CountConsistentStrings(string allowed, string[] words)
        {
            int n = words.Length;

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                bool q = true;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (!allowed.Contains(words[i][j]))
                    {
                        q = false;
                        break;
                    }
                }
                if (q) c++;
            }

            return c;
        }
    }
}
