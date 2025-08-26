namespace Rftim3LeetCode.Temp
{
    public class _01608_SpecialArrayWithXElementsGreaterThanOrEqualX
    {
        /// <summary>
        /// You are given an array nums of non-negative integers. 
        /// nums is considered special if there exists a number x such that 
        /// there are exactly x numbers in nums that are greater than or equal to x.
        /// Notice that x does not have to be an element in nums.
        /// Return x if the array is special, otherwise, return -1. 
        /// It can be proven that if nums is special, the value for x is unique.
        /// </summary>
        public _01608_SpecialArrayWithXElementsGreaterThanOrEqualX()
        {
            Console.WriteLine(SpecialArrayWithXElementsGreaterThanOrEqualX0([3, 5]));
            Console.WriteLine(SpecialArrayWithXElementsGreaterThanOrEqualX0([0, 0]));
            Console.WriteLine(SpecialArrayWithXElementsGreaterThanOrEqualX0([0, 4, 3, 0, 4]));
        }

        public static int SpecialArrayWithXElementsGreaterThanOrEqualX0(int[] a0) => RftSpecialArrayWithXElementsGreaterThanOrEqualX0(a0);

        public static int SpecialArrayWithXElementsGreaterThanOrEqualX1(int[] a0) => RftSpecialArrayWithXElementsGreaterThanOrEqualX1(a0);

        private static int RftSpecialArrayWithXElementsGreaterThanOrEqualX0(int[] nums)
        {
            int n = nums.Length;

            Dictionary<int, int> x = [];
            for (int i = 0; i < n; i++)
            {
                if (!x.TryAdd(nums[i], 1)) x[nums[i]]++;
            }

            int c = 0;
            while (c <= n)
            {
                if (n == c) return c;
                if (x.TryGetValue(c, out int count)) n -= count;
                c++;
            }

            return -1;
        }

        private static int RftSpecialArrayWithXElementsGreaterThanOrEqualX1(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i <= n; i++)
            {
                int c = 0;
                for (int j = 0; j < n; j++)
                {
                    if (nums[j] >= i) c++;
                }
                if (i == c) return i;
            }

            return -1;
        }
    }
}