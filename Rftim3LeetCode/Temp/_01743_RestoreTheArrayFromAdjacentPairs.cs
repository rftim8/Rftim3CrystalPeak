using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01743_RestoreTheArrayFromAdjacentPairs
    {
        /// <summary>
        /// There is an integer array nums that consists of n unique elements, but you have forgotten it. 
        /// However, you do remember every pair of adjacent elements in nums.
        /// 
        /// You are given a 2D integer array adjacentPairs of size n - 1 where each adjacentPairs[i] = [ui, vi] indicates that the elements ui and vi are adjacent in nums.
        /// It is guaranteed that every adjacent pair of elements nums[i] and nums[i + 1] will exist in adjacentPairs, either as [nums[i], nums[i + 1]] or[nums[i + 1], nums[i]].
        /// The pairs can appear in any order.
        /// 
        /// Return the original array nums. If there are multiple solutions, return any of them.
        /// </summary>
        public _01743_RestoreTheArrayFromAdjacentPairs()
        {
            int[] x = RestoreArray0(
            [
                [2, 1],
                [3, 4],
                [3, 2]
            ]);
            RftTerminal.RftReadResult(x);

            int[] x0 = RestoreArray0(
            [
                [4, -2],
                [1, 4],
                [-3, 1]
            ]);
            RftTerminal.RftReadResult(x0);

            int[] x1 = RestoreArray0(
            [
                [100000, -100000]
            ]);
            RftTerminal.RftReadResult(x1);

            int[] x2 = RestoreArray0(
            [
                [4, -10],
                [-1, 3],
                [4, -3],
                [-3, 3]
            ]);
            RftTerminal.RftReadResult(x2);
        }

        // DFS
        private static Dictionary<int, List<int>>? graph;

        public static int[] RestoreArray0(int[][] a0) => RftRestoreArray0(a0);

        public static int[] RestoreArray1(int[][] a0) => RftRestoreArray1(a0);

        private static int[] RftRestoreArray0(int[][] adjacentPairs)
        {
            graph = [];
            foreach (int[] edge in adjacentPairs)
            {
                int x = edge[0];
                int y = edge[1];

                if (!graph.ContainsKey(x)) graph.Add(x, []);
                if (!graph.ContainsKey(y)) graph.Add(y, []);

                graph[x].Add(y);
                graph[y].Add(x);
            }

            int root = 0;
            foreach (int num in graph.Keys)
            {
                if (graph[num].Count == 1)
                {
                    root = num;
                    break;
                }
            }

            int[] ans = new int[graph.Count];
            Dfs(root, int.MaxValue, ans, 0);

            return ans;
        }

        private static void Dfs(int node, int prev, int[] ans, int i)
        {
            ans[i] = node;
            foreach (int neighbor in graph![node])
            {
                if (neighbor != prev) Dfs(neighbor, node, ans, i + 1);
            }
        }

        // Iterative
        private static int[] RftRestoreArray1(int[][] adjacentPairs)
        {
            List<int[]> x = [.. adjacentPairs];

            LinkedList<int> r = [];
            r.AddFirst(x[0][0]);
            r.AddFirst(x[0][1]);

            for (int i = 1; i < x.Count; i++)
            {
                if (r.First() == x[i][0])
                {
                    r.AddFirst(x[i][1]);
                    x.RemoveAt(i);
                    i = 0;

                }
                else if (r.First() == x[i][1])
                {
                    r.AddFirst(x[i][0]);
                    x.RemoveAt(i);
                    i = 0;
                }
                else if (r.Last() == x[i][0])
                {
                    r.AddLast(x[i][1]);
                    x.RemoveAt(i);
                    i = 0;
                }
                else if (r.Last() == x[i][1])
                {
                    r.AddLast(x[i][0]);
                    x.RemoveAt(i);
                    i = 0;
                }
            }

            return [.. r];
        }
    }
}
