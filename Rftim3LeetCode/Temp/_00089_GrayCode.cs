using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00089_GrayCode
    {
        /// <summary>
        /// An n-bit gray code sequence is a sequence of 2n integers where:
        /// Every integer is in the inclusive range[0, 2n - 1],
        /// The first integer is 0,
        /// An integer appears no more than once in the sequence,
        /// The binary representation of every pair of adjacent integers differs by exactly one bit, and
        /// The binary representation of the first and last integers differs by exactly one bit.
        /// Given an integer n, return any valid n-bit gray code sequence.
        /// </summary>
        public _00089_GrayCode()
        {
            IList<int> x = GrayCode(2);
            RftTerminal.RftReadResult(x);
            IList<int> x0 = GrayCode(1);
            RftTerminal.RftReadResult(x0);
        }

        private static List<int> GrayCode(int n)
        {
            HashSet<int> r = [0];
            int c = (int)Math.Pow(2, n);
            int x = 0;

            while (r.Count != c)
            {
                for (int i = 0; i < n; i++)
                {
                    if (!r.Contains(x ^ 1 << i))
                    {
                        x ^= 1 << i;
                        r.Add(x);

                        break;
                    }
                }
            }

            return [.. r];
        }
    }
}
