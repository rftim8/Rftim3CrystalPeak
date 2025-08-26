namespace Rftim3LeetCode.Temp
{
    public class _02706_BuyTwoChocolates
    {
        /// <summary>
        /// You are given an integer array prices representing the prices of various chocolates in a store. 
        /// You are also given a single integer money, which represents your initial amount of money.
        /// You must buy exactly two chocolates in such a way that you still have some non-negative leftover money.
        /// You would like to minimize the sum of the prices of the two chocolates you buy.
        /// Return the amount of money you will have leftover after buying the two chocolates.
        /// If there is no way for you to buy two chocolates without ending up in debt, return money.
        /// Note that the leftover must be non-negative.
        /// </summary>
        public _02706_BuyTwoChocolates()
        {
            Console.WriteLine(BuyChoco([1, 2, 2], 3));
            Console.WriteLine(BuyChoco([3, 2, 3], 3));
        }

        private static int BuyChoco(int[] prices, int money)
        {
            Array.Sort(prices);

            if (prices[0] + prices[1] <= money) return money - (prices[0] + prices[1]);
            else return money;
        }
    }
}
