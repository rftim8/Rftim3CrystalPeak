namespace Rftim3LeetCode.Temp
{
    public class _00264_UglyNumber2
    {
        /// <summary>
        /// An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.
        /// Given an integer n, return the nth ugly number.
        /// </summary>
        public _00264_UglyNumber2()
        {
            Console.WriteLine(NthUglyNumber(11));
            Console.WriteLine(NthUglyNumber(10));
            Console.WriteLine(NthUglyNumber(1));
        }

        private static int NthUglyNumber(int n)
        {
            int[] x = new int[n];
            x[0] = 1;
            int p2 = 0, p3 = 0, p5 = 0;

            for (int i = 1; i < n; i++)
            {
                int n1 = 2 * x[p2];
                int n2 = 3 * x[p3];
                int n3 = 5 * x[p5];

                x[i] = Math.Min(n1, Math.Min(n2, n3));

                if (n1 == x[i]) p2++;
                if (n2 == x[i]) p3++;
                if (n3 == x[i]) p5++;
            }

            return x[n - 1];
        }
    }
}
