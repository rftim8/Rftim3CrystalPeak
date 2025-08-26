namespace Rftim3LeetCode.Temp
{
    public class _00322_CoinChange
    {
        /// <summary>
        /// You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
        /// Return the fewest number of coins that you need to make up that amount.
        /// If that amount of money cannot be made up by any combination of the coins, return -1.
        /// You may assume that you have an infinite number of each kind of coin.
        /// </summary>
        public _00322_CoinChange()
        {
            Console.WriteLine(CoinChange(new int[] { 1, 2, 5 }, 11));
            Console.WriteLine(CoinChange(new int[] { 2 }, 3));
            Console.WriteLine(CoinChange(new int[] { 1 }, 0));
        }

        private static int CoinChange(int[] coins, int amount)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            Array.Fill(dp, max);
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i) dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }

        private static int CoinChange0(int[] coins, int amount)
        {
            if (amount < 1) return 0;
            return CoinChange(coins, amount, new int[amount]);
        }

        private static int CoinChange(int[] coins, int rem, int[] count)
        {
            if (rem < 0) return -1;
            if (rem == 0) return 0;
            if (count[rem - 1] != 0) return count[rem - 1];

            int min = int.MaxValue;
            foreach (int coin in coins)
            {
                int res = CoinChange(coins, rem - coin, count);
                if (res >= 0 && res < min) min = 1 + res;
            }
            count[rem - 1] = min == int.MaxValue ? -1 : min;

            return count[rem - 1];
        }

        private static int CoinChange1(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            for (int i = 1; i < amount + 1; i++)
            {
                dp[i] = amount + 1;
            }
            dp[0] = 0;

            for (int i = 1; i < amount + 1; i++)
            {
                foreach (int coin in coins)
                {
                    if (i - coin >= 0) dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }

            if (dp[amount] != amount + 1) return dp[amount];

            return -1;
        }
    }
}
