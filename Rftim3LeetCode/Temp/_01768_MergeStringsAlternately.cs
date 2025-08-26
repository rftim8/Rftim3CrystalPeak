namespace Rftim3LeetCode.Temp
{
    public class _01768_MergeStringsAlternately
    {
        /// <summary>
        /// You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1.
        /// If a string is longer than the other, append the additional letters onto the end of the merged string.
        /// Return the merged string.
        /// </summary>
        public _01768_MergeStringsAlternately()
        {
            Console.WriteLine(MergeAlternately("abc", "pqr"));
            Console.WriteLine(MergeAlternately("ab", "pqrs"));
            Console.WriteLine(MergeAlternately("abcd", "pq"));
        }

        private static string MergeAlternately(string word1, string word2)
        {
            int n = Math.Max(word1.Length, word2.Length);
            string x = "";

            for (int i = 0; i < n; i++)
            {
                if (i < word1.Length) x += word1[i];
                if (i < word2.Length) x += word2[i];
            }

            return x;
        }
    }
}
