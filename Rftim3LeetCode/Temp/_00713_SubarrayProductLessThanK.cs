namespace Rftim3LeetCode.Temp
{
    public class _00713_SubarrayProductLessThanK
    {
        /// <summary>
        /// Given an array of integers nums and an integer k, return the number of contiguous subarrays where the product 
        /// of all the elements in the subarray is strictly less than k.
        /// </summary>
        public _00713_SubarrayProductLessThanK()
        {
            Console.WriteLine(NumSubarrayProductLessThanK([10, 5, 2, 6], 100));
            Console.WriteLine(NumSubarrayProductLessThanK([1, 2, 3], 0));
            Console.WriteLine(NumSubarrayProductLessThanK([10, 9, 10, 4, 3, 8, 3, 3, 6, 2, 10, 10, 9, 3], 19));
        }

        private static int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int n = nums.Length;
            int x = 0;

            for (int i = 0; i < n; i++)
            {
                int y = 1;
                for (int j = i; j < n; j++)
                {
                    y *= nums[j];
                    if (y < k) x++;
                    if (y >= k) break;
                }
            }

            return x;
        }

        private static int NumSubarrayProductLessThanK0(int[] nums, int k)
        {
            if (k <= 1) return 0;

            int l = 0;
            int mid = 1;
            int x = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                mid *= nums[i];
                while (mid >= k)
                {
                    mid /= nums[l];
                    l++;
                }
                x += i - l + 1;
            }

            return x;
        }
    }
}
