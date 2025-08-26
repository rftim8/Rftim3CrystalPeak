namespace Rftim3LeetCode.Temp
{
    public class _01802_MaximumValueAtAGivenIndexInABoundedArray
    {
        /// <summary>
        /// You are given three positive integers: n, index, and maxSum. You want to construct an array nums (0-indexed) that satisfies the following conditions:
        /// - nums.length == n
        /// - nums[i] is a positive integer where 0 <= i<n.
        /// - abs(nums[i] - nums[i + 1]) <= 1 where 0 <= i<n-1.
        /// - The sum of all the elements of nums does not exceed maxSum.
        /// - nums[index] is maximized.
        /// - Return nums[index] of the constructed array.
        /// Note that abs(x) equals x if x >= 0, and -x otherwise.
        /// </summary>
        public _01802_MaximumValueAtAGivenIndexInABoundedArray()
        {
            Console.WriteLine(MaxValue(4, 2, 6));
            Console.WriteLine(MaxValue(6, 1, 10));
        }

        private static int MaxValue(int n, int index, int maxSum)
        {
            int left = 1, right = maxSum;
            while (left < right)
            {
                int mid = (left + right + 1) / 2;
                if (GetSum(index, mid, n) <= maxSum) left = mid;
                else right = mid - 1;
            }

            return left;
        }

        private static long GetSum(int index, int value, int n)
        {
            long count = 0;

            if (value > index) count += (long)(value + value - index) * (index + 1) / 2;
            else count += (long)(value + 1) * value / 2 + index - value + 1;

            if (value >= n - index) count += (long)(value + value - n + 1 + index) * (n - index) / 2;
            else count += (long)(value + 1) * value / 2 + n - index - value;

            return count - value;
        }
    }
}
