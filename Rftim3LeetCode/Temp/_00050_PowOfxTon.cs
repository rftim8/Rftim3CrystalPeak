namespace Rftim3LeetCode.Temp
{
    public class _00050_PowOfxTon
    {
        /// <summary>
        /// Implement pow(x, n), which calculates x raised to the power n (i.e., xn).
        /// </summary>
        public _00050_PowOfxTon()
        {
            Console.WriteLine(PowOfxTon0(2, 10));
            Console.WriteLine(PowOfxTon0(2.1, 3));
            Console.WriteLine(PowOfxTon0(2, -3));
            Console.WriteLine(PowOfxTon0(0.00001, 2147483647));
        }

        public static double PowOfxTon0(double a0, int a1) => RftPowOfxTon0(a0, a1);

        private static double RftPowOfxTon0(double x, int n)
        {
            double result = 1;

            while (n != 0)
            {
                if (n % 2 == 0)
                {
                    x *= x;
                    n /= 2;
                }
                else
                {
                    result = n > 0 ? result * x : result / x;
                    if (n > 0) n--;
                    else n++;
                }
            }

            return result;
        }
    }
}
