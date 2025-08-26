namespace Rftim3LeetCode.Temp
{
    public class _01658_MinimumOperationsToReduceXToZero
    {
        /// <summary>
        /// You are given an integer array nums and an integer x. 
        /// In one operation, you can either remove the leftmost or the rightmost element from the array nums and subtract its value from x. 
        /// Note that this modifies the array for future operations.
        /// Return the minimum number of operations to reduce x to exactly 0 if it is possible, otherwise, return -1.
        /// </summary>
        public _01658_MinimumOperationsToReduceXToZero()
        {
            Console.WriteLine(MinOperations([1, 1, 4, 2, 3], 5));
            Console.WriteLine(MinOperations([5, 6, 7, 8, 9], 4));
            Console.WriteLine(MinOperations([3, 2, 20, 1, 1, 3], 10));
            Console.WriteLine(MinOperations([1, 1], 3));
            Console.WriteLine(MinOperations([10, 1, 1, 1, 1, 1], 5));
            Console.WriteLine(MinOperations([1000, 1, 1, 2, 3], 1004));
        }

        private static int MinOperations(int[] nums, int x)
        {
            int n = nums.Length;
            int sum = nums.Sum();
            sum -= x;

            if (sum < 0) return -1;
            else if (sum == 0) return n;

            int res = -1, l = 0, r = 0;
            for (int i = 0; i < n; ++i)
            {
                if (r < sum) r += nums[i];

                while (l <= i && r >= sum)
                {
                    if (r == sum) res = res == -1 ? i - l + 1 : Math.Max(res, i - l + 1);
                    r -= nums[l++];
                }
            }

            return res == -1 ? -1 : n - res;
        }

        private static int MinOperations0(int[] nums, int x)
        {
            int n = nums.Length;
            if (x == nums[0] || x == nums[n - 1]) return 1;

            int min = int.MaxValue;
            int dim = nums.Length;
            int[] leftOnly = new int[dim];
            int[] rightOnly = new int[dim];

            int last = nums[0];
            leftOnly[0] = last;
            for (int i = 1; i < dim; i++)
            {
                last += nums[i];
                leftOnly[i] = last;

                if (last == x) min = Math.Min(min, i + 1);
            }

            last = nums[n - 1];
            rightOnly[0] = last;

            for (int i = 1; i < dim; i++)
            {
                last += nums[n - 1 - i];
                rightOnly[i] = last;

                if (last == x) min = Math.Min(min, i + 1);
            }

            for (int l = leftOnly.Length - 2, r = 0; l >= 0 && r < rightOnly.Length - 2;)
            {
                int sum = leftOnly[l] + rightOnly[r];
                if (sum > x) l--;
                else if (sum == x)
                {
                    min = Math.Min(min, l + r + 2);
                    l--;
                    r++;
                }
                else r++;
            }

            return min == int.MaxValue ? -1 : min;
        }
    }
}
