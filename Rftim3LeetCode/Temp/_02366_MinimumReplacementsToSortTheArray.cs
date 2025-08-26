namespace Rftim3LeetCode.Temp
{
    public class _02366_MinimumReplacementsToSortTheArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums. In one operation you can replace any element of the array with any two elements that sum to it.
        /// For example, consider nums = [5,6,7]. In one operation, we can replace nums[1] with 2 and 4 and convert nums to[5, 2, 4, 7].
        /// Return the minimum number of operations to make an array that is sorted in non-decreasing order.
        /// </summary>
        public _02366_MinimumReplacementsToSortTheArray()
        {
            Console.WriteLine(MinimumReplacement([3, 9, 3]));
            Console.WriteLine(MinimumReplacement([1, 2, 3, 4, 5]));
        }

        private static long MinimumReplacement(int[] nums)
        {
            long answer = 0;
            int n = nums.Length;

            for (int i = n - 2; i >= 0; i--)
            {
                if (nums[i] <= nums[i + 1]) continue;

                long numElements = (nums[i] + nums[i + 1] - 1) / (long)nums[i + 1];
                answer += numElements - 1;
                nums[i] = nums[i] / (int)numElements;
            }

            return answer;
        }
    }
}
