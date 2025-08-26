namespace Rftim3LeetCode.Temp
{
    public class _01952_ThreeDivisors
    {
        /// <summary>
        /// Given an integer n, return true if n has exactly three positive divisors. 
        /// Otherwise, return false.
        /// An integer m is a divisor of n if there exists an integer k such that n = k * m.
        /// </summary>
        public _01952_ThreeDivisors()
        {
            Console.WriteLine(IsThree(2));
            Console.WriteLine(IsThree(4));
        }

        private static bool IsThree(int n)
        {
            int c = 0;

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) c++;
                if (c > 3) return false;
            }

            return c == 3;
        }
    }
}
