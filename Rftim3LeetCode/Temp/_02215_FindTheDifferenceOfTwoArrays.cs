using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02215_FindTheDifferenceOfTwoArrays
    {
        /// <summary>
        /// Given two 0-indexed integer arrays nums1 and nums2, return a list answer of size 2 where:
        /// answer[0] is a list of all distinct integers in nums1 which are not present in nums2.
        /// answer[1] is a list of all distinct integers in nums2 which are not present in nums1.
        /// Note that the integers in the lists may be returned in any order.
        /// </summary>
        public _02215_FindTheDifferenceOfTwoArrays()
        {
            IList<IList<int>> x = FindDifference([1, 2, 3], [2, 4, 6]);
            IList<IList<int>> x0 = FindDifference([1, 2, 3, 3], [1, 1, 2, 2]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static List<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            List<int> y0 = [.. nums1];
            List<int> y1 = [.. nums2];

            List<IList<int>> x =
            [
                y0.Except(y1).ToList(),
                y1.Except(y0).ToList()
            ];

            return x;
        }

        private static IList<IList<int>> FindDifference0(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = [.. nums1];
            HashSet<int> set2 = [.. nums2];

            set1.ExceptWith(set2);
            set2.ExceptWith(nums1);

            return new int[][] { [.. set1], [.. set2] };
        }
    }
}
