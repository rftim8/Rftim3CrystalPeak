namespace Rftim3LeetCode.Temp
{
    public class _02144_MinimumCostOfBuyingCandiesWithDiscount
    {
        /// <summary>
        /// A shop is selling candies at a discount. 
        /// For every two candies sold, the shop gives a third candy for free.
        /// The customer can choose any candy to take away for free as long as the cost of the chosen candy is less than or equal to the minimum cost of the two candies bought.
        /// For example, if there are 4 candies with costs 1, 2, 3, and 4, and the customer buys candies with costs 2 and 3, 
        /// they can take the candy with cost 1 for free, but not the candy with cost 4.
        /// Given a 0-indexed integer array cost, where cost[i] denotes the cost of the ith candy, return the minimum cost of buying all the candies.
        /// </summary>
        public _02144_MinimumCostOfBuyingCandiesWithDiscount()
        {
            Console.WriteLine(MinimumCost([1, 2, 3]));
            Console.WriteLine(MinimumCost([6, 5, 7, 9, 2, 2]));
            Console.WriteLine(MinimumCost([5, 5]));
            Console.WriteLine(MinimumCost([10, 5, 9, 4, 1, 9, 10, 2, 10, 8]));
        }

        private static int MinimumCost(int[] cost)
        {
            int n = cost.Length;
            Array.Sort(cost);

            int j = 0, c = 0;
            for (int i = n - 1; i > -1; i--)
            {
                if (j == 2)
                {
                    j = 0;
                    continue;
                }
                else c += cost[i];

                j++;
            }

            return c;
        }
    }
}
