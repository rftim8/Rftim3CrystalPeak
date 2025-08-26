using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00228_SummaryRanges
    {
        /// <summary>
        /// You are given a sorted unique integer array nums.
        /// A range[a, b] is the set of all integers from a to b(inclusive).
        /// Return the smallest sorted list of ranges that cover all the numbers in the array exactly.
        /// That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.
        /// Each range[a, b] in the list should be output as:
        /// "a->b" if a != b
        /// "a" if a == b
        /// </summary>
        public _00228_SummaryRanges()
        {
            IList<string> x = SummaryRanges0([0, 1, 2, 4, 5, 7]);
            RftTerminal.RftReadResult(x);

            IList<string> x0 = SummaryRanges0([0, 2, 3, 4, 6, 8, 9]);
            RftTerminal.RftReadResult(x0);
        }

        public static IList<string> SummaryRanges0(int[] a0) => RftSummaryRanges0(a0);

        public static IList<string> SummaryRanges1(int[] a0) => RftSummaryRanges1(a0);

        private static List<string> RftSummaryRanges0(int[] nums)
        {
            int n = nums.Length;
            List<string> x = [];

            if (n == 0) return x;

            if (n == 1)
            {
                x.Add(nums[0].ToString());

                return x;
            }

            int l = nums[0], r = nums[0];
            for (int i = 1; i < n; i++)
            {
                int t = nums[i];
                if (t == nums[i - 1] + 1) r = t;
                else
                {
                    if (l == r) x.Add($"{l}");
                    else x.Add($"{l}->{r}");

                    l = t;
                    r = t;
                }
                if (i == n - 1)
                {
                    if (l == r) x.Add($"{l}");
                    else x.Add($"{l}->{r}");
                }
            }

            return x;
        }

        private static List<string> RftSummaryRanges1(int[] nums)
        {
            int n = nums.Length;
            List<string> res = [];
            int i = 0;
            while (i < n)
            {
                int k = i;
                while (k < n - 1 && nums[k + 1] == nums[k] + 1) k++;

                if (i == k) res.Add($"{nums[i]}");
                else res.Add($"{nums[i]}->{nums[k]}");

                i = k + 1;
            }

            return res;
        }
    }
}
