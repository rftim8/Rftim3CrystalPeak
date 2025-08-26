using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02273_FindResultantArrayAfterRemovingAnagrams
    {
        /// <summary>
        /// You are given a 0-indexed string array words, where words[i] consists of lowercase English letters.
        /// In one operation, select any index i such that 0 < i<words.length and words[i - 1] and words[i] are anagrams, and delete words[i] from words.
        /// Keep performing this operation as long as you can select an index that satisfies the conditions.
        /// Return words after performing all operations.It can be shown that selecting the indices for each operation in any arbitrary order will lead to the same result.
        /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase using all the original letters exactly once.
        /// For example, "dacb" is an anagram of "abdc".
        /// </summary>
        public _02273_FindResultantArrayAfterRemovingAnagrams()
        {
            IList<string> x = RemoveAnagrams(["abba", "baba", "bbaa", "cd", "cd"]);
            IList<string> x0 = RemoveAnagrams(["a", "b", "c", "d", "e"]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static IList<string> RemoveAnagrams(string[] words)
        {
            if (words.Length == 1) return words;

            List<string> x = [.. words];

            for (int i = 1; i < x.Count; i++)
            {
                char[] l = x[i - 1].ToCharArray();
                Array.Sort(l);
                char[] r = x[i].ToCharArray();
                Array.Sort(r);

                if (l.SequenceEqual(r))
                {
                    x.Remove(x[i]);
                    i--;
                }
            }

            return x;
        }
    }
}
