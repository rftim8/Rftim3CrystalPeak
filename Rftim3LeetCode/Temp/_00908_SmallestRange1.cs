namespace Rftim3LeetCode.Temp
{
    public class _00908_SmallestRange1
    {
        /// <summary>
        /// You are given an integer array nums and an integer k.
        /// In one operation, you can choose any index i where 0 <= i<nums.length and change nums[i] to nums[i] + x where x is an integer from the range[-k, k]. 
        /// You can apply this operation at most once for each index i.
        /// The score of nums is the difference between the maximum and minimum elements in nums.
        /// Return the minimum score of nums after applying the mentioned operation at most once for each index in it.
        /// </summary>
        public _00908_SmallestRange1()
        {
            Console.WriteLine(SmallestRangeI([1], 0));
            Console.WriteLine(SmallestRangeI([0, 10], 2));
            Console.WriteLine(SmallestRangeI([1, 3, 6], 3));
        }

        private static int SmallestRangeI(int[] nums, int k)
        {
            int res = nums.Max() - k - nums.Min() - k;

            return res > 0 ? res : 0;
        }
    }
}
