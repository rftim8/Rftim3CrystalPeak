namespace Rftim3LeetCode.Temp
{
    public class _02218_MaximumValueOfKCoinsFromPiles
    {
        /// <summary>
        /// There are n piles of coins on a table. Each pile consists of a positive number of coins of assorted denominations.
        /// In one move, you can choose any coin on top of any pile, remove it, and add it to your wallet.
        /// Given a list piles, where piles[i] is a list of integers denoting the composition of the ith pile from top to bottom, 
        /// and a positive integer k, return the maximum total value of coins you can have in your wallet if you choose exactly k coins optimally.
        /// </summary>
        public _02218_MaximumValueOfKCoinsFromPiles()
        {
            Console.WriteLine(MaxValueOfCoins(
            [
                [ 1,100,3 ],
                [ 7,8,9 ]
            ], 2));

            Console.WriteLine(MaxValueOfCoins(
            [
                [ 100 ],
                [ 100 ],
                [ 100 ],
                [ 100 ],
                [ 100 ],
                [ 100 ],
                [ 1,1,1,1,1,1,700 ]
            ], 7));
        }

        private static int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            int n = piles.Count;
            int[][] dp = new int[n + 1][];

            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[k + 1];
            }

            for (int i = 1; i <= n; i++)
            {
                for (int coins = 0; coins <= k; coins++)
                {
                    int currentSum = 0;
                    for (int currentCoins = 0; currentCoins <= Math.Min(piles[i - 1].Count, coins); currentCoins++)
                    {
                        if (currentCoins > 0) currentSum += piles[i - 1][currentCoins - 1];

                        dp[i][coins] = Math.Max(dp[i][coins], dp[i - 1][coins - currentCoins] + currentSum);
                    }
                }
            }

            return dp[n][k];
        }

        private static int MaxValueOfCoins0(IList<IList<int>> piles, int k)
        {
            int n = piles.Count;
            int h = piles.Max(p => p.Count);
            int?[,] memo = new int?[n, k];
            int f(int x, int y)
            {
                if (x == n || y == k) return 0;
                if (memo[x, y].HasValue) return memo[x, y]!.Value;

                int max = f(x + 1, y);
                int sum = 0;
                for (int z = 0; y + z < k && z < piles[x].Count; z++)
                {
                    sum += piles[x][z];
                    max = Math.Max(max, sum + f(x + 1, y + z + 1));
                }
                memo[x, y] = max;

                return max;
            }

            return f(0, 0);
        }
    }
}
