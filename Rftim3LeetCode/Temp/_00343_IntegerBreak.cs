namespace Rftim3LeetCode.Temp
{
    public class _00343_IntegerBreak
    {
        /// <summary>
        /// Given an integer n, break it into the sum of k positive integers, where k >= 2, and maximize the product of those integers.
        /// Return the maximum product you can get.
        /// </summary>
        public _00343_IntegerBreak()
        {
            Console.WriteLine(IntegerBreak(2));
            Console.WriteLine(IntegerBreak(10));
        }

        private static int IntegerBreak(int n)
        {
            if (n == 2 || n == 3) return n - 1;

            int x = 1;
            while (n > 4)
            {
                n -= 3;
                x *= 3;
            }

            return n * x;
        }

        private static int IntegerBreak0(int n)
        {
            if (n == 2) return 1;

            int[] dp = new int[n + 1];
            dp[2] = 1;
            dp[3] = 2;

            for (int number = 4; number <= n; number++)
            {
                for (int i = 1; i <= number / 2; i++)
                {
                    int leftPart = Math.Max(dp[i], i);
                    int rightPart = Math.Max(dp[number - i], number - i);
                    dp[number] = Math.Max(dp[number], leftPart * rightPart);
                }
            }

            return dp[n];
        }

        private static int IntegerBreak1(int n)
        {
            if (n == 2) return 1;

            checked
            {
                int[] dp = new int[n + 1];

                dp[0] = 1;
                dp[1] = 1;
                dp[2] = 1;

                for (int i = 3; i <= n; i++)
                {
                    for (int j = 1; j < i; j++)
                    {
                        int prevProd = dp[i - j];
                        dp[i] = Math.Max(dp[i], j * (i - j));
                        dp[i] = Math.Max(dp[i], j * prevProd);
                    }
                }

                return dp[n];
            }
        }

        private static int IntegerBreak2(int n)
        {
            List<int> memo = new();
            for (int i = 0; i <= n + 1; i++)
            {
                memo.Add(0);
            }

            if (n <= 2) return 1;
            memo[1] = 0;
            memo[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    memo[i] = Math.Max(memo[i], Math.Max(j * (i - j), j * memo[i - j]));
                }
            }

            return memo[n];
        }
    }
}
