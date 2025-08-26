using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00922_SortArrayByParity2
    {
        /// <summary>
        /// Given an array of integers nums, half of the integers in nums are odd, and the other half are even.
        /// Sort the array so that whenever nums[i] is odd, i is odd, and whenever nums[i] is even, i is even.
        /// Return any answer array that satisfies this condition.
        /// </summary>
        public _00922_SortArrayByParity2()
        {
            int[] x = SortArrayByParityII([4, 2, 5, 7]);
            int[] x0 = SortArrayByParityII([2, 3]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] SortArrayByParityII(int[] nums)
        {
            int n = nums.Length;
            int[] r = new int[n];

            int odd = 1;
            int even = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    r[even] = nums[i];
                    even += 2;
                }
                else
                {
                    r[odd] = nums[i];
                    odd += 2;
                }
            }

            return r;
        }
    }
}
