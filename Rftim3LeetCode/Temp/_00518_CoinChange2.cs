namespace Rftim3LeetCode.Temp
{
    public class _00518_CoinChange2
    {
        /// <summary>
        /// You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
        /// Return the number of combinations that make up that amount.If that amount of money cannot be made up by any combination of the coins, return 0.
        /// You may assume that you have an infinite number of each kind of coin.
        /// The answer is guaranteed to fit into a signed 32-bit integer.
        /// </summary>
        public _00518_CoinChange2()
        {
            Console.WriteLine(Change(5, [1, 2, 5]));
            Console.WriteLine(Change(3, [2]));
            Console.WriteLine(Change(10, [10]));
        }

        private static int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 1;

            for (int j = 0; j < coins.Length; j++)
            {
                for (int i = coins[j]; i <= amount; i++)
                {
                    dp[i] += dp[i - coins[j]];
                }
            }

            return dp[amount];
        }
    }
}
