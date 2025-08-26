namespace Rftim3LeetCode.Temp
{
    public class _00633_SumOfSquaresNumbers
    {
        /// <summary>
        /// Given a non-negative integer c, decide whether there're two integers a and b such that a2 + b2 = c.
        /// </summary>
        public _00633_SumOfSquaresNumbers()
        {
            Console.WriteLine(JudgeSquareSum(5));
            Console.WriteLine(JudgeSquareSum(4));
            Console.WriteLine(JudgeSquareSum(3));
            Console.WriteLine(JudgeSquareSum(2));
            Console.WriteLine(JudgeSquareSum(1));
            Console.WriteLine(JudgeSquareSum(0));
        }

        private static bool JudgeSquareSum(int c)
        {
            for (long a = 0; a * a <= c; a++)
            {
                double b = Math.Sqrt(c - a * a);
                if (b == (int)b) return true;
            }

            return false;
        }

        private static bool JudgeSquareSum0(int c)
        {
            for (long a = 0; a * a <= c; a++)
            {
                int b = c - (int)(a * a);
                if (BinarySearch(0, b, b)) return true;
            }

            return false;
        }

        private static bool BinarySearch(long s, long e, int n)
        {
            if (s > e) return false;

            long mid = s + (e - s) / 2;

            if (mid * mid == n) return true;
            if (mid * mid > n) return BinarySearch(s, mid - 1, n);

            return BinarySearch(mid + 1, e, n);
        }

        private static bool JudgeSquareSum1(int c)
        {
            for (int i = 2; i * i <= c; i++)
            {
                int count = 0;
                if (c % i == 0)
                {
                    while (c % i == 0)
                    {
                        count++;
                        c /= i;
                    }
                    if (i % 4 == 3 && count % 2 != 0) return false;
                }
            }

            return c % 4 != 3;
        }
    }
}
