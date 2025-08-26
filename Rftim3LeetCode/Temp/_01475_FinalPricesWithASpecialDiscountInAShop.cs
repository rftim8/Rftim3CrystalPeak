using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01475_FinalPricesWithASpecialDiscountInAShop
    {
        /// <summary>
        /// You are given an integer array prices where prices[i] is the price of the ith item in a shop.
        /// There is a special discount for items in the shop.If you buy the ith item, then you will receive a discount 
        /// equivalent to prices[j] where j is the minimum index such that j > i and prices[j] <= prices[i]. 
        /// Otherwise, you will not receive any discount at all.
        /// Return an integer array answer where answer[i] is the final price you will pay for the ith item of the shop, considering the special discount.
        /// </summary>
        public _01475_FinalPricesWithASpecialDiscountInAShop()
        {
            int[] x = FinalPrices([8, 4, 6, 2, 3]);
            int[] x0 = FinalPrices([1, 2, 3, 4, 5]);
            int[] x1 = FinalPrices([10, 1, 1, 6]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] FinalPrices(int[] prices)
        {
            int n = prices.Length;
            if (n == 1) return prices;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (prices[j] <= prices[i])
                    {
                        prices[i] -= prices[j];
                        break;
                    }
                }
            }

            return prices;
        }
    }
}
