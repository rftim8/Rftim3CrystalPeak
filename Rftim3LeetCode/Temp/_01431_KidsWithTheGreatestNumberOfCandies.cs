using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01431_KidsWithTheGreatestNumberOfCandies
    {
        /// <summary>
        /// There are n kids with candies. You are given an integer array candies, where each candies[i] represents the number of candies the ith kid has, 
        /// and an integer extraCandies, denoting the number of extra candies that you have.
        /// Return a boolean array result of length n, where result[i] is true if, after giving the ith kid all the extraCandies, 
        /// they will have the greatest number of candies among all the kids, or false otherwise.
        /// Note that multiple kids can have the greatest number of candies.
        /// </summary>
        public _01431_KidsWithTheGreatestNumberOfCandies()
        {
            IList<bool> x0 = KidsWithCandies([2, 3, 5, 1, 3], 3);
            IList<bool> x1 = KidsWithCandies([4, 2, 1, 1, 2], 1);
            IList<bool> x2 = KidsWithCandies([12, 1, 12], 10);

            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
            RftTerminal.RftReadResult(x2);
        }

        private static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int n = candies.Length;

            int y = -1;
            for (int i = 0; i < n; i++)
            {
                if (candies[i] > y) y = candies[i];
            }

            bool[] x = new bool[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = candies[i] + extraCandies >= y;
            }

            return x;
        }
    }
}
