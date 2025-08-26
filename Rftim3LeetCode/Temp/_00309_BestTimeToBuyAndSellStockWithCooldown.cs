namespace Rftim3LeetCode.Temp
{
    public class _00309_BestTimeToBuyAndSellStockWithCooldown
    {
        /// <summary>
        /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
        /// Find the maximum profit you can achieve.You may complete as many transactions as you like(i.e., 
        /// buy one and sell one share of the stock multiple times) with the following restrictions:
        /// After you sell your stock, you cannot buy stock on the next day(i.e., cooldown one day).
        /// Note: You may not engage in multiple transactions simultaneously(i.e., you must sell the stock before you buy again).
        /// </summary>
        public _00309_BestTimeToBuyAndSellStockWithCooldown()
        {
            Console.WriteLine(BestTimeToBuyAndSellStockWithCooldown0([1, 2, 3, 0, 2]));
            Console.WriteLine(BestTimeToBuyAndSellStockWithCooldown0([1]));
        }

        public static int BestTimeToBuyAndSellStockWithCooldown0(int[] a0) => RftBestTimeToBuyAndSellStockWithCooldown0(a0);

        private static int RftBestTimeToBuyAndSellStockWithCooldown0(int[] prices)
        {
            int n = prices.Length;
            if (n <= 1) return 0;
            if (n == 2) return Math.Max(0, prices[1] - prices[0]);

            int[] buy = new int[n];
            int[] sell = new int[n];

            buy[0] = -prices[0];
            sell[0] = 0;

            buy[1] = Math.Max(-prices[0], -prices[1]);
            sell[1] = Math.Max(0, prices[1] - prices[0]);

            for (int i = 2; i < n; i++)
            {
                buy[i] = Math.Max(buy[i - 1], sell[i - 2] - prices[i]);
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
            }

            return Math.Max(buy[n - 1], sell[n - 1]);
        }
    }
}