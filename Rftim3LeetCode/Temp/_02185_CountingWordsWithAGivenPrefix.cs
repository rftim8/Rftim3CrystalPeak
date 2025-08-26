namespace Rftim3LeetCode.Temp
{
    public class _02185_CountingWordsWithAGivenPrefix
    {
        /// <summary>
        /// You are given an array of strings words and a string pref.
        /// Return the number of strings in words that contain pref as a prefix.
        /// A prefix of a string s is any leading contiguous substring of s.
        /// </summary>
        public _02185_CountingWordsWithAGivenPrefix()
        {
            Console.WriteLine(PrefixCount(["pay", "attention", "practice", "attend"], "at"));
            Console.WriteLine(PrefixCount(["leetcode", "win", "loops", "success"], "code"));
        }

        private static int PrefixCount(string[] words, string pref)
        {
            int r = 0;

            foreach (string item in words)
            {
                if (item.StartsWith(pref)) r++;
            }

            return r;
        }
    }
}
