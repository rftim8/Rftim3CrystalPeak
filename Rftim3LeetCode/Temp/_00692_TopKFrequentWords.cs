using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00692_TopKFrequentWords
    {
        /// <summary>
        /// Given an array of strings words and an integer k, return the k most frequent strings.
        /// Return the answer sorted by the frequency from highest to lowest.
        /// Sort the words with the same frequency by their lexicographical order.
        /// </summary>
        public _00692_TopKFrequentWords()
        {
            IList<string> x = TopKFrequent(["i", "love", "leetcode", "i", "love", "coding"], 2);
            IList<string> x1 = TopKFrequent(["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], 4);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x1);
        }

        private static List<string> TopKFrequent(string[] words, int k)
        {
            int n = words.Length;
            Dictionary<string, int> x = [];
            List<string> y = [];

            for (int i = 0; i < n; i++)
            {
                if (!x.TryGetValue(words[i], out int value)) x.Add(words[i], 1);
                else x[words[i]] = ++value;
            }
            y = x.OrderByDescending(o => o.Value).ThenBy(o => o.Key).Select(o => o.Key).ToList();

            return y.GetRange(0, k);
        }
    }
}
