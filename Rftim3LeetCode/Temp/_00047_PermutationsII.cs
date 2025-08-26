using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00047_PermutationsII
    {
        /// <summary>
        /// Given a collection of numbers, nums, that might contain duplicates, 
        /// return all possible unique permutations in any order.
        /// </summary>
        public _00047_PermutationsII()
        {
            IList<IList<int>> x = PermutationsII0([1, 1, 2]);

            RftTerminal.RftReadResult(x);
        }

        public static IList<IList<int>> PermutationsII0(int[] a0) => RftPermutationsII0(a0);

        private static List<IList<int>> RftPermutationsII0(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            List<IList<int>> x = [];
            bool[] used = new bool[n];

            Backtracking(nums, [], x, used);

            return x;
        }


        private static void Backtracking(int[] nums, List<int> list, List<IList<int>> x, bool[] used)
        {
            int n = nums.Length;
            if (list.Count == n)
            {
                x.Add(new List<int>(list));
                return;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1] && used[i - 1] || used[i]) continue;

                    list.Add(nums[i]);
                    used[i] = true;

                    Backtracking(nums, list, x, used);

                    list.RemoveAt(list.Count - 1);
                    used[i] = false;
                }
            }
        }
    }
}
