namespace Rftim3LeetCode.Temp
{
    public class _02239_FindClosestNumberToZero
    {
        /// <summary>
        /// Given an integer array nums of size n, return the number with the value closest to 0 in nums.
        /// If there are multiple answers, return the number with the largest value.
        /// </summary>
        public _02239_FindClosestNumberToZero()
        {
            Console.WriteLine(FindClosestNumber([-4, -2, 1, 4, 8]));
            Console.WriteLine(FindClosestNumber([2, -1, 1]));
        }

        private static int FindClosestNumber(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            int l = int.MinValue, r = int.MaxValue;
            int x = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0) return 0;
                else if (nums[i] < 0) l = Math.Max(l, nums[i]);
                else
                {
                    r = Math.Min(r, nums[i]);
                    break;
                }
            }
            if (l == int.MinValue) return r;
            if (r == int.MaxValue) return l;
            x = Math.Abs(l) < r ? l : r;

            return x;
        }
    }
}
