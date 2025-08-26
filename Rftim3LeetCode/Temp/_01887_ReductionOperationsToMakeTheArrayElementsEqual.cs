namespace Rftim3LeetCode.Temp
{
    public class _01887_ReductionOperationsToMakeTheArrayElementsEqual
    {
        /// <summary>
        /// Given an integer array nums, your goal is to make all elements in nums equal. To complete one operation, follow these steps:
        /// 
        /// Find the largest value in nums.Let its index be i(0-indexed) and its value be largest.If there are multiple elements with the largest value, pick the smallest i.
        /// Find the next largest value in nums strictly smaller than largest.Let its value be nextLargest.
        /// Reduce nums[i] to nextLargest.
        /// Return the number of operations to make all elements in nums equal.
        /// </summary>
        public _01887_ReductionOperationsToMakeTheArrayElementsEqual()
        {
            Console.WriteLine(ReductionOperations0([5, 1, 3]));
            Console.WriteLine(ReductionOperations0([1, 1, 1]));
            Console.WriteLine(ReductionOperations0([1, 1, 2, 2, 3]));
        }

        public static int ReductionOperations0(int[] a0) => RftReductionOperations0(a0);

        private static int RftReductionOperations0(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            int r = 0, c = 0;
            for (int i = 1; i < n; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    c++;
                    r += c;
                }
                else if (nums[i - 1] == nums[i]) r += c;
            }

            return r;
        }
    }
}
