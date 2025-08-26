namespace Rftim3LeetCode.Temp
{
    public class _00209_MinimumSizeSubarraySum
    {
        /// <summary>
        /// Given an array of positive integers nums and a positive integer target, return the minimal length of a subarray
        /// whose sum is greater than or equal to target.If there is no such subarray, return 0 instead.
        /// </summary>
        public _00209_MinimumSizeSubarraySum()
        {
            Console.WriteLine(MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 }));
            Console.WriteLine(MinSubArrayLen(4, new int[] { 1, 4, 4 }));
            Console.WriteLine(MinSubArrayLen(11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }));
            Console.WriteLine(MinSubArrayLen(11, new int[] { 1, 2, 3, 4, 5 }));
        }

        private static int MinSubArrayLen0(int target, int[] nums)
        {
            int n = nums.Length;
            int c = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int x = 0, y = 0;
                for (int j = i; j < n; j++)
                {
                    y += nums[j];
                    if (y < target) x++;
                    else
                    {
                        x++;
                        if (x < c) c = x;
                        break;
                    }
                }
            }

            return c == int.MaxValue ? 0 : c;
        }

        private static int MinSubArrayLen(int target, int[] nums)
        {
            int n = nums.Length;
            int x = int.MaxValue;
            int l = 0;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                while (sum >= target)
                {
                    x = Math.Min(x, i + 1 - l);
                    sum -= nums[l++];
                }
            }

            return x != int.MaxValue ? x : 0;
        }
    }
}
