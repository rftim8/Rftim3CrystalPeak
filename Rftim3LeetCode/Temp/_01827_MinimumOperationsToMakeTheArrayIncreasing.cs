namespace Rftim3LeetCode.Temp
{
    public class _01827_MinimumOperationsToMakeTheArrayIncreasing
    {
        /// <summary>
        /// You are given an integer array nums (0-indexed). In one operation, you can choose an element of the array and increment it by 1.
        /// For example, if nums = [1,2,3], you can choose to increment nums[1] to make nums = [1,3,3].
        /// Return the minimum number of operations needed to make nums strictly increasing.
        /// An array nums is strictly increasing if nums[i] < nums[i + 1] for all 0 <= i<nums.length - 1. 
        /// An array of length 1 is trivially strictly increasing.
        /// </summary>
        public _01827_MinimumOperationsToMakeTheArrayIncreasing()
        {
            Console.WriteLine(MinOperations([1, 1, 1]));
            Console.WriteLine(MinOperations([1, 5, 2, 4, 1]));
            Console.WriteLine(MinOperations([8]));
        }

        private static int MinOperations(int[] nums)
        {
            int n = nums.Length;

            int c = 0;
            for (int i = 1; i < n; i++)
            {
                if (nums[i - 1] >= nums[i])
                {
                    c += nums[i - 1] - nums[i] + 1;
                    nums[i] = nums[i - 1] + 1;
                }
            }

            return c;
        }
    }
}
