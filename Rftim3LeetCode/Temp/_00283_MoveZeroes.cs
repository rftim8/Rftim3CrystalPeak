using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00283_MoveZeroes
    {
        /// <summary>
        /// Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        /// Note that you must do this in-place without making a copy of the array.
        /// </summary>
        public _00283_MoveZeroes()
        {
            int[] a0 = MoveZeroes0([0, 1, 0, 3, 12]);
            RftTerminal.RftReadResult(a0);

            int[] a1 = MoveZeroes0([0]);
            RftTerminal.RftReadResult(a1);
        }

        public static int[] MoveZeroes0(int[] a0) => RftMoveZeroes0(a0);

        public static int[] MoveZeroes1(int[] a0) => RftMoveZeroes1(a0);

        public static int[] MoveZeroes2(int[] a0) => RftMoveZeroes2(a0);

        private static int[] RftMoveZeroes0(int[] nums)
        {
            int n = nums.Length;
            int c = n, t = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0) c--;
                else nums[t++] = nums[i];
            }

            for (int i = c; i < n; i++)
            {
                nums[i] = 0;
            }

            return nums;
        }

        private static int[] RftMoveZeroes1(int[] nums)
        {
            int n = nums.Length - 1;
            int c = 0;
            for (int i = 0; i <= n; i++)
            {
                if (nums[i] == 0) c++;
            }

            for (int j = 0; j < c; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] == 0) (nums[i], nums[i + 1]) = (nums[i + 1], nums[i]);
                }
            }

            return nums;
        }

        private static int[] RftMoveZeroes2(int[] nums)
        {
            int j = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0) nums[j++] = nums[i];
            }

            while (j < nums.Length)
            {
                nums[j++] = 0;
            }

            return nums;
        }
    }
}
