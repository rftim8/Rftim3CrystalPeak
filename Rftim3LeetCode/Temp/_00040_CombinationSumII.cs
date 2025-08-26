using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00040_CombinationSumII
    {
        /// <summary>
        /// Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations 
        /// in candidates where the candidate numbers sum to target.
        /// Each number in candidates may only be used once in the combination.
        /// Note: The solution set must not contain duplicate combinations.
        /// </summary>
        public _00040_CombinationSumII()
        {
            IList<IList<int>> x = CombinationSumII0([10, 1, 2, 7, 6, 1, 5], 8);

            RftTerminal.RftReadResult(x);
        }

        public static IList<IList<int>> CombinationSumII0(int[] a0, int a1) => RftCombinationSumII0(a0, a1);

        private static List<IList<int>> RftCombinationSumII0(int[] candidates, int target)
        {
            List<IList<int>> x = [];
            Array.Sort(candidates);

            Backtracking(candidates, target, 0, [], x);

            return x;
        }

        private static void Backtracking(int[] candidates, int target, int start, List<int> list, List<IList<int>> x)
        {
            if (target < 0) return;
            else if (target == 0)
            {
                x.Add(new List<int>(list));
                return;
            }
            else
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    if (i > start && candidates[i] == candidates[i - 1]) continue;

                    list.Add(candidates[i]);
                    Backtracking(candidates, target - candidates[i], i + 1, list, x);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}
