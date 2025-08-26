namespace Rftim3LeetCode.Temp
{
    public class _00121_BestTimeToBuyAndSellStock
    {
        /// <summary>
        /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
        /// You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
        /// Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.
        /// </summary>
        public _00121_BestTimeToBuyAndSellStock()
        {

        }

        public static int BestTimeToBuyAndSellStock0(int[] a0) => RftBestTimeToBuyAndSellStock0(a0);

        private static int RftBestTimeToBuyAndSellStock0(int[] prices)
        {
            int n = prices.Length;

            int min = int.MaxValue;
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                if (prices[i] < min) min = prices[i];
                else if (prices[i] - min > max) max = prices[i] - min;
            }

            return max;
        }
    }
}