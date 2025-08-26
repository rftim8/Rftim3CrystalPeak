namespace Rftim3LeetCode.Temp
{
    public class _00287_FindTheDuplicateNumber
    {
        /// <summary>
        /// Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.
        /// There is only one repeated number in nums, return this repeated number.
        /// You must solve the problem without modifying the array nums and uses only constant extra space.
        /// </summary>
        public _00287_FindTheDuplicateNumber()
        {
            Console.WriteLine(FindDuplicate([1, 3, 4, 2, 2]));
            Console.WriteLine(FindDuplicate([3, 1, 3, 4, 2]));
        }

        private static int FindDuplicate(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.ContainsKey(nums[i])) return nums[i];
                else r[nums[i]] = 1;
            }

            return -1;
        }
    }
}
