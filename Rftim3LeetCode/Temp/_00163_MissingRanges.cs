using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00163_MissingRanges
    {
        /// <summary>
        /// You are given an inclusive range [lower, upper] and a sorted unique integer array nums,
        /// where all elements are within the inclusive range.
        /// 
        /// A number x is considered missing if x is in the range[lower, upper] and x is not in nums.
        /// Return the shortest sorted list of ranges that exactly covers all the missing numbers.
        /// That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        /// </summary>
        public _00163_MissingRanges()
        {
            List<IList<int>> x = FindMissingRanges0([0, 1, 3, 50, 75], 0, 99);
            RftTerminal.RftReadResult(x);

            List<IList<int>> x0 = FindMissingRanges0([-1], -1, -1);
            RftTerminal.RftReadResult(x0);
        }

        public static List<IList<int>> FindMissingRanges0(int[] a0, int a1, int a2) => RftFindMissingRanges0(a0, a1, a2);

        public static List<IList<int>> FindMissingRanges1(int[] a0, int a1, int a2) => RftFindMissingRanges1(a0, a1, a2);

        private static List<IList<int>> RftFindMissingRanges0(int[] nums, int lower, int upper)
        {
            int n = nums.Length;
            List<IList<int>> res = [];

            if (n == 0)
            {
                res.Add([lower, upper]);

                return res;
            }

            if (lower < nums[0]) res.Add([lower, nums[0] - 1]);

            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i + 1] - nums[i] <= 1) continue;

                res.Add([nums[i] + 1, nums[i + 1] - 1]);
            }

            if (upper > nums[n - 1]) res.Add([nums[n - 1] + 1, upper]);

            return res;
        }

        private static List<IList<int>> RftFindMissingRanges1(int[] nums, int lower, int upper)
        {
            List<IList<int>> result = [];
            if (nums.Length == 0)
            {
                result.Add([lower, upper]);

                return result;
            }

            if (nums[0] != lower) result.Add([lower, nums[0] - 1]);

            lower = nums[0] + 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != lower)
                {
                    result.Add([lower, nums[i] - 1]);
                    lower = nums[i] + 1;
                }
                else lower++;
            }

            if (nums[^1] != upper) result.Add([nums[^1] + 1, upper]);

            return result;

        }
    }
}
