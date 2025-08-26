namespace Rftim3LeetCode.Temp
{
    public class _00525_ContiguousArray
    {
        /// <summary>
        /// Given a binary array nums, return the maximum length of a contiguous subarray with an equal number of 0 and 1.
        /// </summary>
        public _00525_ContiguousArray()
        {
            Console.WriteLine(ContiguousArray0([0, 1]));
            Console.WriteLine(ContiguousArray0([0, 1, 0]));
        }

        public static int ContiguousArray0(int[] a0) => RftContiguousArray0(a0);

        private static int RftContiguousArray0(int[] nums)
        {
            Dictionary<int, int> map = [];
            map.Add(0, -1);
            int maxlen = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count += nums[i] == 1 ? 1 : -1;

                if (map.TryGetValue(count, out int value)) maxlen = Math.Max(maxlen, i - value);
                else map.Add(count, i);
            }

            return maxlen;
        }
    }
}
