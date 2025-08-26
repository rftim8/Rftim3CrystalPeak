using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00078_Subsets
    {
        /// <summary>
        /// Permutations
        /// Given an integer array nums of unique elements, return all possible subsets (the power set).
        /// The solution set must not contain duplicate subsets.Return the solution in any order.
        /// </summary>
        public _00078_Subsets()
        {
            IList<IList<int>> x = Subsets([1, 2, 3]);

            RftTerminal.RftReadResult(x);
        }

        private static List<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> x = [[]];

            foreach (int item in nums)
            {
                List<List<int>> y = [];

                foreach (List<int> item1 in x.Cast<List<int>>())
                {
                    y.Add(new List<int>(item1) { item });
                }

                foreach (List<int> item1 in y)
                {
                    x.Add(item1);
                }
            }

            return x;
        }

        private static List<IList<int>> Subsets0(int[] nums)
        {
            List<IList<int>> res = [[]];

            foreach (int num in nums)
            {
                List<IList<int>> newSubsets = [];

                foreach (IList<int> item in res)
                {
                    List<int> temp = new(item)
                    {
                        num
                    };
                    newSubsets.Add(temp);
                }

                res.AddRange(newSubsets);
            }

            return res;
        }
    }
}
