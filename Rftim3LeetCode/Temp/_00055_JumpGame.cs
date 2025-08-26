namespace Rftim3LeetCode.Temp
{
    public class _00055_JumpGame
    {
        /// <summary>
        /// You are given an integer array nums. You are initially positioned at the array's first index, 
        /// and each element in the array represents your maximum jump length at that position.
        /// Return true if you can reach the last index, or false otherwise.
        /// </summary>
        public _00055_JumpGame()
        {
            Console.WriteLine(JumpGame0([2, 3, 1, 1, 4]));
            Console.WriteLine(JumpGame0([3, 2, 0, 1, 4]));
            Console.WriteLine(JumpGame0([0, 2, 3]));
        }

        public static bool JumpGame0(int[] a0) => RftJumpGame0(a0);

        private static bool RftJumpGame0(int[] nums)
        {
            int n = nums.Length - 1;

            for (int i = n - 1; i > -1; i--)
            {
                if (i + nums[i] >= n) n = i;
            };

            return n == 0;
        }
    }
}
