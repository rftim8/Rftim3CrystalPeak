namespace Rftim3LeetCode.Temp
{
    public class _01175_PrimeArrangements
    {
        /// <summary>
        /// Return the number of permutations of 1 to n so that prime numbers are at prime indices (1-indexed.)
        /// (Recall that an integer is prime if and only if it is greater than 1, and cannot be written as a product of two positive integers both smaller than it.)
        /// Since the answer may be large, return the answer modulo 10^9 + 7.
        /// </summary>
        public _01175_PrimeArrangements()
        {
            Console.WriteLine(NumPrimeArrangements(5));
            Console.WriteLine(NumPrimeArrangements(100));
        }

        private static int NumPrimeArrangements(int n)
        {
            static bool IsPrime(int num)
            {
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0) return false;
                }

                return true;
            }

            int mod = (int)Math.Pow(10, 9) + 7;

            int count = 0;
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i)) count++;
            }

            long res = 1;
            for (int i = count; i > 0; i--)
            {
                res = res * i % mod;
                res %= mod;
            }

            for (int i = n - count; i > 0; i--)
            {

                res = res * i % mod;
                res %= mod;
            }

            return (int)res;
        }

        private static int NumPrimeArrangements0(int n)
        {
            int countPrimes = 0, mod = 1000000007;

            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;
                int ub = (int)Math.Sqrt(i);
                for (int j = 2; j <= ub; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) countPrimes++;
            }

            return (int)(Fact(countPrimes) * Fact(n - countPrimes) % mod);
        }

        private static long Fact(int n)
        {
            long res = 1;
            for (int i = 2; i <= n; i++)
            {
                res *= i;
                res %= 1000000007;
            }

            return res;
        }
    }
}
