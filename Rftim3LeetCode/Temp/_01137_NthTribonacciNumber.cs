namespace Rftim3LeetCode.Temp
{
    public class _01137_NthTribonacciNumber
    {
        /// <summary>
        /// The Tribonacci sequence Tn is defined as follows: 
        /// T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.
        /// Given n, return the value of Tn.
        /// </summary>
        public _01137_NthTribonacciNumber()
        {
            Console.WriteLine(Tribonacci0(4));
            Console.WriteLine(Tribonacci0(25));
        }

        private static int Tribonacci(int n, int f0 = 0, int f1 = 1, int f2 = 1)
        {
            if (n == 0) return 0;
            if (n <= 2) return 1;
            if (n - 4 < 0) return f0 + f1 + f2;
            else return Tribonacci(n - 1, f1, f2, f0 + f1 + f2);
        }

        private static int Tribonacci0(int n)
        {
            if (n == 0) return 0;
            if (n <= 2) return 1;

            int a = 0, b = 1, c = 1, d = 2;
            for (int i = 2; i < n; i++)
            {
                d = a + b + c;
                a = b;
                b = c;
                c = d;
            }

            return d;
        }
    }
}
