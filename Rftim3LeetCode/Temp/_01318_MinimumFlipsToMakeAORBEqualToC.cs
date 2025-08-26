namespace Rftim3LeetCode.Temp
{
    public class _01318_MinimumFlipsToMakeAORBEqualToC
    {
        /// <summary>
        /// Given 3 positives numbers a, b and c. 
        /// Return the minimum flips required in some bits of a and b to make ( a OR b == c ). (bitwise OR operation).
        /// Flip operation consists of change any single bit 1 to 0 or change the bit 0 to 1 in their binary representation.
        /// </summary>
        public _01318_MinimumFlipsToMakeAORBEqualToC()
        {
            Console.WriteLine(MinimumFlipsToMakeAORBEqualToC0(2, 6, 5));
            Console.WriteLine(MinimumFlipsToMakeAORBEqualToC0(4, 2, 7));
            Console.WriteLine(MinimumFlipsToMakeAORBEqualToC0(1, 2, 3));
        }

        public static int MinimumFlipsToMakeAORBEqualToC0(int a0, int a1, int a2) => RftMinimumFlipsToMakeAORBEqualToC0(a0, a1, a2);

        private static int RftMinimumFlipsToMakeAORBEqualToC0(int a, int b, int c)
        {
            int r = 0;
            while (a != 0 | b != 0 | c != 0)
            {
                if ((c & 1) == 1)
                {
                    if ((a & 1) == 0 && (b & 1) == 0) r++;
                }
                else r += (a & 1) + (b & 1);

                a >>= 1;
                b >>= 1;
                c >>= 1;
            }

            return r;
        }
    }
}