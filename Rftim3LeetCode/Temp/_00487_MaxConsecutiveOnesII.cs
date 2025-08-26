namespace Rftim3LeetCode.Temp
{
    public class _00487_MaxConsecutiveOnesII
    {
        /// <summary>
        /// Given a binary array nums, return the maximum number of consecutive 1's in the array if you can flip at most one 0.
        /// </summary>
        public _00487_MaxConsecutiveOnesII()
        {
            Console.WriteLine(FindMaxConsecutiveOnes0([1, 0, 1, 1, 0]));
            Console.WriteLine(FindMaxConsecutiveOnes0([1, 0, 1, 1, 0, 1]));
        }

        public static int FindMaxConsecutiveOnes0(int[] a0) => RftFindMaxConsecutiveOnes0(a0);

        public static int FindMaxConsecutiveOnes1(int[] a0) => RftFindMaxConsecutiveOnes1(a0);

        public static int FindMaxConsecutiveOnes2(int[] a0) => RftFindMaxConsecutiveOnes2(a0);

        #region Brute Force
        private static int RftFindMaxConsecutiveOnes0(int[] nums)
        {
            int longestSequence = 0;
            for (int left = 0; left < nums.Length; left++)
            {
                int numZeroes = 0;
                for (int right = left; right < nums.Length; right++)
                {
                    if (nums[right] == 0) numZeroes += 1;
                    if (numZeroes <= 1) longestSequence = Math.Max(longestSequence, right - left + 1);
                }
            }

            return longestSequence;
        }
        #endregion

        #region Sliding Window
        private static int RftFindMaxConsecutiveOnes1(int[] nums)
        {
            int longestSequence = 0;
            int left = 0;
            int right = 0;
            int numZeroes = 0;

            while (right < nums.Length)
            {
                if (nums[right] == 0) numZeroes++;

                while (numZeroes == 2)
                {
                    if (nums[left] == 0) numZeroes--;

                    left++;
                }

                longestSequence = Math.Max(longestSequence, right - left + 1);
                right++;
            }

            return longestSequence;
        }
        #endregion

        #region Sliding Window
        private static int RftFindMaxConsecutiveOnes2(int[] nums)
        {
            int j = 0;
            int counter = 0;
            int max = 0;
            bool nozero = true;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) counter++;
                else if (nums[i] == 0 && nozero)
                {
                    nozero = false;
                    j = i;
                    counter++;
                }
                else if (nums[i] == 0 && !nozero)
                {
                    if (max < counter) max = counter;

                    i = j;
                    nozero = true;
                    counter = 0;
                }
            }

            if (max < counter) return counter;

            return max;
        }
        #endregion
    }
}
