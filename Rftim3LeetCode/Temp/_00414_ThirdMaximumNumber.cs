namespace Rftim3LeetCode.Temp
{
    public class _00414_ThirdMaximumNumber
    {
        /// <summary>
        /// Given an integer array nums, return the third distinct maximum number in this array. 
        /// If the third maximum does not exist, return the maximum number.
        /// </summary>
        public _00414_ThirdMaximumNumber()
        {
            Console.WriteLine(ThirdMax0([3, 2, 1]));
            Console.WriteLine(ThirdMax0([1, 1]));
            Console.WriteLine(ThirdMax0([2, 2, 3, 1]));
        }

        public static int ThirdMax0(int[] a0) => RftThirdMax0(a0);

        private static int RftThirdMax0(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            if (n < 3) return nums[n - 1];

            int c = 1;
            int x = nums[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                if (nums[i] != x)
                {
                    x = nums[i];
                    c++;
                }
                if (c == 3) break;
            }
            if (c < 3) x = nums[n - 1];

            return x;
        }
    }
}
