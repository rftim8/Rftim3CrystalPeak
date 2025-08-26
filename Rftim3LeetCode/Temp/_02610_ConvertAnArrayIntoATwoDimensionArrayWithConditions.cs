using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02610_ConvertAnArrayIntoATwoDimensionArrayWithConditions
    {
        /// <summary>
        /// You are given an integer array nums. You need to create a 2D array from nums satisfying the following conditions:
        /// 
        /// The 2D array should contain only the elements of the array nums.
        /// Each row in the 2D array contains distinct integers.
        /// The number of rows in the 2D array should be minimal.
        /// Return the resulting array. If there are multiple answers, return any of them.
        /// 
        /// Note that the 2D array can have a different number of elements on each row.
        /// </summary>
        public _02610_ConvertAnArrayIntoATwoDimensionArrayWithConditions()
        {
            IList<IList<int>> a0 = FindMatrix0([1, 3, 4, 1, 2, 3, 1]);
            RftTerminal.RftReadResult(a0);

            IList<IList<int>> a1 = FindMatrix0([1, 2, 3, 4]);
            RftTerminal.RftReadResult(a1);
        }

        public static IList<IList<int>> FindMatrix0(int[] a0) => RftFindMatrix0(a0);

        public static IList<IList<int>> FindMatrix1(int[] a0) => RftFindMatrix1(a0);

        private static List<IList<int>> RftFindMatrix0(int[] nums)
        {
            int n = nums.Length;

            List<IList<int>> r = [];
            for (int i = 0; i < n; i++)
            {
                if (i == 0) r.Add([nums[i]]);
                else
                {
                    bool stop = true;
                    for (int j = 0; j < r.Count; j++)
                    {
                        if (!r[j].Contains(nums[i]))
                        {
                            r[j].Add(nums[i]);
                            stop = false;
                            break;
                        }
                    }
                    if (stop) r.Add([nums[i]]);
                }
            }

            return r;
        }

        private static List<IList<int>> RftFindMatrix1(int[] nums)
        {
            List<IList<int>> ans = [];

            foreach (int i in nums)
            {
                bool found = false;
                foreach (IList<int> l in ans)
                {
                    if (l.Contains(i)) continue;

                    l.Add(i);
                    found = true;
                    break;
                }

                if (!found) ans.Add([i]);
            }

            return ans;
        }
    }
}
