namespace Rftim3LeetCode.Temp
{
    public class _02908_MinimumSumOfMountainTriplets1
    {
        /// <summary>
        /// You are given a 0-indexed array nums of integers.
        /// 
        /// A triplet of indices(i, j, k) is a mountain if:
        /// 
        /// i<j<k
        /// nums[i] < nums[j] and nums[k] < nums[j]
        /// Return the minimum possible sum of a mountain triplet of nums.If no such triplet exists, return -1.
        /// </summary>
        public _02908_MinimumSumOfMountainTriplets1()
        {
            Console.WriteLine(MinimumSum0([8, 6, 1, 5, 3]));
            Console.WriteLine(MinimumSum0([5, 4, 8, 7, 10, 2]));
            Console.WriteLine(MinimumSum0([6, 5, 4, 3, 4, 5]));
        }

        public static int MinimumSum0(int[] a0) => RftMinimumSum0(a0);

        private static int RftMinimumSum0(int[] nums)
        {
            int n = nums.Length;

            int r = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (nums[i] < nums[j] && nums[j] > nums[k]) r = Math.Min(r, nums[i] + nums[j] + nums[k]);
                    }
                }

            }

            return r == int.MaxValue ? -1 : r;
        }
    }
}
