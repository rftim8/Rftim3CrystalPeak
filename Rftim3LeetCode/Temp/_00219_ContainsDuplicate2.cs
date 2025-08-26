namespace Rftim3LeetCode.Temp
{
    public class _00219_ContainsDuplicate2
    {
        /// <summary>
        /// Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
        /// </summary>
        public _00219_ContainsDuplicate2()
        {
            Console.WriteLine(ContainsNearbyDuplicate0([1, 2, 3, 1], 3));
            Console.WriteLine(ContainsNearbyDuplicate0([1, 0, 1, 1], 1));
            Console.WriteLine(ContainsNearbyDuplicate0([1, 2, 3, 1, 2, 3], 2));
        }

        public static bool ContainsNearbyDuplicate0(int[] a0, int a1) => RftContainsNearbyDuplicate0(a0, a1);

        private static bool RftContainsNearbyDuplicate0(int[] nums, int k)
        {
            int n = nums.Length;

            Dictionary<int, int> x = [];

            for (int i = 0; i < n; i++)
            {
                if (!x.TryGetValue(nums[i], out int value)) x.Add(nums[i], i);
                else
                {
                    if (Math.Abs(value - i) <= k) return true;
                    else x[nums[i]] = i;
                }
            }

            return false;
        }
    }
}
