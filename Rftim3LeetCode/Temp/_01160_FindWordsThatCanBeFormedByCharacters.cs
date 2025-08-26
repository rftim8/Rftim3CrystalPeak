namespace Rftim3LeetCode.Temp
{
    public class _01160_FindWordsThatCanBeFormedByCharacters
    {
        /// <summary>
        /// You are given an array of strings words and a string chars.
        /// A string is good if it can be formed by characters from chars(each character can only be used once).
        /// Return the sum of lengths of all good strings in words.
        /// </summary>
        public _01160_FindWordsThatCanBeFormedByCharacters()
        {
            Console.WriteLine(FindWordsThatCanBeFormedByCharacters0(["cat", "bt", "hat", "tree"], "atach"));
            Console.WriteLine(FindWordsThatCanBeFormedByCharacters0(["hello", "world", "leetcode"], "welldonehoneyr"));
        }

        public static int FindWordsThatCanBeFormedByCharacters0(string[] a0, string a1) => RftFindWordsThatCanBeFormedByCharacters0(a0, a1);

        public static int FindWordsThatCanBeFormedByCharacters1(string[] a0, string a1) => RftFindWordsThatCanBeFormedByCharacters1(a0, a1);

        private static int RftFindWordsThatCanBeFormedByCharacters0(string[] words, string chars)
        {
            int n = words.Length;

            Dictionary<char, int> x = [];

            foreach (char item in chars)
            {
                if (!x.TryGetValue(item, out int value)) x.Add(item, 1);
                else x[item] = ++value;
            }

            int r = 0;
            for (int i = 0; i < n; i++)
            {
                int m = words[i].Length;
                int c = 0;
                Dictionary<char, int> y = new(x);
                for (int j = 0; j < m; j++)
                {
                    if (y.TryGetValue(words[i][j], out int value))
                    {
                        if (value > 0)
                        {
                            y[words[i][j]] = --value;
                            c++;
                        }
                    }
                }
                if (c == m) r += c;
            }

            return r;
        }

        private static int RftFindWordsThatCanBeFormedByCharacters1(string[] words, string chars)
        {
            int[] freq = new int[26];
            int len = 0;

            for (int i = 0; i < chars.Length; i++) freq[chars[i] - 'a']++;

            foreach (string word in words)
            {
                int[] freqWord = new int[26];
                len += word.Length;
                for (int i = 0; i < word.Length; i++)
                {
                    int idx = word[i] - 'a';
                    freqWord[idx]++;
                    if (freqWord[idx] > freq[idx])
                    {
                        len -= word.Length;
                        break;
                    }
                }
            }

            return len;
        }
    }
}