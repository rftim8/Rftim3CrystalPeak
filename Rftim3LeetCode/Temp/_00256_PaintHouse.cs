namespace Rftim3LeetCode.Temp
{
    public class _00256_PaintHouse
    {
        /// <summary>
        /// There is a row of n houses, where each house can be painted one of three colors: red, blue, or green. 
        /// The cost of painting each house with a certain color is different. 
        /// You have to paint all the houses such that no two adjacent houses have the same color.
        /// 
        /// The cost of painting each house with a certain color is represented by an n x 3 cost matrix costs.
        /// 
        /// For example, costs[0][0] is the cost of painting house 0 with the color red; 
        /// costs[1][2] is the cost of painting house 1 with color green, and so on...
        /// Return the minimum cost to paint all houses.
        /// </summary>
        public _00256_PaintHouse()
        {
            Console.WriteLine(PaintHouse0([[17, 2, 17], [16, 16, 5], [14, 3, 19]]));
            Console.WriteLine(PaintHouse0([[7, 6, 2]]));
        }

        public static int PaintHouse0(int[][] a0) => RftPaintHouse0(a0);

        public static int PaintHouse1(int[][] a0) => RftPaintHouse1(a0);

        public static int PaintHouse2(int[][] a0) => RftPaintHouse2(a0);

        // DP
        private static int RftPaintHouse0(int[][] costs)
        {
            for (int n = costs.Length - 2; n >= 0; n--)
            {
                costs[n][0] += Math.Min(costs[n + 1][1], costs[n + 1][2]);
                costs[n][1] += Math.Min(costs[n + 1][0], costs[n + 1][2]);
                costs[n][2] += Math.Min(costs[n + 1][0], costs[n + 1][1]);
            }

            if (costs.Length == 0) return 0;

            return Math.Min(Math.Min(costs[0][0], costs[0][1]), costs[0][2]);
        }

        // DP Space Optimized
        private static int RftPaintHouse1(int[][] costs)
        {

            if (costs.Length == 0) return 0;

            int[] previousRow = costs[^1];

            for (int n = costs.Length - 2; n >= 0; n--)
            {
                int m = costs[n].Length;
                int[] currentRow = new int[m];
                Array.Copy(costs[n], currentRow, m);
                currentRow[0] += Math.Min(previousRow[1], previousRow[2]);
                currentRow[1] += Math.Min(previousRow[0], previousRow[2]);
                currentRow[2] += Math.Min(previousRow[0], previousRow[1]);
                previousRow = currentRow;
            }

            return Math.Min(Math.Min(previousRow[0], previousRow[1]), previousRow[2]);
        }

        // Memoization
        private static int[][]? costs0;
        private static Dictionary<string, int>? memo;

        private static int RftPaintHouse2(int[][] costs)
        {
            if (costs.Length == 0) return 0;

            costs0 = costs;
            memo = [];

            return Math.Min(PaintCost(0, 0), Math.Min(PaintCost(0, 1), PaintCost(0, 2)));
        }

        private static int PaintCost(int n, int color)
        {
            if (memo!.ContainsKey(GetKey(n, color))) return memo[GetKey(n, color)];

            int totalCost = costs0![n][color];

            if (n == costs0.Length - 1) { }
            else if (color == 0) totalCost += Math.Min(PaintCost(n + 1, 1), PaintCost(n + 1, 2));
            else if (color == 1) totalCost += Math.Min(PaintCost(n + 1, 0), PaintCost(n + 1, 2));
            else totalCost += Math.Min(PaintCost(n + 1, 0), PaintCost(n + 1, 1));

            memo.Add(GetKey(n, color), totalCost);

            return totalCost;
        }

        private static string GetKey(int n, int color) => $"{n} {color}";
    }
}
