namespace Rftim3LeetCode.Temp
{
    public class _00326_PowerOfThree
    {
        /// <summary>
        /// Given an integer n, return true if it is a power of three. 
        /// Otherwise, return false.
        /// An integer n is a power of three, if there exists an integer x such that n == 3x.
        /// </summary>
        public _00326_PowerOfThree()
        {
            Console.WriteLine(IsPowerOfThree0(27));
            Console.WriteLine(IsPowerOfThree0(0));
            Console.WriteLine(IsPowerOfThree0(-1));
        }

        public static bool IsPowerOfThree0(int a0) => RftIsPowerOfThree0(a0);

        public static bool IsPowerOfThree1(int a0) => RftIsPowerOfThree1(a0);

        public static bool IsPowerOfThree2(int a0) => RftIsPowerOfThree2(a0);

        private static bool RftIsPowerOfThree0(int n)
        {
            return Math.Log10(n) / Math.Log10(3) % 1 == 0;
        }

        // Integer limitations
        private static bool RftIsPowerOfThree1(int n)
        {
            return n > 0 && 1162261467 % n == 0;
        }

        private static bool RftIsPowerOfThree2(int n)
        {
            if (n < 1) return false;

            while (n > 1)
            {
                if (n % 3 == 0) n /= 3;
                else return false;
            }

            return true;
        }
    }
}
