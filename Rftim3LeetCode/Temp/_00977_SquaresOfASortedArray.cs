using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00977_SquaresOfASortedArray
    {
        /// <summary>
        /// Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
        /// </summary>
        public _00977_SquaresOfASortedArray()
        {
            int[] x = SortedSquares0([-4, -1, 0, 3, 10]);

            RftTerminal.RftReadResult(x);
        }

        private static int[] SortedSquares(int[] nums)
        {
            List<int> a = nums.Select(o => o * o).ToList();
            a.Sort();

            return [.. a];
        }

        private static int[] SortedSquares0(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                nums[i] *= nums[i];
            }
            Array.Sort(nums);

            return nums;
        }
    }
}
