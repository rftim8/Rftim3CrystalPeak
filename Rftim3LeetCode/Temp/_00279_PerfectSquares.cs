namespace Rftim3LeetCode.Temp
{
    public class _00279_PerfectSquares
    {
        /// <summary>
        /// Given an integer n, return the least number of perfect square numbers that sum to n.
        /// A perfect square is an integer that is the square of an integer; in other words, it is the product of some integer with itself.
        /// For example, 1, 4, 9, and 16 are perfect squares while 3 and 11 are not.
        /// </summary>
        public _00279_PerfectSquares()
        {
            Console.WriteLine(NumSquares(12));
            Console.WriteLine(NumSquares(13));
        }

        private static int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                dp[i] = int.MaxValue;
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }

            return dp[n];
        }

        private static int NumSquares0(int n)
        {
            while (n % 4 == 0)
            {
                n /= 4;
            }

            if (n % 8 == 7) return 4;

            if (IsSquare(n)) return 1;

            for (int i = 1; i * i <= n; ++i)
            {
                if (IsSquare(n - i * i)) return 2;
            }

            return 3;
        }

        private static bool IsSquare(int n)
        {
            int sq = (int)Math.Sqrt(n);

            return n == sq * sq;
        }
    }
}
