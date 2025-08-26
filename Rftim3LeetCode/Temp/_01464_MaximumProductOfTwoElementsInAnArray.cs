namespace Rftim3LeetCode.Temp
{
    public class _01464_MaximumProductOfTwoElementsInAnArray
    {
        /// <summary>
        /// Given the array of integers nums, you will choose two different indices i and j of that array. 
        /// Return the maximum value of (nums[i]-1)*(nums[j]-1).
        /// </summary>
        public _01464_MaximumProductOfTwoElementsInAnArray()
        {
            Console.WriteLine(MaxProduct([3, 4, 5, 2]));
            Console.WriteLine(MaxProduct([1, 5, 4, 5]));
            Console.WriteLine(MaxProduct([3, 7]));
        }

        private static int MaxProduct(int[] nums)
        {
            Array.Sort(nums);

            return (nums[^1] - 1) * (nums[^2] - 1);
        }
    }
}
