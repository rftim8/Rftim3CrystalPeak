namespace Rftim3LeetCode.Temp
{
    public class _00137_SingleNumber2
    {
        /// <summary>
        /// Given an integer array nums where every element appears three times except for one, which appears exactly once. 
        /// Find the single element and return it.
        /// You must implement a solution with a linear runtime complexity and use only constant extra space.
        /// </summary>
        public _00137_SingleNumber2()
        {
            Console.WriteLine(SingleNumber(new int[] { 2, 2, 3, 2 }));
            Console.WriteLine(SingleNumber(new int[] { 0, 1, 0, 1, 0, 1, 99 }));
        }

        private static int SingleNumber(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> x = new();

            for (int i = 0; i < n; i++)
            {
                if (!x.ContainsKey(nums[i])) x.Add(nums[i], 1);
                else
                {
                    x[nums[i]]++;
                    if (x[nums[i]] == 3) x.Remove(nums[i]);
                }
            }

            return x.First().Key;
        }

        private static int SingleNumber0(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int o = 0;
            int t = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                o ^= nums[i] & ~t;
                t ^= nums[i] & ~o;
            }

            return o;
        }
    }
}
