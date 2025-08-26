namespace Rftim3LeetCode.Temp
{
    public class _00204_CountPrimes
    {
        /// <summary>
        /// Given an integer n, return the number of prime numbers that are strictly less than n.
        /// </summary>
        public _00204_CountPrimes()
        {
            Console.WriteLine(CountPrimes0(10));
            Console.WriteLine(CountPrimes0(0));
            Console.WriteLine(CountPrimes0(1));
            Console.WriteLine(CountPrimes0(461465));
        }

        public static int CountPrimes0(int a0) => RftCountPrimes0(a0);

        public static int CountPrimes1(int a0) => RftCountPrimes1(a0);

        // Brute Force TLE
        private static int RftCountPrimes0(int n)
        {
            int res = 0;

            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i)) res++;
            }

            return res;
        }

        private static bool IsPrime(int num)
        {
            if (num == 1) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        // Sieve of Eratosthenes
        private static int RftCountPrimes1(int n)
        {
            if (n <= 2) return 0;

            bool[] numbers = new bool[n];
            for (int p = 2; p <= (int)Math.Sqrt(n); ++p)
            {
                if (numbers[p] == false)
                {
                    for (int j = p * p; j < n; j += p)
                    {
                        numbers[j] = true;
                    }
                }
            }

            int numberOfPrimes = 0;
            for (int i = 2; i < n; i++)
            {
                if (numbers[i] == false) ++numberOfPrimes;
            }

            return numberOfPrimes;
        }
    }
}
