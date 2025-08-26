using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02595_NumberOfEvenAndOddBits
    {
        /// <summary>
        /// You are given a positive integer n.
        /// Let even denote the number of even indices in the binary representation of n(0-indexed) with value 1.
        /// Let odd denote the number of odd indices in the binary representation of n(0-indexed) with value 1.
        /// Return an integer array answer where answer = [even, odd].
        /// </summary>
        public _02595_NumberOfEvenAndOddBits()
        {
            int[] x = EvenOddBit(17);
            RftTerminal.RftReadResult(x);
            int[] x0 = EvenOddBit(2);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] EvenOddBit(int n)
        {
            int[] result = new int[2];

            for (int i = 0; n > 0; n >>= 1, i = 1 - i)
            {
                result[i] += n % 2;
            }

            return result;
        }
    }
}
