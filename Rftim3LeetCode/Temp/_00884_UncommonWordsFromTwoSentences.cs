using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00884_UncommonWordsFromTwoSentences
    {
        /// <summary>
        /// A sentence is a string of single-space separated words where each word consists only of lowercase letters.
        /// A word is uncommon if it appears exactly once in one of the sentences, and does not appear in the other sentence.
        /// Given two sentences s1 and s2, return a list of all the uncommon words.You may return the answer in any order.
        /// </summary>
        public _00884_UncommonWordsFromTwoSentences()
        {
            string[] x = UncommonFromSentences("this apple is sweet", "this apple is sour");
            string[] x0 = UncommonFromSentences("apple apple", "banana");

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static string[] UncommonFromSentences(string s1, string s2)
        {
            List<string> r = [.. s1.Split(' '), .. s2.Split(' ')];

            var x = r.GroupBy(o => o).Select(o => new { o.Key, Value = o.Count() }).Where(o => o.Value == 1);

            return x.Select(o => o.Key).ToArray();
        }

        private static string[] UncommonFromSentences0(string s1, string s2)
        {
            string s = $"{s1} {s2}";

            return s.Split(' ')
                .GroupBy(word => word)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .ToArray();
        }
    }
}
