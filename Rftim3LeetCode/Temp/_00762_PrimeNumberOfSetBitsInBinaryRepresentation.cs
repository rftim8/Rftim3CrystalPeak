using System.Numerics;

namespace Rftim3LeetCode.Temp
{
    public class _00762_PrimeNumberOfSetBitsInBinaryRepresentation
    {
        /// <summary>
        /// Given two integers left and right, return the count of numbers in the inclusive range [left, right] having a prime number of set bits in their binary representation.
        /// Recall that the number of set bits an integer has is the number of 1's present when written in binary.
        /// For example, 21 written in binary is 10101, which has 3 set bits.
        /// </summary>
        public _00762_PrimeNumberOfSetBitsInBinaryRepresentation()
        {
            Console.WriteLine(PrimeNumberOfSetBitsInBinaryRepresentation0(6, 10));
            Console.WriteLine(PrimeNumberOfSetBitsInBinaryRepresentation0(10, 15));
        }

        public static int PrimeNumberOfSetBitsInBinaryRepresentation0(int a0, int a1) => RftPrimeNumberOfSetBitsInBinaryRepresentation0(a0, a1);

        public static int PrimeNumberOfSetBitsInBinaryRepresentation1(int a0, int a1) => RftPrimeNumberOfSetBitsInBinaryRepresentation1(a0, a1);

        private static int RftPrimeNumberOfSetBitsInBinaryRepresentation0(int left, int right)
        {
            int r = 0;

            for (int i = left; i <= right; i++)
            {
                int c = Convert.ToString(i, 2).Count(o => o == '1');

                if (IsPrime(c)) r++;
            }

            return r;
        }


        private static bool IsPrime(int n)
        {
            if (n == 2) return true;
            if (n < 2 || n % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

        private static int RftPrimeNumberOfSetBitsInBinaryRepresentation1(int left, int right)
        {
            int cnt = 0;

            for (int i = left; i <= right; i++)
            {
                int x = BitOperations.PopCount((uint)i);
                if (x == 2 || x == 3 || x == 5 || x == 7 ||
                    x == 11 || x == 13 || x == 17 || x == 19)
                    cnt++;
            }

            return cnt;
        }
    }
}