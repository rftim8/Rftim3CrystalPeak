namespace Rftim3LeetCode.Temp
{
    public class _00265_PaintHouseII
    {
        /// <summary>
        /// There are a row of n houses, each house can be painted with one of the k colors. 
        /// The cost of painting each house with a certain color is different. 
        /// You have to paint all the houses such that no two adjacent houses have the same color.
        /// 
        /// The cost of painting each house with a certain color is represented by an n x k cost matrix costs.
        /// 
        /// For example, costs[0][0] is the cost of painting house 0 with color 0; 
        /// costs[1][2] is the cost of painting house 1 with color 2, and so on...
        /// Return the minimum cost to paint all houses.
        /// </summary>
        public _00265_PaintHouseII()
        {
            Console.WriteLine(PaintHouseII0([[1, 5, 3], [2, 9, 4]]));
            Console.WriteLine(PaintHouseII0([[1, 3], [2, 4]]));
        }

        public static int PaintHouseII0(int[][] a0) => RftPaintHouseII0(a0);

        public static int PaintHouseII1(int[][] a0) => RftPaintHouseII1(a0);

        public static int PaintHouseII2(int[][] a0) => RftPaintHouseII2(a0);

        // DP
        private static int RftPaintHouseII0(int[][] costs)
        {
            if (costs.Length == 0) return 0;

            int k = costs[0].Length;
            int n = costs.Length;
            int[] previousRow = costs[0];

            int min;
            for (int house = 1; house < n; house++)
            {
                int[] currentRow = new int[k];
                for (int color = 0; color < k; color++)
                {
                    min = int.MaxValue;
                    for (int previousColor = 0; previousColor < k; previousColor++)
                    {
                        if (color == previousColor) continue;
                        min = Math.Min(min, previousRow[previousColor]);
                    }
                    currentRow[color] += costs[house][color] += min;
                }
                previousRow = currentRow;
            }

            min = int.MaxValue;
            foreach (int c in previousRow)
            {
                min = Math.Min(min, c);
            }

            return min;
        }

        // DP Optimized Time
        private static int RftPaintHouseII1(int[][] costs)
        {

            if (costs.Length == 0) return 0;

            int k = costs[0].Length;
            int n = costs.Length;

            for (int house = 1; house < n; house++)
            {
                int minColor = -1; int secondMinColor = -1;
                for (int color = 0; color < k; color++)
                {
                    int cost = costs[house - 1][color];
                    if (minColor == -1 || cost < costs[house - 1][minColor])
                    {
                        secondMinColor = minColor;
                        minColor = color;
                    }
                    else if (secondMinColor == -1 || cost < costs[house - 1][secondMinColor]) secondMinColor = color;
                }

                for (int color = 0; color < k; color++)
                {
                    if (color == minColor) costs[house][color] += costs[house - 1][secondMinColor];
                    else costs[house][color] += costs[house - 1][minColor];
                }
            }

            int min = int.MaxValue;
            foreach (int c in costs[n - 1])
            {
                min = Math.Min(min, c);
            }

            return min;
        }

        // DP Otimize Time and Space
        private static int RftPaintHouseII2(int[][] costs)
        {

            if (costs.Length == 0) return 0;

            int k = costs[0].Length;
            int n = costs.Length;

            int prevMin = -1, prevSecondMin = -1, prevMinColor = -1;
            for (int color = 0; color < k; color++)
            {
                int cost = costs[0][color];
                if (prevMin == -1 || cost < prevMin)
                {
                    prevSecondMin = prevMin;
                    prevMinColor = color;
                    prevMin = cost;
                }
                else if (prevSecondMin == -1 || cost < prevSecondMin) prevSecondMin = cost;
            }

            for (int house = 1; house < n; house++)
            {
                int min = -1; int secondMin = -1; int minColor = -1;
                for (int color = 0; color < k; color++)
                {
                    int cost = costs[house][color];
                    if (color == prevMinColor) cost += prevSecondMin;
                    else cost += prevMin;

                    if (min == -1 || cost < min)
                    {
                        secondMin = min;
                        minColor = color;
                        min = cost;
                    }
                    else if (secondMin == -1 || cost < secondMin) secondMin = cost;
                }

                prevMin = min;
                prevSecondMin = secondMin;
                prevMinColor = minColor;
            }

            return prevMin;
        }
    }
}
