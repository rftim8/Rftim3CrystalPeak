using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01408_StringMatchingInAnArray
    {
        /// <summary>
        /// Given an array of string words, return all strings in words that is a substring of another word. 
        /// You can return the answer in any order.
        /// A substring is a contiguous sequence of characters within a string
        /// </summary>
        public _01408_StringMatchingInAnArray()
        {
            IList<string> x = StringMatching(["mass", "as", "hero", "superhero"]);
            IList<string> x0 = StringMatching(["leetcode", "et", "code"]);
            IList<string> x1 = StringMatching(["blue", "green", "bu"]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static List<string> StringMatching(string[] words)
        {
            int n = words.Length;

            HashSet<string> r = [];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j) if (words[i].Contains(words[j])) r.Add(words[j]);
                }
            }

            return [.. r];
        }
    }
}
