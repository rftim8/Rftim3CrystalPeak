using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00066_PlusOne
    {
        /// <summary>
        /// You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. 
        /// The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.
        /// Increment the large integer by one and return the resulting array of digits.
        /// </summary>
        public _00066_PlusOne()
        {
            int[] x = PlusOne0([1, 2, 3]);
            RftTerminal.RftReadResult(x);

            int[] x0 = PlusOne0([4, 3, 2, 1]);
            RftTerminal.RftReadResult(x0);

            int[] x1 = PlusOne0([9]);
            RftTerminal.RftReadResult(x1);
        }

        public static int[] PlusOne0(int[] a0) => RftPlusOne0(a0);

        private static int[] RftPlusOne0(int[] digits)
        {
            int n = digits.Length;

            int[] x;
            bool inc = true;
            for (int i = n - 1; i >= 0; i--)
            {
                if (inc)
                {
                    if (digits[i] == 9)
                    {
                        digits[i] = 0;
                        if (i == 0)
                        {
                            x = new int[n + 1];
                            Array.Copy(digits, 0, x, 1, n);
                            x[0] = 1;
                            return x;
                        }
                    }
                    else
                    {
                        digits[i]++;
                        return digits;
                    }
                }
                else return digits;
            }

            return digits;
        }
    }
}
