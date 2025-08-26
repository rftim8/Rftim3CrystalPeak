namespace Rftim3LeetCode.Temp
{
    public class CalculateEntropy
    {
        /// <summary>
        /// Given a group of values, the entropy of the group is defined as the formula as following:
        /// Sum(from i = 1 to n) of P(xi) * log(base 2) of P(xi) * P(xi)
        /// where P(x) is the probability of appearance for the value x.
        /// The exercise is to calculate the entropy of a group.Here is one example.
        /// the input group:  [1, 1, 2, 2]
        /// the probability of value 1 is  2/4 = 1/2
        /// the probability of value 2 is  2/4 = 1/2
        /// As a result, its entropy can be obtained by:  - (1/2) * log2(1/2) - (1/2) * log2(1/2) = 1/2 + 1/2 = 1
        /// Note: the precision of result would remain within 1e-6.
        /// </summary>
        public CalculateEntropy()
        {
            Console.WriteLine(CalculateEntropy0([1, 1, 2, 2]));
            Console.WriteLine(CalculateEntropy0([1, 2, 3, 4, 5, 6]));
        }

        public static double CalculateEntropy0(int[] a0) => RftCalculateEntropy0(a0);

        private static double RftCalculateEntropy0(int[] input)
        {
            double x = 0;
            int n = input.Length;
            if (n == 0 || input.Distinct().Count() == 1) return 0;

            Array.Sort(input);
            int c = input[0];
            int t = 1;
            for (int i = 1; i < n; i++)
            {
                if (input[i] == c) t++;
                else
                {
                    x -= (double)t / n * Math.Log2((double)t / n);
                    c = input[i];
                    t = 1;
                }
                if (i == n - 1) x -= (double)t / n * Math.Log2((double)t / n);
            }

            return x;
        }
    }
}
