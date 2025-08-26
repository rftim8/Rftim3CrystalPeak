using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00448_FindAllNumbersDisappearedInAnArray
    {
        /// <summary>
        /// Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.
        /// </summary>
        public _00448_FindAllNumbersDisappearedInAnArray()
        {
            IList<int> x = FindDisappearedNumbers0([4, 3, 2, 7, 8, 2, 3, 1]);
            RftTerminal.RftReadResult(x);

            IList<int> x0 = FindDisappearedNumbers0([1, 1]);
            RftTerminal.RftReadResult(x0);
        }

        public static IList<int> FindDisappearedNumbers0(int[] a0) => RftFindDisappearedNumbers0(a0);

        private static List<int> RftFindDisappearedNumbers0(int[] nums)
        {
            int n = nums.Length;
            HashSet<int> x = Enumerable.Range(1, n).ToHashSet();

            for (int i = 0; i < n; i++)
            {
                if (x.Contains(nums[i])) x.Remove(nums[i]);
            }

            return [.. x];
        }
    }
}
