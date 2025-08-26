using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01048_LongestStringChain
    {
        /// <summary>
        /// You are given an array of words where each word consists of lowercase English letters.
        /// wordA is a predecessor of wordB if and only if we can insert exactly one letter anywhere in wordA without changing the order of the other characters to make it equal to wordB.
        /// For example, "abc" is a predecessor of "abac", while "cba" is not a predecessor of "bcad".
        /// A word chain is a sequence of words[word1, word2, ..., wordk] with k >= 1, where word1 is a predecessor of word2, word2 is a predecessor of word3, and so on.
        /// A single word is trivially a word chain with k == 1.
        /// Return the length of the longest possible word chain with words chosen from the given list of words.
        /// </summary>

        private static int LongestStrChain(string[] words)
        {
            Array.Sort(words, (a, b) => a.Length.CompareTo(b.Length));
            int n = words.Length;
            int r = 1;

            List<HashSet<string>> x = [];
            foreach (string item in words)
            {
                x.Add([item]);
            }

            for (int i = 0; i < n; i++)
            {
                string c0 = words[i];
                for (int j = 0; j < x.Count; j++)
                {
                    string c1 = x[j].Last();
                    if (c0.Length != c1.Length + 1) continue;

                    HashSet<string> q = [.. x[j]];

                    for (int k = 0; k < c0.Length; k++)
                    {
                        StringBuilder sb = new(c0);
                        sb.Remove(k, 1);
                        if (c1 == sb.ToString())
                        {
                            q.Add(c0);
                            x.Add(q);
                            r = Math.Max(r, q.Count);
                        }
                    }
                }
            }

            return r;
        }

        private static int LongestStrChain0(string[] words)
        {
            Array.Sort(words, (a, b) => a.Length - b.Length);
            int r = 0;

            Dictionary<string, int> x = [];
            foreach (string item in words)
            {
                if (!x.ContainsKey(item))
                {
                    int c = 1;
                    for (int i = 0; i < item.Length; i++)
                    {
                        StringBuilder sb = new(item);
                        sb.Remove(i, 1);

                        string modifiedWord = sb.ToString();
                        int modifiedLen = x.TryGetValue(modifiedWord, out int value) ? value + 1 : 1;
                        c = Math.Max(c, modifiedLen);
                    }

                    x.Add(item, c);
                    r = Math.Max(r, c);
                }
            }

            return r;
        }

        private static int LongestStrChain1(string[] words)
        {
            Dictionary<string, int> map = [];
            Array.Sort(words, (a, b) => a.Length - b.Length);

            int result = 0;
            StringBuilder sb = new();
            foreach (string word in words)
            {
                sb.Clear();
                sb.Append(word);
                int length = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    StringBuilder prev = sb.Remove(i, 1);
                    map.TryGetValue(prev.ToString(), out int prevLength);
                    sb.Insert(i, word[i]);

                    length = Math.Max(length, prevLength + 1);
                }

                map[word] = length;
                result = Math.Max(result, length);
            }

            return result;
        }
    }
}
