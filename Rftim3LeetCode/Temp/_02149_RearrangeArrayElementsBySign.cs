using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02149_RearrangeArrayElementsBySign
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums of even length consisting of an equal number of positive and negative integers.
        /// 
        /// You should rearrange the elements of nums such that the modified array follows the given conditions:
        /// 
        /// Every consecutive pair of integers have opposite signs.
        /// For all integers with the same sign, the order in which they were present in nums is preserved.
        /// The rearranged array begins with a positive integer.
        /// Return the modified array after rearranging the elements to satisfy the aforementioned conditions.
        /// </summary>
        public _02149_RearrangeArrayElementsBySign()
        {
            int[] a0 = RearrangeArrayElementsBySign0([3, 1, -2, -5, 2, -4]);
            RftTerminal.RftReadResult(a0);

            int[] a1 = RearrangeArrayElementsBySign0([-1, 1]);
            RftTerminal.RftReadResult(a1);
        }

        public static int[] RearrangeArrayElementsBySign0(int[] a0) => RftRearrangeArrayElementsBySign0(a0);

        // Two Pointers
        private static int[] RftRearrangeArrayElementsBySign0(int[] nums)
        {
            int n = nums.Length;
            int[] ans = new int[n];
            int posIndex = 0, negIndex = 1;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    ans[posIndex] = nums[i];
                    posIndex += 2;
                }
                else
                {
                    ans[negIndex] = nums[i];
                    negIndex += 2;
                }
            }

            return ans;
        }
    }
}
