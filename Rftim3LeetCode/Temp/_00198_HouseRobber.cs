namespace Rftim3LeetCode.Temp
{
    public class _00198_HouseRobber
    {
        /// <summary>
        /// You are a professional robber planning to rob houses along a street. 
        /// Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent 
        /// houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
        /// Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.
        /// </summary>
        public _00198_HouseRobber()
        {
            Console.WriteLine(Rob(new int[] { 1, 2, 3, 1 }));
            Console.WriteLine(Rob(new int[] { 2, 7, 9, 3, 1 }));
        }

        private static int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int l = 0;
            int c = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int r = l;
                l = c;
                c = Math.Max(l, r + nums[i]);
            }

            return c;
        }
    }
}
