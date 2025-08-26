namespace Rftim3LeetCode.Temp
{
    public class _02535_DifferenceBetweenElementSumAndDigitSumOfAnArray
    {
        /// <summary>
        /// You are given a positive integer array nums.
        /// The element sum is the sum of all the elements in nums.
        /// The digit sum is the sum of all the digits(not necessarily distinct) that appear in nums.
        /// Return the absolute difference between the element sum and digit sum of nums.
        /// Note that the absolute difference between two integers x and y is defined as |x - y|.
        /// </summary>
        public _02535_DifferenceBetweenElementSumAndDigitSumOfAnArray()
        {
            Console.WriteLine(DifferenceOfSum([1, 15, 6, 3]));
            Console.WriteLine(DifferenceOfSum([1, 2, 3, 4]));
        }

        private static int DifferenceOfSum(int[] nums)
        {
            int n = nums.Length;

            int d = 0, e = 0;
            for (int i = 0; i < n; i++)
            {
                e += nums[i];
                int t = nums[i];
                while (t > 0)
                {
                    d += t % 10;
                    t /= 10;
                }
            }

            return Math.Abs(d - e);
        }
    }
}
