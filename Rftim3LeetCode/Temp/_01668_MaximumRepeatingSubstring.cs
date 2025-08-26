namespace Rftim3LeetCode.Temp
{
    public class _01668_MaximumRepeatingSubstring
    {
        /// <summary>
        /// For a string sequence, a string word is k-repeating if word concatenated k times is a substring of sequence. 
        /// The word's maximum k-repeating value is the highest value k where word is k-repeating in sequence. 
        /// If word is not a substring of sequence, word's maximum k-repeating value is 0.
        /// Given strings sequence and word, return the maximum k-repeating value of word in sequence.
        /// </summary>
        public _01668_MaximumRepeatingSubstring()
        {
            Console.WriteLine(MaxRepeating("ababc", "ab"));
            Console.WriteLine(MaxRepeating("ababc", "ba"));
            Console.WriteLine(MaxRepeating("ababc", "ac"));
            Console.WriteLine(MaxRepeating("aaabaaaabaaabaaaabaaaabaaaabaaaaba", "aaaba"));
            Console.WriteLine(MaxRepeating("aaa", "a"));
        }

        private static int MaxRepeating(string sequence, string word)
        {
            int n = sequence.Length;
            int m = word.Length;
            if (n < m) return 0;
            if (n == 1) return sequence == word ? 1 : 0;

            int c = 0;
            string t = word;
            for (int i = 1; i * m <= n; i++)
            {
                if (sequence.Contains(t)) c = i;
                t += word;
            }

            return c;
        }

        private static int MaxRepeating0(string sequence, string word)
        {
            int n = sequence.Length;
            int m = word.Length;

            int maxCnt = 0;
            for (int i = 0; i <= n - m; i++)
            {
                int j = 0;
                for (; i + j < n; j++)
                {
                    if (sequence[i + j] != word[j % m]) break;
                }
                maxCnt = Math.Max(maxCnt, j / m);
            }

            return maxCnt;
        }
    }
}
