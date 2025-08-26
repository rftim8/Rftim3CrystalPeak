namespace Rftim3LeetCode.Temp
{
    public class _00075_SortColors
    {
        /// <summary>
        /// Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, 
        /// with the colors in the order red, white, and blue.
        /// We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
        /// You must solve this problem without using the library's sort function.
        /// </summary>
        public _00075_SortColors()
        {
            SortColors0(new int[] { 2, 0, 2, 1, 1, 0 });
        }

        private static void SortColors0(int[] nums)
        {
            int n = nums.Length;
            int m;
            for (int i = 0; i < n; i++)
            {
                m = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[j] < nums[m]) m = j;
                }
                (nums[m], nums[i]) = (nums[i], nums[m]);
            }

            foreach (int item in nums)
            {
                Console.WriteLine(item);
            }
        }
    }
}
