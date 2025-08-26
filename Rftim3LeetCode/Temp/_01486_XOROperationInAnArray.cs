namespace Rftim3LeetCode.Temp
{
    public class _01486_XOROperationInAnArray
    {
        /// <summary>
        /// You are given an integer n and an integer start.
        /// Define an array nums where nums[i] = start + 2 * i(0 - indexed) and n == nums.length.
        /// Return the bitwise XOR of all elements of nums.
        /// </summary>
        public _01486_XOROperationInAnArray()
        {
            Console.WriteLine(XorOperation(5, 0));
            Console.WriteLine(XorOperation(4, 3));
        }

        private static int XorOperation(int n, int start)
        {
            int c = start;
            for (int i = 1; i < n; i++)
            {
                c ^= start + 2 * i;
            }

            return c;
        }
    }
}
