using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01403_MinimumSubsequenceInNonIncreasingOrder
    {
        /// <summary>
        /// Given the array nums, obtain a subsequence of the array whose sum of elements is strictly greater than the sum of the non included elements in such subsequence. 
        /// If there are multiple solutions, return the subsequence with minimum size and if there still exist multiple solutions, 
        /// return the subsequence with the maximum total sum of all its elements.
        /// A subsequence of an array can be obtained by erasing some(possibly zero) elements from the array.
        /// Note that the solution with the given constraints is guaranteed to be unique.
        /// Also return the answer sorted in non-increasing order.
        /// </summary>
        public _01403_MinimumSubsequenceInNonIncreasingOrder()
        {
            IList<int> x = MinSubsequence([4, 3, 10, 9, 8]);
            IList<int> x0 = MinSubsequence([4, 4, 7, 6, 7]);
            IList<int> x1 = MinSubsequence([6]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static List<int> MinSubsequence(int[] nums)
        {
            int n = nums.Length;
            int t = nums.Sum();
            Array.Sort(nums);

            List<int> r = [];
            int c = 0;
            for (int i = n - 1; i > -1; i--)
            {
                if (t < c) return r;
                else r.Add(nums[i]);
                c += nums[i];
                t -= nums[i];
            }

            return r;
        }
    }
}
