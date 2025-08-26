namespace Rftim3LeetCode.Temp
{
    public class _02652_SumMultiples
    {
        /// <summary>
        /// Given a positive integer n, find the sum of all integers in the range [1, n] inclusive that are divisible by 3, 5, or 7.
        /// Return an integer denoting the sum of all numbers in the given range satisfying the constraint.
        /// </summary>
        public _02652_SumMultiples()
        {
            Console.WriteLine(SumOfMultiples(7));
            Console.WriteLine(SumOfMultiples(10));
            Console.WriteLine(SumOfMultiples(9));
        }

        private static int SumOfMultiples(int n)
        {
            int c = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0) c += i;
            }

            return c;
        }
    }
}
