namespace Rftim3LeetCode.Temp
{
    public class _00169_MajorityElement
    {
        /// <summary>
        /// Given an array nums of size n, return the majority element.
        /// The majority element is the element that appears more than ⌊n / 2⌋ times.
        /// You may assume that the majority element always exists in the array.
        /// </summary>
        public _00169_MajorityElement()
        {
            Console.WriteLine(MajorityElement0([3, 2, 3]));
            Console.WriteLine(MajorityElement0([2, 2, 1, 1, 1, 2, 2]));
        }

        public static int MajorityElement0(int[] a0) => RftMajorityElement0(a0);

        public static int MajorityElement1(int[] a0) => RftMajorityElement1(a0);

        private static int RftMajorityElement0(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return nums[0];

            Dictionary<int, int> x = [];

            for (int i = 0; i < n; i++)
            {
                if (!x.TryGetValue(nums[i], out int value)) x.Add(nums[i], 1);
                else
                {
                    x[nums[i]] = ++value;
                    if (value >= n / 2 + 1) return nums[i];
                }
            }

            return 0;
        }

        private static int RftMajorityElement1(int[] nums)
        {
            int count = 0, candidate = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0) candidate = nums[i];
                count += nums[i] == candidate ? 1 : -1;
            }

            return candidate;
        }
    }
}
