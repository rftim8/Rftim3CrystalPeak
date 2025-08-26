namespace Rftim3LeetCode.Temp
{
    public class _00139_WordBreak
    {
        /// <summary>
        /// Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.
        /// Note that the same word in the dictionary may be reused multiple times in the segmentation.
        /// </summary>
        public _00139_WordBreak()
        {
            Console.WriteLine(WordBreak("leetcode", new List<string>() { "leet", "code" }));
            Console.WriteLine(WordBreak("applepenapple", new List<string>() { "apple", "pen" }));
            Console.WriteLine(WordBreak("catsandog", new List<string>() { "cats", "dog", "sand", "and", "cat" }));
        }

        private static bool WordBreak(string s, IList<string> wordDict)
        {
            int n = s.Length;
            bool[] x = new bool[n + 1];

            x[0] = true;
            for (int i = 1; i <= n; i++)
            {
                int l = i - 1;
                foreach (string item in wordDict)
                {
                    int len = item.Length;
                    char r = item[^1];

                    if (r == s[l] && l + 1 >= len)
                    {
                        if (s.Substring(l - len + 1, len) == item) x[i] |= x[i - len];
                    }
                }
            }

            return x[n];
        }

        private static bool WordBreak0(string s, IList<string> wordDict)
        {
            int n = s.Length;
            bool[] dp = new bool[n + 1];
            dp[0] = true;

            for (int i = 0; i <= n; i++)
            {
                for (int j = i - 1; j > i - 1 - n; j--)
                {
                    if (j < 0) break;
                    if (dp[j] && wordDict.IndexOf(s.Substring(j, i - j)) != -1)
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[n];
        }
    }
}
