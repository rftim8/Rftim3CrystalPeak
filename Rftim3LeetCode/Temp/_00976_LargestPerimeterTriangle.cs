namespace Rftim3LeetCode.Temp
{
    public class _00976_LargestPerimeterTriangle
    {
        /// <summary>
        /// Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. 
        /// If it is impossible to form any triangle of a non-zero area, return 0.
        /// </summary>
        public _00976_LargestPerimeterTriangle()
        {
            Console.WriteLine(LargestPerimeter([2, 1, 2]));
            Console.WriteLine(LargestPerimeter([1, 2, 1, 10]));
        }

        private static int LargestPerimeter(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            for (int i = n - 1; i > 1; i--)
            {
                if (nums[i] < nums[i - 2] + nums[i - 1]) return nums[i - 2] + nums[i - 1] + nums[i];
            }

            return 0;
        }

        private static int LargestPerimeter0(int[] nums)
        {
            int maxPer = 0;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (GetPerimeter(nums[i], nums[i + 1], nums[i + 2], out var per))
                {
                    if (per > maxPer) maxPer = per;
                }
            }

            return maxPer;
        }

        private static bool GetPerimeter(int a, int b, int c, out int perimeter)
        {
            if (a + b > c && b + c > a && c + a > b)
            {
                perimeter = a + b + c;

                return true;
            }
            perimeter = 0;

            return false;
        }
    }
}
