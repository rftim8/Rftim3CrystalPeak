using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00260_SingleNumberIII
    {
        /// <summary>
        /// Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. 
        /// Find the two elements that appear only once. You can return the answer in any order.
        /// 
        /// You must write an algorithm that runs in linear runtime complexity and uses only constant extra space.
        /// </summary>
        public _00260_SingleNumberIII()
        {
            int[] a0 = SingleNumberIII0([1, 2, 1, 3, 2, 5]);
            RftTerminal.RftReadResult(a0);

            int[] b0 = SingleNumberIII0([-1, 0]);
            RftTerminal.RftReadResult(b0);

            int[] c0 = SingleNumberIII0([0, 1]);
            RftTerminal.RftReadResult(c0);
        }

        public static int[] SingleNumberIII0(int[] a0) => RftSingleNumberIII0(a0);

        public static int[] SingleNumberIII1(int[] a0) => RftSingleNumberIII1(a0);

        public static int[] SingleNumberIII2(int[] a0) => RftSingleNumberIII2(a0);

        private static int[] RftSingleNumberIII0(int[] nums)
        {
            int n = nums.Length;
            if (n == 2) return nums;

            Array.Sort(nums);
            int[] res = new int[2];
            int c = 0;
            if (nums[0] != nums[1])
            {
                res[c] = nums[0];
                c++;
            }
            for (int i = 1; i < n - 1; i++)
            {
                if (nums[i - 1] != nums[i] && nums[i] != nums[i + 1])
                {
                    res[c] = nums[i];
                    c++;
                    if (c == 2) return res;
                }
            }
            if (c == 1) res[1] = nums[^1];

            return res;
        }

        private static int[] RftSingleNumberIII1(int[] nums)
        {
            int xor = nums.Aggregate((current, num) => current ^ num);

            int rightmostSetBit = xor & ~(xor - 1);
            int[] result = new int[2];

            foreach (int num in nums)
            {
                if ((num & rightmostSetBit) != 0) result[0] ^= num;
                else result[1] ^= num;
            }

            return result;
        }

        private static int[] RftSingleNumberIII2(int[] nums)
        {
            HashSet<int> found = [];
            foreach (int num in nums)
            {
                if (!found.Remove(num)) found.Add(num);
            }

            return [.. found];
        }
    }
}
