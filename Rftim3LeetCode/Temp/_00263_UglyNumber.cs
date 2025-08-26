namespace Rftim3LeetCode.Temp
{
    public class _00263_UglyNumber
    {
        /// <summary>
        /// An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.
        /// Given an integer n, return true if n is an ugly number.
        /// </summary>
        public _00263_UglyNumber()
        {
            Console.WriteLine(IsUgly0(6));
            Console.WriteLine(IsUgly0(1));
            Console.WriteLine(IsUgly0(14));
        }

        public static bool IsUgly0(int a0) => RftIsUgly0(a0);

        private static bool RftIsUgly0(int n)
        {
            while (n > 1)
            {
                if (n % 2 == 0) n /= 2;
                else if (n % 3 == 0) n /= 3;
                else if (n % 5 == 0) n /= 5;
                else return false;
            }

            return n > 0;
        }
    }
}
