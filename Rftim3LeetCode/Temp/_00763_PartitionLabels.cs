using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00763_PartitionLabels
    {
        /// <summary>
        /// You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        /// Note that the partition is done so that after concatenating all the parts in order, the resultant string should be s.
        /// Return a list of integers representing the size of these parts.
        /// </summary>
        public _00763_PartitionLabels()
        {
            IList<int> x0 = PartitionLabels("ababcbacadefegdehijhklij");
            IList<int> x1 = PartitionLabels("eccbbbbdec");

            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static List<int> PartitionLabels(string s)
        {
            int n = s.Length;
            int[] chars = new int[26];

            for (int i = 0; i < n; ++i)
            {
                chars[s[i] - 'a'] = i;
            }

            int j = 0, l = 0;
            List<int> x = [];
            for (int i = 0; i < n; ++i)
            {
                j = Math.Max(j, chars[s[i] - 'a']);
                if (i == j)
                {
                    x.Add(i - l + 1);
                    l = i + 1;
                }
            }

            return x;
        }
    }
}
