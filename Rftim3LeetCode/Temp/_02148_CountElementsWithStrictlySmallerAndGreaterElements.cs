namespace Rftim3LeetCode.Temp
{
    public class _02148_CountElementsWithStrictlySmallerAndGreaterElements
    {
        /// <summary>
        /// Given an integer array nums, return the number of elements that have both a strictly smaller and a strictly greater element appear in nums.
        /// </summary>
        public _02148_CountElementsWithStrictlySmallerAndGreaterElements()
        {
            Console.WriteLine(CountElements([11, 7, 2, 15]));
            Console.WriteLine(CountElements([-3, 3, 3, 90]));
        }

        private static int CountElements(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                int l = i, r = i;
                bool left = false, right = false;
                while (l > -1)
                {
                    if (nums[l] < nums[i])
                    {
                        left = true;
                        break;
                    }
                    l--;
                }
                while (r < n)
                {
                    if (nums[r] > nums[i])
                    {
                        right = true;
                        break;
                    }
                    r++;
                }

                if (right && left) c++;
            }

            return c;
        }
    }
}
