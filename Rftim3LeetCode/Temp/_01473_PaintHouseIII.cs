namespace Rftim3LeetCode.Temp
{
    public class _01473_PaintHouseIII
    {
        /// <summary>
        /// There is a row of m houses in a small city, each house must be painted with one of the n colors (labeled from 1 to n), 
        /// some houses that have been painted last summer should not be painted again.
        /// 
        /// A neighborhood is a maximal group of continuous houses that are painted with the same color.
        /// 
        /// For example: houses = [1,2,2,3,3,2,1,1] contains 5 neighborhoods[{1}, {2,2}, { 3,3}, { 2}, { 1,1}].
        /// Given an array houses, an m x n matrix cost and an integer target where:
        /// 
        /// houses[i]: is the color of the house i, and 0 if the house is not painted yet.
        /// cost[i][j]: is the cost of paint the house i with the color j + 1.
        /// Return the minimum cost of painting all the remaining houses in such a way that there are exactly target neighborhoods. 
        /// If it is not possible, return -1.
        /// </summary>
        public _01473_PaintHouseIII()
        {
            Console.WriteLine(PaintHouseIII2([0, 0, 0, 0, 0], [[1, 10], [10, 1], [10, 1], [1, 10], [5, 1]], 5, 2, 3));
            Console.WriteLine(PaintHouseIII2([0, 2, 1, 2, 0], [[1, 10], [10, 1], [10, 1], [1, 10], [5, 1]], 5, 2, 3));
            Console.WriteLine(PaintHouseIII2([3, 1, 2, 3], [[1, 1, 1], [1, 1, 1], [1, 1, 1], [1, 1, 1]], 4, 3, 3));
        }

        public static int PaintHouseIII0(int[] a0, int[][] a1, int a2, int a3, int a4) => RftPaintHouseIII0(a0, a1, a2, a3, a4);

        public static int PaintHouseIII1(int[] a0, int[][] a1, int a2, int a3, int a4) => RftPaintHouseIII1(a0, a1, a2, a3, a4);

        public static int PaintHouseIII2(int[] a0, int[][] a1, int a2, int a3, int a4) => RftPaintHouseIII2(a0, a1, a2, a3, a4);

        // Top-Down DP
        private static int[][][] memo = new int[100][][];
        private static readonly int MAX_COST = 1000001;

        private static int RftPaintHouseIII0(int[] houses, int[][] cost, int m, int n, int target)
        {
            memo = new int[100][][];
            for (int i = 0; i < 100; i++)
            {
                memo[i] = new int[100][];
                for (int j = 0; j < 100; j++)
                {
                    memo[i][j] = new int[21];
                }
            }

            int answer = FindMinCost(houses, cost, target, 0, 0, 0);

            return answer == MAX_COST ? -1 : answer;
        }

        private static int FindMinCost(int[] houses, int[][] cost, int targetCount, int currIndex, int neighborhoodCount, int prevHouseColor)
        {
            if (currIndex == houses.Length) return neighborhoodCount == targetCount ? 0 : MAX_COST;

            if (neighborhoodCount > targetCount) return MAX_COST;

            int minCost = MAX_COST;

            if (houses[currIndex] != 0)
            {
                int newNeighborhoodCount = neighborhoodCount + (houses[currIndex] != prevHouseColor ? 1 : 0);
                minCost = FindMinCost(houses, cost, targetCount, currIndex + 1, newNeighborhoodCount, houses[currIndex]);
            }
            else
            {
                int totalColors = cost[0].Length;

                for (int color = 1; color <= totalColors; color++)
                {
                    int newNeighborhoodCount = neighborhoodCount + (color != prevHouseColor ? 1 : 0);
                    int currCost = cost[currIndex][color - 1] + FindMinCost(houses, cost, targetCount, currIndex + 1, newNeighborhoodCount, color);
                    minCost = Math.Min(minCost, currCost);
                }
            }

            return memo[currIndex][neighborhoodCount][prevHouseColor] = minCost;
        }

        // Bottom-Up DP
        private static int RftPaintHouseIII1(int[] houses, int[][] cost, int m, int n, int target)
        {
            int[][][] memo = new int[m][][];
            for (int i = 0; i < m; i++)
            {
                memo[i] = new int[target + 1][];
                for (int j = 0; j < target + 1; j++)
                {
                    memo[i][j] = new int[n];
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    Array.Fill(memo[i][j], MAX_COST);
                }
            }

            for (int color = 1; color <= n; color++)
            {
                if (houses[0] == color) memo[0][1][color - 1] = 0;
                else if (houses[0] == 0) memo[0][1][color - 1] = cost[0][color - 1];
            }

            for (int house = 1; house < m; house++)
            {
                for (int neighborhoods = 1; neighborhoods <= Math.Min(target, house + 1); neighborhoods++)
                {
                    for (int color = 1; color <= n; color++)
                    {
                        if (houses[house] != 0 && color != houses[house]) continue;

                        int currCost = MAX_COST;
                        for (int prevColor = 1; prevColor <= n; prevColor++)
                        {
                            if (prevColor != color) currCost = Math.Min(currCost, memo[house - 1][neighborhoods - 1][prevColor - 1]);
                            else currCost = Math.Min(currCost, memo[house - 1][neighborhoods][color - 1]);
                        }

                        int costToPaint = houses[house] != 0 ? 0 : cost[house][color - 1];
                        memo[house][neighborhoods][color - 1] = currCost + costToPaint;
                    }
                }
            }

            int minCost = MAX_COST;
            for (int color = 1; color <= n; color++)
            {
                minCost = Math.Min(minCost, memo[m - 1][target][color - 1]);
            }

            return minCost == MAX_COST ? -1 : minCost;
        }

        // Bottom-Up DP Space Optimized
        private static int RftPaintHouseIII2(int[] houses, int[][] cost, int m, int n, int target)
        {
            int[][] prevMemo = new int[target + 1][];
            for (int i = 0; i < target + 1; i++)
            {
                prevMemo[i] = new int[n];
            }

            for (int i = 0; i <= target; i++)
            {
                Array.Fill(prevMemo[i], MAX_COST);
            }

            for (int color = 1; color <= n; color++)
            {
                if (houses[0] == color) prevMemo[1][color - 1] = 0;
                else if (houses[0] == 0) prevMemo[1][color - 1] = cost[0][color - 1];
            }

            for (int house = 1; house < m; house++)
            {
                int[][] memo = new int[target + 1][];
                for (int i = 0; i < target + 1; i++)
                {
                    memo[i] = new int[n];
                }

                for (int i = 0; i <= target; i++)
                {
                    Array.Fill(memo[i], MAX_COST);
                }

                for (int neighborhoods = 1; neighborhoods <= Math.Min(target, house + 1); neighborhoods++)
                {
                    for (int color = 1; color <= n; color++)
                    {
                        if (houses[house] != 0 && color != houses[house]) continue;

                        int currCost = MAX_COST;
                        for (int prevColor = 1; prevColor <= n; prevColor++)
                        {
                            if (prevColor != color) currCost = Math.Min(currCost, prevMemo[neighborhoods - 1][prevColor - 1]);
                            else currCost = Math.Min(currCost, prevMemo[neighborhoods][color - 1]);
                        }

                        int costToPaint = houses[house] != 0 ? 0 : cost[house][color - 1];
                        memo[neighborhoods][color - 1] = currCost + costToPaint;
                    }
                }
                prevMemo = memo;
            }

            int minCost = MAX_COST;
            for (int color = 1; color <= n; color++)
            {
                minCost = Math.Min(minCost, prevMemo[target][color - 1]);
            }

            return minCost == MAX_COST ? -1 : minCost;
        }
    }
}
