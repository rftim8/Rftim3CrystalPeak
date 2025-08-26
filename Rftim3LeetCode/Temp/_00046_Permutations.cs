using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00046_Permutations
    {
        private static List<IList<int>> x = [[]];
        private static int level;

        /// <summary>
        /// Given an array nums of distinct integers, return all the possible permutations. 
        /// You can return the answer in any order.
        /// </summary>
        public _00046_Permutations()
        {
            IList<IList<int>> x = Permutations0([1, 2, 3]);
            RftTerminal.RftReadResult(x);

            IList<IList<int>> x0 = Permutations0([0, 1]);
            RftTerminal.RftReadResult(x0);

            IList<IList<int>> x1 = Permutations0([1]);
            RftTerminal.RftReadResult(x1);
        }

        public static List<IList<int>> Permutations0(int[] a0) => RftPermutations0(a0);

        private static List<IList<int>> RftPermutations0(int[] nums)
        {
            int n = nums.Length;
            x = [];
            level = -1;

            Permute(nums, 0, n - 1);

            return x;
        }

        private static void Permute(int[] nums, int l, int r)
        {
            if (l == r)
            {
                x.Add([]);
                level++;
                foreach (int item in nums)
                {
                    x[level].Add(item);
                }
                RftTerminal.RftReadResult(x[level]);
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    nums = Swap(nums, l, i);
                    Permute(nums, l + 1, r);
                    nums = Swap(nums, l, i);
                }
            }
        }

        private static int[] Swap(int[] nums, int i, int j)
        {
            (nums[j], nums[i]) = (nums[i], nums[j]);

            return nums;
        }
    }
}
