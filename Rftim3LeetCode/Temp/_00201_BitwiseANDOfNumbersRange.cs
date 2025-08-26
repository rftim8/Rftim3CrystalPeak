namespace Rftim3LeetCode.Temp
{
    public class _00201_BitwiseANDOfNumbersRange
    {
        /// <summary>
        /// Given two integers left and right that represent the range [left, right], return the bitwise AND of all numbers in this range, inclusive.
        /// </summary>
        public _00201_BitwiseANDOfNumbersRange()
        {
            Console.WriteLine(RangeBitwiseAnd(5, 7));
            Console.WriteLine(RangeBitwiseAnd(0, 0));
            Console.WriteLine(RangeBitwiseAnd(1, 2147483647));
        }

        private static int RangeBitwiseAnd(int left, int right)
        {
            int tailingZeroCnt = 0;
            while (left != right)
            {
                tailingZeroCnt++;
                left >>= 1;
                right >>= 1;
            }

            return left << tailingZeroCnt;
        }

        private static int RangeBitwiseAnd0(int m, int n)
        {
            int res = 0;
            int idx = 0;

            while (m != 0 || n != 0)
            {
                if (m == n && m % 2 == 1)
                {
                    res |= 1 << idx;
                }

                idx++;
                m /= 2;
                n /= 2;
            }

            return res;
        }
    }
}
