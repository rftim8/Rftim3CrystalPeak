using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02899_LastVisitedIntegers
    {
        /// <summary>
        /// Given a 0-indexed array of strings words where words[i] is either a positive integer represented as a string or the string "prev".
        /// 
        /// Start iterating from the beginning of the array; 
        /// for every "prev" string seen in words, find the last visited integer in words which is defined as follows:
        /// 
        /// Let k be the number of consecutive "prev" strings seen so far(containing the current string). 
        /// Let nums be the 0-indexed array of integers seen so far and nums_reverse be the reverse of nums, 
        /// then the integer at(k - 1)th index of nums_reverse will be the last visited integer for this "prev".
        /// If k is greater than the total visited integers, then the last visited integer will be -1.
        /// Return an integer array containing the last visited integers.
        /// </summary>
        public _02899_LastVisitedIntegers()
        {
            IList<int> x0 = LastVisitedIntegers0(["1", "2", "prev", "prev", "prev"]);
            RftTerminal.RftReadResult(x0);

            IList<int> x1 = LastVisitedIntegers0(["1", "prev", "2", "prev", "prev"]);
            RftTerminal.RftReadResult(x1);
        }

        public static IList<int> LastVisitedIntegers0(IList<string> a0) => RftLastVisitedIntegers0(a0);

        private static List<int> RftLastVisitedIntegers0(IList<string> words)
        {
            int n = words.Count;

            List<int> r = [];
            List<string> x = [];
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (words[i] == "prev")
                {
                    if (c == 0) r.Add(-1);
                    else
                    {
                        r.Add(int.Parse(x[c - 1]));
                        c--;
                    }
                }
                else
                {
                    x.Add(words[i]);
                    c = x.Count;
                }
            }

            return r;
        }
    }
}
