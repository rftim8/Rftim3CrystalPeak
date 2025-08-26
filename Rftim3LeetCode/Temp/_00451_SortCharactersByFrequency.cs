using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00451_SortCharactersByFrequency
    {
        /// <summary>
        /// Given a string s, sort it in decreasing order based on the frequency of the characters.
        /// The frequency of a character is the number of times it appears in the string.
        /// Return the sorted string. If there are multiple answers, return any of them.
        /// </summary>
        public _00451_SortCharactersByFrequency()
        {
            Console.WriteLine(FrequencySort("tree"));
            Console.WriteLine(FrequencySort("cccaaa"));
            Console.WriteLine(FrequencySort("Aabb"));
        }

        private static string FrequencySort(string s)
        {
            int n = s.Length;
            Dictionary<char, int> x = [];

            for (int i = 0; i < n; i++)
            {
                if (!x.TryGetValue(s[i], out int value)) x.Add(s[i], 1);
                else x[s[i]] = ++value;
            }
            x = x.OrderByDescending(o => o.Value).ToDictionary(o => o.Key, o => o.Value);

            string y = "";
            foreach (KeyValuePair<char, int> item in x)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    y += item.Key;
                }
            }

            return y;
        }

        private static string FrequencySort0(string s)
        {
            Dictionary<char, int> dict = [];

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.TryGetValue(s[i], out int value)) dict.Add(s[i], 1);
                else dict[s[i]] = ++value;
            }

            PriorityQueue<char, int> queue = new();

            foreach (KeyValuePair<char, int> x in dict)
            {
                queue.Enqueue(x.Key, -x.Value);
            }

            StringBuilder result = new();

            while (queue.Count > 0)
            {
                char tmp = queue.Dequeue();
                int cnt = dict[tmp];

                for (int i = 0; i < cnt; i++)
                {
                    result.Append(tmp);
                }
            }

            return result.ToString();
        }
    }
}
