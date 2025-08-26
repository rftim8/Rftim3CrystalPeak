namespace Rftim3LeetCode.Temp
{
    public class _00507_PerfectNumber
    {
        /// <summary>
        /// A perfect number is a positive integer that is equal to the sum of its positive divisors, excluding the number itself.
        /// A divisor of an integer x is an integer that can divide x evenly.
        /// Given an integer n, return true if n is a perfect number, otherwise return false.
        /// </summary>
        public _00507_PerfectNumber()
        {
            Console.WriteLine(CheckPerfectNumber0(28));
            Console.WriteLine(CheckPerfectNumber0(7));
        }

        public static bool CheckPerfectNumber0(int a0) => RftCheckPerfectNumber0(a0);

        public static bool CheckPerfectNumber1(int a0) => RftCheckPerfectNumber1(a0);

        public static bool CheckPerfectNumber2(int a0) => RftCheckPerfectNumber2(a0);

        private static bool RftCheckPerfectNumber0(int num)
        {
            int r = 0;

            for (int i = num - 1; i > 0; i--)
            {
                if (num % i == 0) r += i;
            }

            return r == num;
        }

        private static bool RftCheckPerfectNumber1(int num) => GetSumOfDivisors(num) == num;

        private static int GetSumOfDivisors(int num)
        {
            int sum = 0;
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    sum += i;

                    if (i != num / i) sum += num / i;
                }
            }

            return sum - num;
        }

        private static bool RftCheckPerfectNumber2(int num)
        {
            int sum = 0;
            int i = 1;
            int n = num;

            while (i < n)
            {
                if (num % i == 0)
                {
                    sum += i + num / i;
                    n = num / i;
                }
                i++;
            }

            if (num == sum - num) return true;

            return false;
        }
    }
}
