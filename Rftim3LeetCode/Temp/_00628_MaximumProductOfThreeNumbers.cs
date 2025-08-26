namespace Rftim3LeetCode.Temp
{
    public class _00628_MaximumProductOfThreeNumbers
    {
        /// <summary>
        /// Given an integer array nums, find three numbers whose product is maximum and return the maximum product.
        /// </summary>
        public _00628_MaximumProductOfThreeNumbers()
        {
            Console.WriteLine(MaximumProduct([1, 2, 3]));
            Console.WriteLine(MaximumProduct([1, 2, 3, 4]));
            Console.WriteLine(MaximumProduct([-1, -2, -3]));
        }

        private static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);

            HashSet<int> r =
            [
                nums[0] * nums[1] * nums[2],
                nums[0] * nums[1] * nums[^1],
                nums[0] * nums[^2] * nums[^1],
                nums[^3] * nums[^2] * nums[^1]
            ];

            return r.Max();
        }
    }
}
