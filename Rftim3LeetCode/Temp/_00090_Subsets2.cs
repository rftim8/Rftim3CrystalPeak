using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00090_Subsets2
    {
        /// <summary>
        /// Given an integer array nums that may contain duplicates, return all possible subsets (the power set).
        /// The solution set must not contain duplicate subsets.Return the solution in any order.
        /// </summary>
        public _00090_Subsets2()
        {
            IList<IList<int>> x = SubsetsWithDup([1, 2, 2]);
            IList<IList<int>> x0 = SubsetsWithDup([4, 4, 4, 1, 4]);

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static List<IList<int>> SubsetsWithDup(int[] nums)
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
                    bool a = true;
                    foreach (IList<int> item2 in x)
                    {
                        if (item1.OrderBy(o => o).SequenceEqual(item2.OrderBy(o => o)))
                        {
                            a = false;
                            break;
                        }
                    }
                    if (a) x.Add(item1);
                }
            }

            return x;
        }

        private static List<IList<int>> SubsetsWithDup0(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            List<IList<int>> ans = [];
            Stack<int> st = new();
            Backtrack(0);
            return ans;

            void Backtrack(int c)
            {
                ans.Add([.. st]);

                for (int i = c; i < n; i++)
                {
                    st.Push(nums[i]);
                    Backtrack(i + 1);
                    st.Pop();

                    while (i < n - 1 && nums[i] == nums[i + 1])
                    {
                        i++;
                    }
                }
            }
        }

        private static IList<IList<int>> SubsetsWithDup1(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> rv = [];
            Dictionary<string, bool> visitedCombinations = [];
            rv.Add([]);
            foreach (int num in nums)
            {
                List<List<int>> newList = [];
                foreach (IList<int> ex in rv)
                {
                    string newCom = string.Join('x', ex.Select(v => v.ToString()));
                    newCom += num;
                    if (!visitedCombinations.ContainsKey(newCom))
                    {
                        newList.Add(new List<int>(ex) { num });
                        visitedCombinations[newCom] = true;
                    }
                }
                rv.AddRange(newList);
            }
            return rv;
        }
    }
}
