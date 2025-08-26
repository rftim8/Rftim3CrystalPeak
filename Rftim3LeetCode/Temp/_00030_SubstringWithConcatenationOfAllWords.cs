using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00030_SubstringWithConcatenationOfAllWords
    {
        /// <summary>
        /// You are given a string s and an array of strings words. All the strings of words are of the same length.
        /// A concatenated substring in s is a substring that contains all the strings of any permutation of words concatenated.
        /// For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. 
        /// "acdbef" is not a concatenated substring because it is not the concatenation of any permutation of words.
        /// Return the starting indices of all the concatenated substrings in s.You can return the answer in any order.
        /// </summary>
        public _00030_SubstringWithConcatenationOfAllWords()
        {
            IList<int> x = SubstringWithConcatenationOfAllWords0("barfoothefoobarman", ["foo", "bar"]);
            RftTerminal.RftReadResult(x);

            IList<int> x0 = SubstringWithConcatenationOfAllWords0("wordgoodgoodgoodbestword", ["word", "good", "best", "word"]);
            RftTerminal.RftReadResult(x0);

            IList<int> x1 = SubstringWithConcatenationOfAllWords0("barfoofoobarthefoobarman", ["bar", "foo", "the"]);
            RftTerminal.RftReadResult(x1);
        }

        public static List<int> SubstringWithConcatenationOfAllWords0(string a0, string[] a1) => RftSubstringWithConcatenationOfAllWords0(a0, a1);

        private static List<int> RftSubstringWithConcatenationOfAllWords0(string s, string[] words)
        {
            int o = s.Length;
            int n = words.Length;
            int m = words[0].Length;
            List<int> r = [];
            Dictionary<string, int> d = [];

            foreach (string item in words)
            {
                if (d.TryGetValue(item, out int value)) d[item] = ++value;
                else d[item] = 1;
            }

            Dictionary<string, int> v = [];
            for (int i = 0; i < o - n * m + 1; i++)
            {
                v.Clear();

                int c = 0;
                while (c < n)
                {
                    string t = s.Substring(i + c * m, m);
                    if (!d.ContainsKey(t)) break;
                    if (v.TryGetValue(t, out int value)) v[t] = ++value;
                    else v[t] = 1;

                    if (v[t] > d[t]) break;
                    c++;
                }

                if (c == n) r.Add(i);
            }

            return r;
        }

        private static List<int> RftSubstringWithConcatenationOfAllWords1(string s, string[] words)
        {
            List<int> r = [];

            int wordLength = words[0].Length;
            int totalWordLength = wordLength * words.Length;

            Dictionary<string, int> wordFrquency = [];

            foreach (string word in words)
            {
                if (wordFrquency.TryGetValue(word, out int value)) wordFrquency[word] = ++value;
                else wordFrquency[word] = 1;
            }

            for (int i = 0; i < wordLength; i++)
            {
                int left = i;
                int right = i;
                Dictionary<string, int> currentSubstring = [];

                while (right + wordLength <= s.Length)
                {
                    string currentWord = s.Substring(right, wordLength);
                    right += wordLength;

                    if (!wordFrquency.TryGetValue(currentWord, out int value))
                    {
                        currentSubstring.Clear();
                        left = right;
                    }
                    else
                    {
                        if (!currentSubstring.TryGetValue(currentWord, out int value0)) currentSubstring[currentWord] = 1;
                        else currentSubstring[currentWord] = ++value0;

                        while (currentSubstring[currentWord] > value)
                        {
                            string leftWord = s.Substring(left, wordLength);
                            currentSubstring[leftWord]--;
                            left += wordLength;
                        }

                        if (right - left == totalWordLength) r.Add(left);
                    }
                }
            }

            return r;
        }
    }
}
