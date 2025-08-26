using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00039_CombinationSum
    {
        /// <summary>
        /// Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations 
        /// of candidates where the chosen numbers sum to target. You may return the combinations in any order.
        /// The same number may be chosen from candidates an unlimited number of times.Two combinations are unique if the
        /// frequency
        ///  of at least one of the chosen numbers is different.
        /// The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.
        /// </summary>
        public _00039_CombinationSum()
        {
            IList<IList<int>> x = CombinationSum0([2, 3, 6, 7], 7);

            RftTerminal.RftReadResult(x);
        }

        private static readonly List<IList<int>> x = [];

        public static List<IList<int>> CombinationSum0(int[] a0, int a1) => RftCombinationSum0(a0, a1);

        private static List<IList<int>> RftCombinationSum0(int[] candidates, int target)
        {
            x.Clear();
            Dfs(candidates, 0, target, []);

            return x;
        }

        private static void Dfs(int[] c, int i, int target, IList<int> crt)
        {
            if (target == 0)
            {
                x.Add([]);

                foreach (int n in crt)
                {
                    x[^1].Add(n);
                }
            }
            else if (target < 0) return;

            for (int j = i; j < c.Length; j++)
            {
                crt.Add(c[j]);
                Dfs(c, j, target - c[j], crt);
                crt.RemoveAt(crt.Count - 1);
            }
        }

        private static List<IList<int>> RftCombinationSum1(int[] candidates, int target)
        {
            List<IList<int>> result = [];
            List<int> temp = [];
            Array.Sort(candidates);
            Backtrack(candidates, target, temp, result, 0);

            return result;
        }

        private static void Backtrack(int[] nums, int target, List<int> temp, List<IList<int>> res, int start)
        {
            if (target < 0) return;
            if (target == 0)
            {
                res.Add([.. temp]);

                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                temp.Add(nums[i]);
                Backtrack(nums, target - nums[i], temp, res, i);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
