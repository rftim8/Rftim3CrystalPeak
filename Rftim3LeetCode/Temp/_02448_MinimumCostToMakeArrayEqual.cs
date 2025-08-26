namespace Rftim3LeetCode.Temp
{
    public class _02448_MinimumCostToMakeArrayEqual
    {
        /// <summary>
        /// You are given two 0-indexed arrays nums and cost consisting each of n positive integers.
        /// You can do the following operation any number of times:
        /// Increase or decrease any element of the array nums by 1.
        /// The cost of doing one operation on the ith element is cost[i].
        /// Return the minimum total cost such that all the elements of the array nums become equal.
        /// </summary>
        public _02448_MinimumCostToMakeArrayEqual()
        {
            Console.WriteLine(MinCost([1, 3, 5, 2], [2, 3, 1, 14]));
            Console.WriteLine(MinCost([2, 2, 2, 2, 2], [4, 2, 8, 1, 3]));
        }

        private static long MinCost(int[] nums, int[] cost)
        {
            int n = nums.Length;
            int[][] numsAndCost = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                numsAndCost[i] = new int[2];
                numsAndCost[i][0] = nums[i];
                numsAndCost[i][1] = cost[i];
            }
            Array.Sort(numsAndCost, (a, b) => a[0] - b[0]);

            long[] prefixCost = new long[n];
            prefixCost[0] = numsAndCost[0][1];
            for (int i = 1; i < n; ++i)
            {
                prefixCost[i] = numsAndCost[i][1] + prefixCost[i - 1];
            }

            long totalCost = 0L;
            for (int i = 1; i < n; ++i)
            {
                totalCost += 1L * numsAndCost[i][1] * (numsAndCost[i][0] - numsAndCost[0][0]);
            }

            long answer = totalCost;
            for (int i = 1; i < n; ++i)
            {
                int gap = numsAndCost[i][0] - numsAndCost[i - 1][0];
                totalCost += 1L * prefixCost[i - 1] * gap;
                totalCost -= 1L * (prefixCost[n - 1] - prefixCost[i - 1]) * gap;
                answer = Math.Min(answer, totalCost);
            }

            return answer;
        }

        private static long MinCost0(int[] nums, int[] cost)
        {
            int left = 1000001, right = 0;
            foreach (int num in nums)
            {
                left = Math.Min(left, num);
                right = Math.Max(right, num);
            }

            long answer = GetCost(nums, cost, nums[0]);
            while (left < right)
            {
                int mid = (right + left) / 2;
                long cost1 = GetCost(nums, cost, mid);
                long cost2 = GetCost(nums, cost, mid + 1);
                answer = Math.Min(cost1, cost2);

                if (cost1 > cost2) left = mid + 1;
                else right = mid;
            }

            return answer;
        }

        private static long GetCost(int[] nums, int[] cost, int x)
        {
            long result = 0L;
            for (int i = 0; i < nums.Length; ++i)
            {
                result += 1L * Math.Abs(nums[i] - x) * cost[i];
            }

            return result;
        }
    }
}
