using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00767_ReorganizeString
    {
        /// <summary>
        /// Given a string s, rearrange the characters of s so that any two adjacent characters are not the same.
        /// Return any possible rearrangement of s or return "" if not possible.
        /// </summary>
        public _00767_ReorganizeString()
        {
            Console.WriteLine(ReorganizeString("aab"));
            Console.WriteLine(ReorganizeString("aaab"));
            Console.WriteLine(ReorganizeString("baaba"));
            Console.WriteLine(ReorganizeString("vvvlo"));
        }

        private static string ReorganizeString(string s)
        {
            int[] charCounts = new int[26];
            foreach (char c in s.ToCharArray())
            {
                charCounts[c - 'a']++;
            }

            int maxCount = 0, letter = 0;
            for (int i = 0; i < charCounts.Length; i++)
            {
                if (charCounts[i] > maxCount)
                {
                    maxCount = charCounts[i];
                    letter = i;
                }
            }

            if (maxCount > (s.Length + 1) / 2) return "";
            char[] ans = new char[s.Length];
            int index = 0;

            while (charCounts[letter] != 0)
            {
                ans[index] = (char)(letter + 'a');
                index += 2;
                charCounts[letter]--;
            }

            for (int i = 0; i < charCounts.Length; i++)
            {
                while (charCounts[i] > 0)
                {
                    if (index >= s.Length) index = 1;

                    ans[index] = (char)(i + 'a');
                    index += 2;
                    charCounts[i]--;
                }
            }

            return string.Concat(ans);
        }

        private static string ReorganizeString0(string s)
        {
            Dictionary<char, int> Map = [];
            foreach (char c in s)
            {
                if (Map.TryGetValue(c, out int value)) Map[c] = ++value;
                else Map[c] = 1;
            }

            PriorityQueue<char, int> pq = new(new FreqComparer());
            foreach (char key in Map.Keys)
            {
                pq.Enqueue(key, Map[key]);
            }

            StringBuilder sb = new();
            while (pq.Count > 1)
            {
                char currChar = pq.Dequeue();
                char nextChar = pq.Dequeue();
                sb.Append(currChar);
                sb.Append(nextChar);
                Map[currChar]--;
                Map[nextChar]--;

                if (Map[currChar] > 0) pq.Enqueue(currChar, Map[currChar]);
                if (Map[nextChar] > 0) pq.Enqueue(nextChar, Map[nextChar]);
            }

            if (pq.Count > 0)
            {
                char lastChar = pq.Dequeue();

                if (Map[lastChar] > 1) return string.Empty;

                sb.Append(lastChar);
            }

            return sb.ToString();
        }

        public class FreqComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }
    }
}
