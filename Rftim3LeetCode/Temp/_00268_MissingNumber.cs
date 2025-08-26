namespace Rftim3LeetCode.Temp
{
    public class _00268_MissingNumber
    {
        /// <summary>
        /// Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.
        /// </summary>
        public _00268_MissingNumber()
        {
            Console.WriteLine(MissingNumber0([3, 0, 1]));
            Console.WriteLine(MissingNumber0([0, 1]));
            Console.WriteLine(MissingNumber0([9, 6, 4, 2, 3, 5, 7, 0, 1]));
        }

        public static int MissingNumber0(int[] a0) => RftMissingNumber0(a0);

        public static int MissingNumber1(int[] a0) => RftMissingNumber1(a0);

        private static int RftMissingNumber0(int[] nums)
        {
            Array.Sort(nums);

            if (nums.Length > 0 && nums[0] > 0) return 0;
            if (nums.Length == 1) return nums[0] + 1;

            int i = 1;
            while (i < nums.Length)
            {
                if (nums[i - 1] + 1 != nums[i]) return nums[i - 1] + 1;
                i++;
                if (i == nums.Length) return nums[i - 1] + 1;
            }

            return 0;
        }

        private static int RftMissingNumber1(int[] nums)
        {
            int n = nums.Length;
            int max = nums.Max();
            List<int> x = [];

            if (n == max) x.AddRange(Enumerable.Range(0, max + 1));
            else x.AddRange(Enumerable.Range(0, n + 1));

            for (int i = 0; i < n; i++)
            {
                x.Remove(nums[i]);
            }

            return x[0];
        }
    }
}
