namespace Rftim3LeetCode.Temp
{
    public class _00135_Candy
    {
        /// <summary>
        /// There are n children standing in a line. 
        /// Each child is assigned a rating value given in the integer array ratings.
        /// You are giving candies to these children subjected to the following requirements:
        /// Each child must have at least one candy.
        /// Children with a higher rating get more candies than their neighbors.
        /// Return the minimum number of candies you need to have to distribute the candies to the children.
        /// </summary>
        public _00135_Candy()
        {
            Console.WriteLine(Candy([1, 0, 2]));
            Console.WriteLine(Candy([1, 2, 2]));
        }

        private static int Candy(int[] ratings)
        {
            int n = ratings.Length;
            int[] candies = Enumerable.Repeat(1, n).ToArray();

            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1]) candies[i] = candies[i - 1] + 1;
            }

            for (int i = n - 2; i > -1; i--)
            {
                if (ratings[i] > ratings[i + 1]) candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }

            return candies.Sum();
        }
    }
}
