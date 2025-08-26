using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00140_WordBreak2
    {
        /// <summary>
        /// Given a string s and a dictionary of strings wordDict, add spaces in s to construct a sentence where each word is a valid dictionary word. 
        /// Return all such possible sentences in any order.
        /// Note that the same word in the dictionary may be reused multiple times in the segmentation.
        /// </summary>
        public _00140_WordBreak2()
        {
            IList<string> x = WordBreak("catsanddog", ["cat", "cats", "and", "sand", "dog"]);
            RftTerminal.RftReadResult(x);
            IList<string> x0 = WordBreak("pineapplepenapple", ["apple", "pen", "applepen", "pine", "pineapple"]);
            RftTerminal.RftReadResult(x0);
            IList<string> x1 = WordBreak("catsandog", ["cats", "dog", "sand", "and", "cat"]);
            RftTerminal.RftReadResult(x1);
        }

        private static List<string> WordBreak(string s, IList<string> wordDict)
        {
            return Dfs(s, wordDict, 0, new List<string>[s.Length]);
        }

        private static List<string> Dfs(string s, IList<string> l, int i, List<string>[] t)
        {
            if (t[i] is not null) return t[i];

            List<string> c = [];
            for (int j = i; j < s.Length; j++)
            {
                if (l.Contains(s.Substring(i, j - i + 1)))
                {
                    if (j == s.Length - 1) c.Add(s.Substring(i, j - i + 1));
                    else
                    {
                        foreach (string item in Dfs(s, l, j + 1, t))
                        {
                            c.Add($"{s.Substring(i, j - i + 1)} {item}");
                        }
                    }
                }
            }

            t[i] = c;

            return t[i];
        }
    }
}
