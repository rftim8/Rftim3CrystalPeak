using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00001_TwoSum
    {
        /// <summary>
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// </summary>
        public _00001_TwoSum()
        {
            int[] x = TwoSum0([2, 7, 11, 15], 9);
            RftTerminal.RftReadResult(x);

            int[] x0 = TwoSum0([3, 2, 4], 6);
            RftTerminal.RftReadResult(x0);

            int[] x1 = TwoSum0([3, 3], 6);
            RftTerminal.RftReadResult(x1);
        }

        public static int[] TwoSum0(int[] a0, int a1) => RftTwoSum0(a0, a1);

        private static int[] RftTwoSum0(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j && nums[i] + nums[j] == target)
                    {
                        int[] x = [i, j];
                        return x;
                    }
                }
            }

            return [];
        }
    }
}
