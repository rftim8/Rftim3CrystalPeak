namespace Rftim3LeetCode.Temp
{
    public class _00509_FibonacciNumber
    {
        /// <summary>
        /// The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, 
        /// such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,
        /// </summary>
        public _00509_FibonacciNumber()
        {
            Console.WriteLine(Fib0(2));
            Console.WriteLine(Fib0(3));
            Console.WriteLine(Fib0(4));
        }

        public static int Fib0(int a0) => RftFib0(a0);

        private static int RftFib0(int n)
        {
            if (n < 2) return n;
            else return RftFib0(n - 1) + RftFib0(n - 2);
        }
    }
}
