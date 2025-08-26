using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01424_DiagonalTraverse2
    {
        /// <summary>
        /// Given a 2D integer array nums, return all elements of nums in diagonal order as shown in the below images.
        /// </summary>
        public _01424_DiagonalTraverse2()
        {
            int[] x = FindDiagonalOrder0([[1, 2, 3], [4, 5, 6], [7, 8, 9]]);
            RftTerminal.RftReadResult(x);

            int[] x0 = FindDiagonalOrder0([[1, 2, 3, 4, 5], [6, 7], [8], [9, 10, 11], [12, 13, 14, 15, 16]]);
            RftTerminal.RftReadResult(x0);
        }

        public static int[] FindDiagonalOrder0(List<IList<int>> a0) => RftFindDiagonalOrder0(a0);

        public static int[] FindDiagonalOrder1(List<IList<int>> a0) => RftFindDiagonalOrder1(a0);

        private static int[] RftFindDiagonalOrder0(List<IList<int>> nums)
        {
            Dictionary<int, List<int>> groups = [];
            int n = 0;

            for (int row = nums.Count - 1; row >= 0; row--)
            {
                for (int col = 0; col < nums[row].Count; col++)
                {
                    int diagonal = row + col;
                    if (!groups.TryGetValue(diagonal, out List<int>? value))
                    {
                        value = ([]);
                        groups.Add(diagonal, value);
                    }

                    value.Add(nums[row][col]);
                    n++;
                }
            }

            int[] ans = new int[n];
            int i = 0;
            int curr = 0;

            while (groups.ContainsKey(curr))
            {
                foreach (int num in groups[curr])
                {
                    ans[i] = num;
                    i++;
                }

                curr++;
            }

            return ans;
        }

        // BFS
        private static int[] RftFindDiagonalOrder1(List<IList<int>> nums)
        {
            Queue<(int, int)> queue = new();
            queue.Enqueue((0, 0));
            List<int> ans = [];

            while (queue.Count != 0)
            {
                (int, int) p = queue.Dequeue();
                int row = p.Item1;
                int col = p.Item2;
                ans.Add(nums[row][col]);

                if (col == 0 && row + 1 < nums.Count) queue.Enqueue((row + 1, col));

                if (col + 1 < nums[row].Count) queue.Enqueue((row, col + 1));
            }

            int[] result = new int[ans.Count];
            int i = 0;
            foreach (int num in ans)
            {
                result[i] = num;
                i++;
            }

            return result;
        }
    }
}
