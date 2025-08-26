using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02089_FindTargetIndicesAfterSortingArray
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums and a target element target.
        /// A target index is an index i such that nums[i] == target.
        /// Return a list of the target indices of nums after sorting nums in non-decreasing order.
        /// If there are no target indices, return an empty list.
        /// The returned list must be sorted in increasing order.
        /// </summary>
        public _02089_FindTargetIndicesAfterSortingArray()
        {
            IList<int> x = TargetIndices([1, 2, 5, 2, 3], 2);
            RftTerminal.RftReadResult(x);
            IList<int> x0 = TargetIndices([1, 2, 5, 2, 3], 3);
            RftTerminal.RftReadResult(x0);
            IList<int> x1 = TargetIndices([1, 2, 5, 2, 3], 5);
            RftTerminal.RftReadResult(x1);
        }

        private static List<int> TargetIndices(int[] nums, int target)
        {
            Array.Sort(nums);

            List<int> r = [];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target) r.Add(i);
            }

            return r;
        }
    }
}
