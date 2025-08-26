namespace Rftim3LeetCode.Temp
{
    public class _00213_HouseRobber2
    {
        /// <summary>
        /// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed. 
        /// All houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. 
        /// Meanwhile, adjacent houses have a security system connected, and it will automatically contact the police if two adjacent houses were broken into on the same night.
        /// Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.
        /// </summary>
        public _00213_HouseRobber2()
        {
            Console.WriteLine(Rob(new int[] { 2, 3, 2 }));
            Console.WriteLine(Rob(new int[] { 1, 2, 3, 1 }));
            Console.WriteLine(Rob(new int[] { 1, 2, 3 }));
        }

        private static int Rob(int[] nums)
        {
            int n = nums.Length;
            if (nums is null || n == 0) return 0;
            if (n == 1) return nums[0];
            if (n == 2) return Math.Max(nums[0], nums[1]);

            int first = Rob(nums, 0, n - 2);
            int last = Rob(nums, 1, n - 1);

            return Math.Max(first, last);
        }

        private static int Rob(int[] nums, int l, int r)
        {
            int x = nums[l];
            int y = Math.Max(nums[l], nums[l + 1]);

            for (int i = l + 2; i <= r; i++)
            {
                int z = Math.Max(x + nums[i], y);
                x = y;
                y = z;
            }

            return Math.Max(x, y);
        }
    }
}
