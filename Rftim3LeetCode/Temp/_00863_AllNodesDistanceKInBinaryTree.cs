using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00863_AllNodesDistanceKInBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, the value of a target node target, and an integer k, 
        /// return an array of the values of all nodes that have a distance k from the target node.
        /// You can return the answer in any order.
        /// </summary>
        public _00863_AllNodesDistanceKInBinaryTree()
        {
            TreeNode0 a8 = new(4);
            TreeNode0 a7 = new(7);
            TreeNode0 a6 = new(8);
            TreeNode0 a5 = new(0);
            TreeNode0 a4 = new(2, a7, a8);
            TreeNode0 a3 = new(6);
            TreeNode0 a2 = new(1, a5, a6);
            TreeNode0 a1 = new(5, a3, a4);
            TreeNode0 a0 = new(3, a1, a2);

            IList<int> x = AllNodesDistanceKInBinaryTree0(a0, a1, 2);

            RftTerminal.RftReadResult(x);
        }

        public static List<int> AllNodesDistanceKInBinaryTree0(TreeNode0 a0, TreeNode0 a1, int a2) => RftAllNodesDistanceKInBinaryTree0(a0, a1, a2);

        public static List<int> AllNodesDistanceKInBinaryTree1(TreeNode0 a0, TreeNode0 a1, int a2) => RftAllNodesDistanceKInBinaryTree1(a0, a1, a2);

        // DFS on equivalent graph
        private static Dictionary<int, List<int>> graph = [];
        private static List<int> answer = [];
        private static HashSet<int> visited = [];

        private static List<int> RftAllNodesDistanceKInBinaryTree0(TreeNode0 root, TreeNode0 target, int k)
        {
            graph = [];
            BuildGraph(root, null);

            answer = [];
            visited =
            [
                target.val
            ];

            Dfs(target.val, 0, k);

            return answer;
        }

        private static void BuildGraph(TreeNode0 cur, TreeNode0? parent)
        {
            if (cur is not null && parent is not null)
            {
                if (graph.TryGetValue(cur.val, out List<int>? value)) value.Add(parent.val);
                else graph.Add(cur.val, [parent.val]);

                if (graph.TryGetValue(parent.val, out List<int>? value1)) value1.Add(cur.val);
                else graph.Add(parent.val, [cur.val]);
            }

            if (cur?.left is not null) BuildGraph(cur.left, cur);
            if (cur?.right is not null) BuildGraph(cur.right, cur);
        }

        private static void Dfs(int cur, int distance, int k)
        {
            if (distance == k)
            {
                answer.Add(cur);
                return;
            }

            if (graph.TryGetValue(cur, out List<int>? value))
            {
                foreach (int neighbor in value)
                {
                    if (visited.Contains(neighbor)) continue;

                    visited.Add(neighbor);
                    Dfs(neighbor, distance + 1, k);
                }
            }
        }

        // BFS on equivalent graph
        private static List<int> RftAllNodesDistanceKInBinaryTree1(TreeNode0 root, TreeNode0 target, int k)
        {
            Dictionary<int, List<int>> graph = [];
            DfsBuild(root, null, graph);

            List<int> answer = [];
            HashSet<int> visited = [];
            Queue<int[]> queue = new();

            queue.Enqueue([target.val, 0]);
            visited.Add(target.val);

            while (queue.Count != 0)
            {
                int[] cur = queue.Dequeue();
                int node = cur[0], distance = cur[1];

                if (distance == k)
                {
                    answer.Add(node);
                    continue;
                }

                if (graph.TryGetValue(node, out List<int>? value))
                {
                    foreach (int neighbor in value)
                    {
                        if (visited.Contains(neighbor)) continue;

                        visited.Add(neighbor);
                        queue.Enqueue([neighbor, distance + 1]);
                    }
                }
            }

            return answer;
        }

        private static void DfsBuild(TreeNode0 cur, TreeNode0? parent, Dictionary<int, List<int>> graph)
        {
            if (cur is not null && parent is not null)
            {
                int curVal = cur.val, parentVal = parent.val;
                if (!graph.ContainsKey(curVal)) graph.Add(curVal, []);
                if (!graph.ContainsKey(parentVal)) graph.Add(parentVal, []);

                graph[curVal].Add(parentVal);
                graph[parentVal].Add(curVal);
            }

            if (cur is not null && cur.left is not null) DfsBuild(cur.left, cur, graph);
            if (cur is not null && cur.right is not null) DfsBuild(cur.right, cur, graph);
        }
    }
}