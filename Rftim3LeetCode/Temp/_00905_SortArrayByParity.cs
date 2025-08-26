using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00905_SortArrayByParity
    {
        /// <summary>
        /// Given an integer array nums, move all the even integers at the beginning of the array followed by all the odd integers.
        /// Return any array that satisfies this condition.
        /// </summary>
        public _00905_SortArrayByParity()
        {
            int[] x = SortArrayByParity0([3, 1, 2, 4]);

            RftTerminal.RftReadResult(x);
        }

        private static int[] SortArrayByParity0(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] % 2 == 1)
                {
                    if (nums[n - 1] % 2 == 0) (nums[n - 1], nums[i]) = (nums[i], nums[n - 1]);
                    else
                    {
                        i--;
                        n--;
                    }
                }
            }

            return nums;
        }
    }
}
