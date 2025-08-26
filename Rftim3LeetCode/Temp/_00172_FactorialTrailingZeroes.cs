namespace Rftim3LeetCode.Temp
{
    public class _00172_FactorialTrailingZeroes
    {
        /// <summary>
        /// Given an integer n, return the number of trailing zeroes in n!.
        /// Note that n! = n* (n - 1) * (n - 2) * ... * 3 * 2 * 1.
        /// </summary>
        public _00172_FactorialTrailingZeroes()
        {
            Console.WriteLine(TrailingZeroes(3));
            Console.WriteLine(TrailingZeroes(5));
            Console.WriteLine(TrailingZeroes(0));
        }

        private static int TrailingZeroes(int n)
        {
            int c = 0;

            while (n > 0)
            {
                c += n / 5;
                n /= 5;
            }

            return c;
        }
    }
}
