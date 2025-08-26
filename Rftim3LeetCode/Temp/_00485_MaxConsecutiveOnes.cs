namespace Rftim3LeetCode.Temp
{
    public class _00485_MaxConsecutiveOnes
    {
        /// <summary>
        /// Given a binary array nums, return the maximum number of consecutive 1's in the array.
        /// </summary>
        public _00485_MaxConsecutiveOnes()
        {
            Console.WriteLine(FindMaxConsecutiveOnes0([1, 1, 0, 1, 1, 1]));
            Console.WriteLine(FindMaxConsecutiveOnes0([1, 0, 1, 1, 0, 1]));
        }

        public static int FindMaxConsecutiveOnes0(int[] a0) => RftFindMaxConsecutiveOnes0(a0);

        private static int RftFindMaxConsecutiveOnes0(int[] nums)
        {
            int c = 0, l = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) c++;
                else
                {
                    if (c > l) l = c;
                    c = 0;
                }
                if (i == nums.Length - 1)
                {
                    if (c > l) l = c;
                }
            }

            return l;
        }
    }
}
