using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02553_SeparateTheDigitsInAnArray
    {
        /// <summary>
        /// Given an array of positive integers nums, return an array answer that consists of the digits of each 
        /// integer in nums after separating them in the same order they appear in nums.
        /// To separate the digits of an integer is to get all the digits it has in the same order.
        /// For example, for the integer 10921, the separation of its digits is [1,0,9,2,1].
        /// </summary>
        public _02553_SeparateTheDigitsInAnArray()
        {
            int[] x = SeparateDigits([13, 25, 83, 77]);
            RftTerminal.RftReadResult(x);
            int[] x0 = SeparateDigits([7, 1, 3, 9]);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] SeparateDigits(int[] nums)
        {
            List<int> r = [];
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                foreach (char item in nums[i].ToString())
                {
                    r.Add(item - '0');
                }
            }

            return [.. r];
        }
    }
}
