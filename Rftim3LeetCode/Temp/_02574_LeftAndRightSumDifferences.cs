using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02574_LeftAndRightSumDifferences
    {
        /// <summary>
        /// Given a 0-indexed integer array nums, find a 0-indexed integer array answer where:
        /// answer.length == nums.length.
        /// answer[i] = |leftSum[i] - rightSum[i]|.
        /// Where:
        /// leftSum[i] is the sum of elements to the left of the index i in the array nums.
        /// If there is no such element, leftSum[i] = 0.
        /// rightSum[i] is the sum of elements to the right of the index i in the array nums.
        /// If there is no such element, rightSum[i] = 0.
        /// Return the array answer.
        /// </summary>
        public _02574_LeftAndRightSumDifferences()
        {
            int[] x = LeftRightDifference([10, 4, 8, 3]);
            RftTerminal.RftReadResult(x);
            int[] x0 = LeftRightDifference([1]);
            RftTerminal.RftReadResult(x0);
            int[] x1 = LeftRightDifference([8, 28, 35, 21, 13, 21, 72, 35, 52, 74]);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] LeftRightDifference(int[] nums)
        {
            List<int> l = [0];
            List<int> r = [];

            int n = nums.Length;
            if (n == 1) return [0];

            int c = 0;
            for (int i = 0; i < n - 1; i++)
            {
                c += nums[i];
                l.Add(c);
            }
            for (int i = 1; i < n; i++)
            {
                r.Add(nums[i..].Sum());
            }
            r.Add(0);

            int[] x = new int[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = Math.Abs(l[i] - r[i]);
            }

            return x;
        }

        private static int[] LeftRightDifference0(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];

            for (int i = 1, sum = 0; i < n; i++) res[i] = sum += nums[i - 1];
            for (int i = n - 2, sum = 0; i >= 0; i--) res[i] = Math.Abs(res[i] - (sum += nums[i + 1]));

            return res;
        }
    }
}
