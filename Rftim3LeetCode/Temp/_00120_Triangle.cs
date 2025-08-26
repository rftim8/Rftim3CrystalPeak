namespace Rftim3LeetCode.Temp
{
    public class _00120_Triangle
    {
        /// <summary>
        /// Given a triangle array, return the minimum path sum from top to bottom.
        /// For each step, you may move to an adjacent number of the row below.
        /// More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
        /// </summary>
        public _00120_Triangle()
        {
            Console.WriteLine(MinimumTotal(new List<IList<int>>()
            {
                new List<int>() {2},
                new List<int>() {3,4},
                new List<int>() {6,5,7},
                new List<int>() {4,1,8,3}
            }));

            Console.WriteLine(MinimumTotal(new List<IList<int>>()
            {
                new List<int>() {-10}
            }));
        }

        private static int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            if (n == 1) return triangle[0].Min();

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    if (j == 0) triangle[i][0] += triangle[i - 1][0];
                    else if (j == triangle[i].Count - 1) triangle[i][triangle[i].Count - 1] += triangle[i - 1].Last();
                    else triangle[i][j] += Math.Min(triangle[i - 1][j - 1], triangle[i - 1][j]);
                }
            }

            return triangle.Last().Min();
        }
    }
}
