namespace Rftim3LeetCode.Temp
{
    public class _00746_MinCostClimbingStairs
    {
        /// <summary>
        /// You are given an integer array cost where cost[i] is the cost of ith step on a staircase. Once you pay the cost, you can either climb one or two steps.
        /// You can either start from the step with index 0, or the step with index 1.
        /// Return the minimum cost to reach the top of the floor.
        /// </summary>
        public _00746_MinCostClimbingStairs()
        {
            Console.WriteLine(MinCostClimbingStairs([10, 15, 20]));
            Console.WriteLine(MinCostClimbingStairs([1, 100, 1, 1, 1, 100, 1, 1, 100, 1]));
            Console.WriteLine(MinCostClimbingStairs([0, 1, 1, 2]));
            Console.WriteLine(MinCostClimbingStairs([0, 1, 2, 2])); // 2
        }

        private static int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            if (n == 2) return cost[0] <= cost[1] ? cost[0] : cost[1];

            int[] c = new int[n + 1];

            c[0] = cost[0];
            c[1] = cost[1];

            for (int i = 2; i <= n; i++)
            {
                if (i < n) c[i] = Math.Min(c[i - 2] + cost[i], c[i - 1] + cost[i]);
                else c[i] = Math.Min(c[i - 2], c[i - 1]);
            }

            return c[n];
        }
    }
}
