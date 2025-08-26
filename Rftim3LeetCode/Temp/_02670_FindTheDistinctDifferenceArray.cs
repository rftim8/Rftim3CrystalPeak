using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02670_FindTheDistinctDifferenceArray
    {
        /// <summary>
        /// You are given a 0-indexed array nums of length n.
        /// The distinct difference array of nums is an array diff of length n such that diff[i] is equal to 
        /// the number of distinct elements in the suffix nums[i + 1, ..., n - 1] subtracted from the number of distinct elements in the prefix nums[0, ..., i].
        /// Return the distinct difference array of nums.
        /// Note that nums[i, ..., j] denotes the subarray of nums starting at index i and ending at index j inclusive.
        /// Particularly, if i > j then nums[i, ..., j] denotes an empty subarray.
        /// </summary>
        public _02670_FindTheDistinctDifferenceArray()
        {
            int[] x = DistinctDifferenceArray([1, 2, 3, 4, 5]);
            RftTerminal.RftReadResult(x);
            int[] x0 = DistinctDifferenceArray([3, 2, 3, 4, 2]);
            RftTerminal.RftReadResult(x0);
        }

        private static int[] DistinctDifferenceArray(int[] nums)
        {
            int n = nums.Length;
            List<int> l = [];
            List<int> r = [.. nums];

            int[] x = new int[n];
            for (int i = 0; i < n; i++)
            {
                l.Add(r[0]);
                r.RemoveAt(0);

                x[i] = l.Distinct().Count() - r.Distinct().Count();
            }

            return x;
        }
    }
}
