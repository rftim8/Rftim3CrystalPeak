using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00187_RepeatedDNASequences
    {
        /// <summary>
        /// The DNA sequence is composed of a series of nucleotides abbreviated as 'A', 'C', 'G', and 'T'.
        /// For example, "ACGAATTCCG" is a DNA sequence.
        /// When studying DNA, it is useful to identify repeated sequences within the DNA.
        /// Given a string s that represents a DNA sequence, return all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.
        /// You may return the answer in any order.
        /// </summary>
        public _00187_RepeatedDNASequences()
        {
            IList<string> x = FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT");
            IList<string> x0 = FindRepeatedDnaSequences("AAAAAAAAAAAAA");
            IList<string> x1 = FindRepeatedDnaSequences("AAAAAAAAAAA");

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static List<string> FindRepeatedDnaSequences(string s)
        {
            int n = s.Length;
            List<string> x = [];
            Dictionary<string, int> y = [];
            if (n < 10) return x;

            for (int i = 0; i < n - 9; i++)
            {
                string z = s[i..(i + 10)];

                if (!y.TryGetValue(z, out int value)) y.Add(z, 1);
                else y[z] = ++value;
            }

            foreach (KeyValuePair<string, int> item in y)
            {
                if (item.Value > 1) x.Add(item.Key);
            }

            return x;
        }
    }
}
