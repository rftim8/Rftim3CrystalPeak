using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02903_FindIndicesWithIndexAndValueDifference1
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums having length n, an integer indexDifference, and an integer valueDifference.
        /// 
        /// Your task is to find two indices i and j, both in the range[0, n - 1], that satisfy the following conditions:
        /// 
        /// abs(i - j) >= indexDifference, and
        /// abs(nums[i] - nums[j]) >= valueDifference
        /// Return an integer array answer, where answer = [i, j] if there are two such indices, and answer = [-1, -1] otherwise.
        /// If there are multiple choices for the two indices, return any of them.
        /// 
        /// Note: i and j may be equal.
        /// </summary>
        public _02903_FindIndicesWithIndexAndValueDifference1()
        {
            int[] x0 = FindIndices0([5, 1, 4, 1], 2, 4);
            RftTerminal.RftReadResult(x0);

            int[] x1 = FindIndices0([2, 1], 0, 0);
            RftTerminal.RftReadResult(x1);

            int[] x2 = FindIndices0([1, 2, 3], 2, 4);
            RftTerminal.RftReadResult(x2);

            int[] x3 = FindIndices0([5, 48], 0, 29);
            RftTerminal.RftReadResult(x3);

            int[] x4 = FindIndices0([4, 22, 43], 0, 34);
            RftTerminal.RftReadResult(x4);
        }

        public static int[] FindIndices0(int[] a0, int a1, int a2) => RftFindIndices0(a0, a1, a2);

        private static int[] RftFindIndices0(int[] nums, int indexDifference, int valueDifference)
        {
            int[] r = [-1, -1];
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + indexDifference; j < n; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) >= valueDifference) return [i, j];
                }
            }

            return r;
        }
    }
}
