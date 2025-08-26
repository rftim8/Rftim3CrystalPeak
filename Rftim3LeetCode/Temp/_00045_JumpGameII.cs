namespace Rftim3LeetCode.Temp
{
    public class _00045_JumpGameII
    {
        /// <summary>
        /// You are given a 0-indexed array of integers nums of length n. 
        /// You are initially positioned at nums[0].
        /// Each element nums[i] represents the maximum length of a forward jump from index i.
        /// In other words, if you are at nums[i], you can jump to any nums[i + j] where:
        /// 0 <= j <= nums[i] and
        /// i + j<n
        /// Return the minimum number of jumps to reach nums[n - 1]. 
        /// The test cases are generated such that you can reach nums[n - 1].
        /// </summary>
        public _00045_JumpGameII()
        {
            Console.WriteLine(JumpGameII0([1, 2, 3]));
            Console.WriteLine(JumpGameII0([2, 3, 1, 1, 4]));
            Console.WriteLine(JumpGameII0([2, 3, 0, 1, 4]));
        }

        public static int JumpGameII0(int[] a0) => RftJumpGameII0(a0);

        private static int RftJumpGameII0(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return 0;

            int c = 0, b = 0, crt = 0;

            for (int i = 0; i < n - 1; i++)
            {
                b = b > nums[i] + i ? b : nums[i] + i;

                if (crt == i)
                {
                    crt = b;
                    c++;
                }
                if (crt > n - 1) return c;
            }

            return c;
        }
    }
}
