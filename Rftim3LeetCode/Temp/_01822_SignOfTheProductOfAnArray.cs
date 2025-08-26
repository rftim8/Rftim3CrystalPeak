namespace Rftim3LeetCode.Temp
{
    public class _01822_SignOfTheProductOfAnArray
    {
        /// <summary>
        /// There is a function signFunc(x) that returns:
        /// 1 if x is positive.
        /// -1 if x is negative.
        /// 0 if x is equal to 0.
        /// You are given an integer array nums.Let product be the product of all values in the array nums.
        /// Return signFunc(product).
        /// </summary>
        public _01822_SignOfTheProductOfAnArray()
        {
            Console.WriteLine(ArraySign([-1, -2, -3, -4, 3, 2, 1]));
            Console.WriteLine(ArraySign([1, 5, 0, 2, -3]));
            Console.WriteLine(ArraySign([-1, 1, -1, 1, -1]));
            Console.WriteLine(ArraySign([-1]));
            Console.WriteLine(ArraySign([0]));
            Console.WriteLine(ArraySign([1]));
        }

        private static int ArraySign(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0) return 0;
                else if (nums[i] > 0) break;
                else c++;
            }

            return c % 2 == 0 ? 1 : -1;
        }
    }
}
