namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class AContributionByMinhtan143
    {
        public AContributionByMinhtan143()
        {
            List<int> x = [1, 8, 6, 2, 5, 4, 8, 3, 7];

            Console.WriteLine(RftSolve(x));
        }

        /// <summary>
        /// Given n non-negative integers a_1, a_2, ..., a_n, n vertical segments parallel with the y-axis, each vertical lines separated by a distance of 1. 
        /// Find 2 vertical lines which, with the x-axis, form a rectangular bucket, so that the container holds the most water. 
        /// Water will spill over the shorter of the two sides.
        /// 
        /// Example:
        /// 
        /// With arr = [1, 8, 6, 2, 5, 4, 8, 3, 7]
        /// 
        /// The bucket with the largest area is created by arr_2 = 8, arr_9 = 7 and x-axis with a max height that can hold water of 7 and the distance between them is 7. 
        /// So output is 7 * 7 = 49
        ///   |         |
        ///   |~ ~ ~ ~ ~|~ ~|
        ///   |~|~ ~ ~ ~|~ ~|
        ///   |~|~ ~|~ ~|~ ~|
        ///   |~|~ ~|~|~|~ ~|
        ///   |~|~ ~|~|~|~|~|
        ///   |~|~|~|~|~|~|~|
        /// |_|_|_|_|_|_|_|_|
        /// 
        /// You can create a taller bucket from arr_2 and arr_7, area is 8 * 5 = 40. But it doesn't hold the most area.
        /// </summary>
        /// <param name="x"></param>
        public static int RftSolve(List<int> x)
        {
            int area = int.MinValue;
            for (int i = 0; i < x.Count; i++)
            {
                for (int j = i + 1; j < x.Count; j++)
                {
                    area = Math.Max(Math.Min(x[i], x[j]) * (j - i), area);
                }
            }

            return area;
        }
    }
}
