namespace Rftim3LeetCode.Temp
{
    public class _02085_CountCommonWordsWithOneOccurrence
    {
        /// <summary>
        /// Given two string arrays words1 and words2, return the number of strings that appear exactly once in each of the two arrays.
        /// </summary>
        public _02085_CountCommonWordsWithOneOccurrence()
        {
            Console.WriteLine(CountWords(["leetcode", "is", "amazing", "as", "is"], ["amazing", "leetcode", "is"]));
            Console.WriteLine(CountWords(["b", "bb", "bbb"], ["a", "aa", "aaa"]));
            Console.WriteLine(CountWords(["a", "ab"], ["a", "a", "a", "ab"]));
        }

        private static int CountWords(string[] words1, string[] words2)
        {
            Dictionary<string, int> x0 = [];
            for (int i = 0; i < words1.Length; i++)
            {
                if (x0.TryGetValue(words1[i], out int value)) x0[words1[i]] = ++value;
                else x0[words1[i]] = 1;
            }
            x0 = x0.Where(o => o.Value == 1).ToDictionary(o => o.Key, o => o.Value);

            Dictionary<string, int> x1 = [];
            for (int i = 0; i < words2.Length; i++)
            {
                if (x1.TryGetValue(words2[i], out int value)) x1[words2[i]] = ++value;
                else x1[words2[i]] = 1;
            }
            x1 = x1.Where(o => o.Value == 1).ToDictionary(o => o.Key, o => o.Value);

            int r = 0;
            if (x0.Count > x1.Count)
            {
                foreach (KeyValuePair<string, int> item in x1)
                {
                    if (x0.ContainsKey(item.Key)) r++;
                }
            }
            else
            {
                foreach (KeyValuePair<string, int> item in x0)
                {
                    if (x1.ContainsKey(item.Key)) r++;
                }
            }

            return r;
        }
    }
}
