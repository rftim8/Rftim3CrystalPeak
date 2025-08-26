namespace Rftim3LeetCode.Temp
{
    public class _01567_MaximumLengthOfSubarrayWithPositiveProduct
    {
        /// <summary>
        /// Given an array of integers nums, find the maximum length of a subarray where the product of all its elements is positive.
        /// A subarray of an array is a consecutive sequence of zero or more values taken out of that array.
        /// Return the maximum length of a subarray with positive product.
        /// </summary>
        public _01567_MaximumLengthOfSubarrayWithPositiveProduct()
        {
            Console.WriteLine(GetMaxLen([1, -2, -3, 4]));
            Console.WriteLine(GetMaxLen([0, 1, -2, -3, -4]));
            Console.WriteLine(GetMaxLen([-1, -2, -3, 0, 1]));
        }

        private static int GetMaxLen(int[] nums)
        {
            int n = nums.Length;
            int x = 0, pos = 0, neg = 0;

            for (int i = 0; i < n; i++)
            {
                int num = nums[i];
                if (num == 0)
                {
                    pos = 0;
                    neg = 0;
                }
                else if (num > 0)
                {
                    pos++;
                    neg = neg == 0 ? 0 : neg + 1;
                }
                else
                {
                    int prev = pos;
                    pos = neg == 0 ? 0 : neg + 1;
                    neg = prev + 1;
                }

                x = Math.Max(x, pos);
            }

            return x;
        }
    }
}
