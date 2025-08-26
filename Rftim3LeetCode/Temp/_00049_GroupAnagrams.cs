using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00049_GroupAnagrams
    {
        /// <summary>
        /// Given an array of strings strs, group the anagrams together. You can return the answer in any order.
        /// An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
        /// </summary>
        public _00049_GroupAnagrams()
        {
            IList<IList<string>> x = GroupAnagrams0(["eat", "tea", "tan", "ate", "nat", "bat"]);

            RftTerminal.RftReadResult(x);
        }

        public static IList<IList<string>> GroupAnagrams0(string[] a0) => RftGroupAnagrams0(a0);

        private static List<IList<string>> RftGroupAnagrams0(string[] strs)
        {
            int n = strs.Length;
            List<IList<string>> x = [];
            if (n == 0) return x;

            Dictionary<string, List<string>> y = [];
            for (int i = 0; i < n; i++)
            {
                string? z = string.Join("", strs[i].OrderBy(o => o));
                if (!y.TryGetValue(z, out List<string>? value)) y.Add(z, [strs[i]]);
                else value.Add(strs[i]);
            }

            foreach (KeyValuePair<string, List<string>> item in y)
            {
                x.Add(item.Value);
            }

            return x;
        }
    }
}
