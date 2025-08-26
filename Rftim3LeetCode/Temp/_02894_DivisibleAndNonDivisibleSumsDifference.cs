namespace Rftim3LeetCode.Temp
{
    public class _02894_DivisibleAndNonDivisibleSumsDifference
    {
        /// <summary>
        /// You are given positive integers n and m.
        /// 
        /// Define two integers, num1 and num2, as follows:
        /// 
        /// num1: The sum of all integers in the range[1, n] that are not divisible by m.
        /// num2: The sum of all integers in the range [1, n] that are divisible by m.
        /// Return the integer num1 - num2.
        /// </summary>
        public _02894_DivisibleAndNonDivisibleSumsDifference()
        {
            Console.WriteLine(DifferenceOfSums0(10, 3));
            Console.WriteLine(DifferenceOfSums0(5, 6));
            Console.WriteLine(DifferenceOfSums0(5, 1));
        }

        public static int DifferenceOfSums0(int a0, int a1) => RftDifferenceOfSums0(a0, a1);

        public static int DifferenceOfSums1(int a0, int a1) => RftDifferenceOfSums1(a0, a1);

        private static int RftDifferenceOfSums0(int n, int m)
        {
            HashSet<int> r = [.. Enumerable.Range(1, n)];

            int t = n / m;
            int a0 = 0;
            for (int i = 1; i <= t; i++)
            {
                int q = i * m;
                r.Remove(q);
                a0 += q;
            }

            return r.Sum() - a0;
        }

        private static int RftDifferenceOfSums1(int n, int m)
        {
            int a0 = 0;
            int a1 = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % m == 0) a0 += i;
                else a1 += i;
            }

            int r = a1 - a0;

            return r;
        }
    }
}
