namespace Rftim3LeetCode.Temp
{
    public class _00152_MaximumProductSubarray
    {
        /// <summary>
        /// Given an integer array nums, find a 
        /// subarray
        ///  that has the largest product, and return the product.
        /// The test cases are generated so that the answer will fit in a 32-bit integer.
        /// </summary>
        public _00152_MaximumProductSubarray()
        {
            Console.WriteLine(MaxProduct(new int[] { 2, 3, -2, 4 }));
            Console.WriteLine(MaxProduct(new int[] { -2, 0, -1 }));
            Console.WriteLine(MaxProduct(new int[] { -3, -1, -1 }));
            Console.WriteLine(MaxProduct(new int[] { 0, 2 }));
            Console.WriteLine(MaxProduct(new int[] { 3, -1, 4 }));
        }

        private static int MaxProduct(int[] nums)
        {
            int n = nums.Length;
            int x = nums[0], l = 0, r = 0;

            for (int i = 0; i < n; i++)
            {
                l = (l != 0 ? l : 1) * nums[i];
                r = (r != 0 ? r : 1) * nums[n - 1 - i];
                x = Math.Max(x, Math.Max(l, r));
            }

            return x;
        }
    }
}
