using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00303_RangeSumQueryImmutable
    {
        /// <summary>
        /// Given an integer array nums, handle multiple queries of the following type:
        /// Calculate the sum of the elements of nums between indices left and right inclusive where left <= right.
        /// Implement the NumArray class:
        /// NumArray(int[] nums) Initializes the object with the integer array nums.
        /// int sumRange(int left, int right) Returns the sum of the elements of nums between indices left and right inclusive(i.e.nums[left] + nums[left + 1] + ... + nums[right]).
        /// </summary>
        public _00303_RangeSumQueryImmutable()
        {
            List<object?> x = RangeSumQueryImmutable0(
                ["NumArray", "sumRange", "sumRange", "sumRange"],
                [[-2, 0, 3, -5, 2, -1], [0, 2], [2, 5], [0, 5]]
                );
            RftTerminal.RftReadResult(x);
        }

        public static List<object?> RangeSumQueryImmutable0(List<string> a0, IList<IList<int>> a1) => RftRangeSumQueryImmutable0(a0, a1);

        private static List<object?> RftRangeSumQueryImmutable0(List<string> a, IList<IList<int>> b)
        {
            List<object?> r = [];
            NumArray obj = new([]);

            for (int i = 0; i < a.Count; i++)
            {
                switch (a[i])
                {
                    case "NumArray":
                        obj.nums = [.. b[i]];
                        r.Add(null);
                        break;
                    case "sumRange":
                        int[] c = [.. b[i]];
                        r.Add(obj.SumRange(c[0], c[1]));
                        break;
                    default:
                        break;
                }
            }

            return r;
        }

        private class NumArray(int[] nums)
        {
            public int[] nums = nums;

            public int SumRange(int left, int right)
            {
                return nums[left..(right + 1)].Sum();
            }
        }
    }
}
