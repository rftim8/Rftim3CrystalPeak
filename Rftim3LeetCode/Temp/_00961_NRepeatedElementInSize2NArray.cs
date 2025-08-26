namespace Rftim3LeetCode.Temp
{
    public class _00961_NRepeatedElementInSize2NArray
    {
        /// <summary>
        /// You are given an integer array nums with the following properties:
        /// nums.length == 2 * n.
        /// nums contains n + 1 unique elements.
        /// Exactly one element of nums is repeated n times.
        /// Return the element that is repeated n times.
        /// </summary>
        public _00961_NRepeatedElementInSize2NArray()
        {
            Console.WriteLine(RepeatedNTimes([1, 2, 3, 3]));
            Console.WriteLine(RepeatedNTimes([2, 1, 2, 5, 3, 2]));
            Console.WriteLine(RepeatedNTimes([5, 1, 5, 2, 5, 3, 5, 4]));
        }

        private static int RepeatedNTimes(int[] nums)
        {
            int n = nums.Length;
            int m = n / 2;

            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (r.TryGetValue(nums[i], out int value))
                {
                    r[nums[i]] = ++value;
                    if (value == m) return nums[i];
                }
                else r[nums[i]] = 1;
            }

            return -1;
        }

        private static int RepeatedNTimes0(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int count = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j]) count++;
                }
                if (count == nums.Length / 2) return nums[i];
            }

            return 0;
        }
    }
}
