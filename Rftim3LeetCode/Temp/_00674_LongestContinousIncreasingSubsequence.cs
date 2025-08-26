namespace Rftim3LeetCode.Temp
{
    public class _00674_LongestContinousIncreasingSubsequence
    {
        /// <summary>
        /// Given an unsorted array of integers nums, return the length of the longest continuous increasing subsequence (i.e. subarray). 
        /// The subsequence must be strictly increasing.
        /// A continuous increasing subsequence is defined by two indices l and r(l<r) such that 
        /// it is [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] and for each l <= i<r, nums[i] < nums[i + 1].
        /// </summary>
        public _00674_LongestContinousIncreasingSubsequence()
        {
            Console.WriteLine(FindLengthOfLCIS([1, 3, 5, 4, 7]));
            Console.WriteLine(FindLengthOfLCIS([2, 2, 2, 2, 2]));
        }

        private static int FindLengthOfLCIS(int[] nums)
        {
            int r = 0, c = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    c++;
                    r = Math.Max(r, c);
                }
                else c = 1;
            }

            return r;
        }

        private static int FindLengthOfLCIS0(int[] nums)
        {
            int count = 1;
            int maxCount = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    count++;
                    if (count > maxCount) maxCount = count;
                }
                else count = 1;
            }

            return maxCount;
        }
    }
}
