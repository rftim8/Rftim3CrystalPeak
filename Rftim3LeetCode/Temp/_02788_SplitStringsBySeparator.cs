using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02788_SplitStringsBySeparator
    {
        /// <summary>
        /// Given an array of strings words and a character separator, split each string in words by separator.
        /// Return an array of strings containing the new strings formed after the splits, excluding empty strings.
        /// Notes
        /// separator is used to determine where the split should occur, but it is not included as part of the resulting strings.
        /// A split may result in more than two strings.
        /// The resulting strings must maintain the same order as they were initially given.
        /// </summary>
        public _02788_SplitStringsBySeparator()
        {
            IList<string> x = SplitWordsBySeparator(["one.two.three", "four.five", "six"], '.');
            RftTerminal.RftReadResult(x);
            IList<string> x0 = SplitWordsBySeparator(["$easy$", "$problem$"], '$');
            RftTerminal.RftReadResult(x0);
            IList<string> x1 = SplitWordsBySeparator(["|||"], '|');
            RftTerminal.RftReadResult(x1);
        }

        private static List<string> SplitWordsBySeparator(IList<string> words, char separator)
        {
            List<string> r = [];

            foreach (string item in words)
            {
                r.AddRange(item.Split(separator, StringSplitOptions.RemoveEmptyEntries));
            }

            return r;
        }
    }
}
