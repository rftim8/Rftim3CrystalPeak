using System.Numerics;

namespace Rftim3LeetCode.Temp
{
    public class _01009_ComplementOfBase10Integer
    {
        /// <summary>
        /// The complement of an integer is the integer you get when you flip all the 0's to 1's and all the 1's to 0's in its binary representation.
        /// For example, The integer 5 is "101" in binary and its complement is "010" which is the integer 2.
        /// Given an integer n, return its complement.
        /// </summary>
        public _01009_ComplementOfBase10Integer()
        {
            Console.WriteLine(BitwiseComplement(5));
            Console.WriteLine(BitwiseComplement(7));
            Console.WriteLine(BitwiseComplement(10));
        }

        private static int BitwiseComplement(int n)
        {
            string r = Convert.ToString(n, 2);
            char[] x = r.ToCharArray();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == '1') x[i] = '0';
                else x[i] = '1';
            }

            return Convert.ToInt32(string.Concat(x), 2);
        }

        private static int BitwiseComplement0(int n)
        {
            int zeroCnt = BitOperations.LeadingZeroCount((uint)n);
            return n == 0 ? 1 : ~n << zeroCnt >> zeroCnt;
        }

        private static int BitwiseComplement1(int n)
        {
            int m = n;
            int mask = 0;

            if (n == 0) return 1;

            while (m != 0)
            {
                mask = mask << 1 | 1;
                m >>= 1;
            }
            int ans = ~n & mask;

            return ans;
        }

        private static int BitwiseComplement2(int n)
        {
            int mask = 1;

            while (mask < n)
            {
                mask = mask << 1 | 1;
            }

            return n ^ mask;
        }
    }
}
