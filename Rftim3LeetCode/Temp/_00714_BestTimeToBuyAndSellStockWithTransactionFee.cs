namespace Rftim3LeetCode.Temp
{
    public class _00714_BestTimeToBuyAndSellStockWithTransactionFee
    {
        /// <summary>
        /// You are given an array prices where prices[i] is the price of a given stock on the ith day, and an integer fee representing a transaction fee.
        /// Find the maximum profit you can achieve.You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.
        /// Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
        /// </summary>
        public _00714_BestTimeToBuyAndSellStockWithTransactionFee()
        {
            Console.WriteLine(MaxProfit([1, 3, 2, 8, 4, 9], 2));
            Console.WriteLine(MaxProfit([1, 3, 7, 5, 10, 3], 3));
        }

        private static int MaxProfit(int[] prices, int fee)
        {
            int n = prices.Length;
            int profit = 0, hold = -prices[0];

            for (int i = 1; i < n; i++)
            {
                int tmp = hold;
                hold = Math.Max(hold, profit - prices[i]);
                profit = Math.Max(profit, tmp + prices[i] - fee);
            }

            return profit;
        }
    }
}
