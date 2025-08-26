namespace Rftim3LeetCode.Temp
{
    public class _00123_BestTimeToBuyAndSellStockIII
    {
        /// <summary>
        /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
        /// Find the maximum profit you can achieve.You may complete at most two transactions.
        /// Note: You may not engage in multiple transactions simultaneously(i.e., you must sell the stock before you buy again).
        /// </summary>
        public _00123_BestTimeToBuyAndSellStockIII()
        {
            Console.WriteLine(RftBestTimeToBuyAndSellStockIII0([3, 3, 5, 0, 0, 3, 1, 4]));
            Console.WriteLine(RftBestTimeToBuyAndSellStockIII0([1, 2, 3, 4, 5]));
            Console.WriteLine(RftBestTimeToBuyAndSellStockIII0([7, 6, 4, 3, 1]));
        }

        public static int BestTimeToBuyAndSellStockIII0(int[] a0) => RftBestTimeToBuyAndSellStockIII0(a0);

        public static int BestTimeToBuyAndSellStockIII1(int[] a0) => RftBestTimeToBuyAndSellStockIII1(a0);

        private static int RftBestTimeToBuyAndSellStockIII0(int[] prices)
        {
            int n = prices.Length;
            if (n == 0) return 0;

            int[,] r = new int[3, n];
            for (int i = 1; i < 3; i++)
            {
                int d = -prices[0];
                for (int j = 1; j < n; j++)
                {
                    r[i, j] = Math.Max(r[i, j - 1], prices[j] + d);
                    d = Math.Max(d, r[i - 1, j] - prices[j]);
                }
            }

            return r[2, n - 1];
        }

        private static int RftBestTimeToBuyAndSellStockIII1(int[] prices)
        {
            int cost1 = int.MaxValue;
            int cost2 = int.MaxValue;
            int profit1 = 0, profit2 = 0;

            foreach (int price in prices)
            {
                cost1 = Math.Min(cost1, price);
                profit1 = Math.Max(profit1, price - cost1);
                cost2 = Math.Min(cost2, price - profit1);
                profit2 = Math.Max(profit2, price - cost2);
            }

            return profit2;
        }
    }
}