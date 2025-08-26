using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00238_ProductOfArrayExceptSelf
    {
        /// <summary>
        /// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
        /// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        /// You must write an algorithm that runs in O(n) time and without using the division operation.
        /// </summary>
        public _00238_ProductOfArrayExceptSelf()
        {
            int[] a0 = ProductOfArrayExceptSelf0([1, 2, 3, 4]);
            RftTerminal.RftReadResult(a0);

            int[] a1 = ProductOfArrayExceptSelf0([-1, 1, 0, -3, 3]);
            RftTerminal.RftReadResult(a1);
        }

        public static int[] ProductOfArrayExceptSelf0(int[] a0) => RftProductOfArrayExceptSelf0(a0);

        public static int[] ProductOfArrayExceptSelf1(int[] a0) => RftProductOfArrayExceptSelf1(a0);

        public static int[] ProductOfArrayExceptSelf2(int[] a0) => RftProductOfArrayExceptSelf2(a0);

        private static int[] RftProductOfArrayExceptSelf0(int[] nums)
        {
            int n = nums.Length;
            int[] y = new int[n];

            int x = 1, l = 1;
            for (int i = 0; i < n; i++)
            {
                if (i > 0) l *= nums[i - 1];
                int r = n - 1;

                while (r > i)
                {
                    x *= nums[r];
                    r--;
                }
                x *= l;
                y[i] = x;
                x = 1;
            }

            return y;
        }

        private static int[] RftProductOfArrayExceptSelf1(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[nums.Length];

            res[0] = 1;
            for (int i = 1; i < n; i++)
            {
                res[i] = nums[i - 1] * res[i - 1];
            }

            int right = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                res[i] = res[i] * right;
                right *= nums[i];
            }

            return res;
        }

        private static int[] RftProductOfArrayExceptSelf2(int[] nums)
        {
            int len = nums.Length;

            int[] res = new int[len];
            int prefix = 1;

            for (int i = 0; i < len; i++)
            {
                res[i] = prefix;
                prefix *= nums[i];
            }

            int postfix = 1;

            for (int i = len - 1; i >= 0; i--)
            {
                res[i] = postfix * res[i];
                postfix *= nums[i];
            }

            return res;
        }
    }
}
