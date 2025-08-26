namespace Rftim3LeetCode.Temp
{
    public class _00122_BestTimeToBuyAndSellStockII
    {
        /// <summary>
        /// You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
        /// On each day, you may decide to buy and/or sell the stock.You can only hold at most one share of the stock at any time.
        /// However, you can buy it then immediately sell it on the same day.
        /// Find and return the maximum profit you can achieve.
        /// </summary>
        public _00122_BestTimeToBuyAndSellStockII()
        {
            Console.WriteLine(BestTimeToBuyAndSellStockII0([7, 1, 5, 3, 6, 4]));
            Console.WriteLine(BestTimeToBuyAndSellStockII0([1, 2, 3, 4, 5]));
            Console.WriteLine(BestTimeToBuyAndSellStockII0([7, 6, 4, 3, 1]));
        }

        public static int BestTimeToBuyAndSellStockII0(int[] a0) => RftBestTimeToBuyAndSellStockII0(a0);

        private static int RftBestTimeToBuyAndSellStockII0(int[] prices)
        {
            int n = prices.Length;
            if (n == 1) return 0;
            int[] x = new int[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                x[i] = prices[i + 1] - prices[i];
            }

            int c = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (x[i] > 0) c += x[i];
            }

            return c;
        }
    }
}