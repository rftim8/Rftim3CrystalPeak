namespace Rftim3LeetCode.Temp
{
    public class _00188_BestTimetoBuyandSellStockIV
    {
        /// <summary>
        /// You are given an integer array prices where prices[i] is 
        /// the price of a given stock on the ith day, and an integer k.
        /// 
        /// Find the maximum profit you can achieve.
        /// You may complete at most k transactions: i.e.you may buy at most k times and sell 
        /// at most k times.
        /// 
        /// Note: You may not engage in multiple transactions simultaneously(i.e., 
        /// you must sell the stock before you buy again).
        /// </summary>
        public _00188_BestTimetoBuyandSellStockIV()
        {
            Console.WriteLine(BestTimetoBuyandSellStockIV0(2, [2, 4, 1]));
            Console.WriteLine(BestTimetoBuyandSellStockIV0(2, [3, 2, 6, 5, 0, 3]));
        }

        public static int BestTimetoBuyandSellStockIV0(int a0, int[] a1) => RftBestTimetoBuyandSellStockIV0(a0, a1);

        public static int BestTimetoBuyandSellStockIV1(int a0, int[] a1) => RftBestTimetoBuyandSellStockIV1(a0, a1);

        public static int BestTimetoBuyandSellStockIV2(int a0, int[] a1) => RftBestTimetoBuyandSellStockIV2(a0, a1);

        private static int RftBestTimetoBuyandSellStockIV0(int k, int[] prices)
        {
            int n = prices.Length;
            int res = 0;

            if (n <= 0 || k <= 0) return 0;

            if (k / 2 > n)
            {
                for (int i = 1; i < n; i++)
                {
                    res += Math.Max(0, prices[i] - prices[i - 1]);
                }

                return res;
            }

            int[][][] dp = new int[n][][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[k + 1][];
                for (int j = 0; j < k + 1; j++)
                {
                    dp[i][j] = new int[2];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    dp[i][j][0] = -1000000000;
                    dp[i][j][1] = -1000000000;
                }
            }

            dp[0][0][0] = 0;
            dp[0][1][1] = -prices[0];

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    dp[i][j][0] = Math.Max(dp[i - 1][j][0], dp[i - 1][j][1] + prices[i]);
                    if (j > 0) dp[i][j][1] = Math.Max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i]);
                }
            }

            res = 0;
            for (int j = 0; j <= k; j++)
            {
                res = Math.Max(res, dp[n - 1][j][0]);
            }

            return res;
        }

        private static int RftBestTimetoBuyandSellStockIV1(int k, int[] prices)
        {
            int n = prices.Length;

            if (n <= 0 || k <= 0) return 0;

            List<int[]> transactions = [];
            int start = 0;
            int end = 0;
            for (int i = 1; i < n; i++)
            {
                if (prices[i] >= prices[i - 1]) end = i;
                else
                {
                    if (end > start)
                    {
                        int[] t = [start, end];
                        transactions.Add(t);
                    }
                    start = i;
                }
            }
            if (end > start)
            {
                int[] t = [start, end];
                transactions.Add(t);
            }

            while (transactions.Count > k)
            {
                int delete_index = 0;
                int min_delete_loss = int.MaxValue;
                for (int i = 0; i < transactions.Count; i++)
                {
                    int[] t = transactions[i];
                    int profit_loss = prices[t[1]] - prices[t[0]];
                    if (profit_loss < min_delete_loss)
                    {
                        min_delete_loss = profit_loss;
                        delete_index = i;
                    }
                }

                int merge_index = 0;
                int min_merge_loss = int.MaxValue;
                for (int i = 1; i < transactions.Count; i++)
                {
                    int[] t1 = transactions[i - 1];
                    int[] t2 = transactions[i];
                    int profit_loss = prices[t1[1]] - prices[t2[0]];
                    if (profit_loss < min_merge_loss)
                    {
                        min_merge_loss = profit_loss;
                        merge_index = i;
                    }
                }

                if (min_delete_loss <= min_merge_loss) transactions.RemoveAt(delete_index);
                else
                {
                    int[] t1 = transactions[merge_index - 1];
                    int[] t2 = transactions[merge_index];
                    t1[1] = t2[1];
                    transactions.RemoveAt(merge_index);
                }

            }

            int res = 0;
            foreach (int[] t in transactions)
            {
                res += prices[t[1]] - prices[t[0]];
            }

            return res;
        }

        private static int RftBestTimetoBuyandSellStockIV2(int k, int[] prices)
        {
            return MaxProfitBottomUpTabulation(k, prices);
        }

        private static int MaxProfitBottomUpTabulation(int k, int[] prices)
        {
            int[][] dp = new int[k][];

            for (int i = 0; i < k; i++)
            {
                dp[i] = new int[prices.Length];
                int maxDiff = -prices[0];
                for (int j = 1; j < prices.Length; j++)
                {
                    int profitNoOp = dp[i][j - 1];
                    int profitSell = prices[j] + maxDiff;

                    dp[i][j] = Math.Max(profitNoOp, profitSell);

                    int currDiff = (i == 0 ? 0 : dp[i - 1][j]) - prices[j];
                    maxDiff = Math.Max(currDiff, maxDiff);
                }
            }

            return dp[k - 1][prices.Length - 1];
        }

        private int MaxProfitTopDownRecc(int k, int[] prices)
        {
            Dictionary<(int, int, bool), int> cache = [];

            return Helper(prices, 0, k, true, cache);
        }

        private static int Helper(
            int[] prices,
            int index,
            int k,
            bool buy,
            Dictionary<(int, int, bool), int> cache
        )
        {
            if (index >= prices.Length || k <= 0) return 0;

            if (cache.ContainsKey((index, k, buy))) return cache[(index, k, buy)];
            if (buy)
            {
                int priceBuy = -prices[index] + Helper(prices, index + 1, k, false, cache);
                int priceNoOp = 0 + Helper(prices, index + 1, k, buy, cache);

                cache[(index, k, buy)] = Math.Max(priceBuy, priceNoOp);
            }
            else
            {
                int priceSell = prices[index] + Helper(prices, index + 1, k - 1, true, cache);
                int priceNoOp = 0 + Helper(prices, index + 1, k, buy, cache);

                cache[(index, k, buy)] = Math.Max(priceSell, priceNoOp);
            }

            return cache[(index, k, buy)];
        }
    }
}
