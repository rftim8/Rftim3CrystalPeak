namespace Rftim3LeetCode.Temp
{
    public class _01837_SumOfDigitsInBaseK
    {
        /// <summary>
        /// Given an integer n (in base 10) and a base k, return the sum of the digits of n after converting n from base 10 to base k.
        /// After converting, each digit should be interpreted as a base 10 number, and the sum should be returned in base 10.
        /// </summary>
        public _01837_SumOfDigitsInBaseK()
        {
            Console.WriteLine(SumBase(34, 6));
            Console.WriteLine(SumBase(10, 10));
        }

        private static int SumBase(int n, int k)
        {
            int r = 0;
            while (n > 0)
            {
                int bk = n % k;
                r += bk;
                n /= k;
            }

            return r;
        }
    }
}
