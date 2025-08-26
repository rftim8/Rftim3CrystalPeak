using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _02385_AmountOfTimeForBinaryTreeToBeInfected
    {
        /// <summary>
        /// You are given the root of a binary tree with unique values, and an integer start. 
        /// At minute 0, an infection starts from the node with value start.
        /// 
        /// Each minute, a node becomes infected if:
        /// 
        /// The node is currently uninfected.
        /// The node is adjacent to an infected node.
        /// Return the number of minutes needed for the entire tree to be infected.
        /// </summary>
        public _02385_AmountOfTimeForBinaryTreeToBeInfected()
        {
            int[] a0 = [1, 5, 3, 0, 4, 10, 6, 9, 2];
            TreeNode0? x0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);
            Console.WriteLine(AmountOfTime0(x0, 3));

            int[] a1 = [1];
            TreeNode0? x1 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a1);
            Console.WriteLine(AmountOfTime0(x1, 1));
        }

        public static int AmountOfTime0(TreeNode0? a0, int a1) => RftAmountOfTime0(a0, a1);

        public static int AmountOfTime1(TreeNode0? a0, int a1) => RftAmountOfTime1(a0, a1);

        // One-Pass DFS
        private static int RftAmountOfTime0(TreeNode0? root, int start)
        {
            int maxDistance = 0;

            traverse(root, start);

            int traverse(TreeNode0? root, int start)
            {
                int depth = 0;
                if (root == null) return depth;

                int leftDepth = traverse(root.left, start);
                int rightDepth = traverse(root.right, start);

                if (root.val == start)
                {
                    maxDistance = Math.Max(leftDepth, rightDepth);
                    depth = -1;
                }
                else if (leftDepth >= 0 && rightDepth >= 0) depth = Math.Max(leftDepth, rightDepth) + 1;
                else
                {
                    int distance = Math.Abs(leftDepth) + Math.Abs(rightDepth);
                    maxDistance = Math.Max(maxDistance, distance);
                    depth = Math.Min(leftDepth, rightDepth) - 1;
                }

                return depth;
            }

            return maxDistance;
        }

        // Convert to graph + BFS
        private static int RftAmountOfTime1(TreeNode0? root, int start)
        {
            Dictionary<int, HashSet<int>> map = [];

            convert(root, 0, map);

            Queue<int> queue = new();
            queue.Enqueue(start);
            int minute = 0;
            HashSet<int> visited = [start];

            while (queue.Count != 0)
            {
                int levelSize = queue.Count;
                while (levelSize > 0)
                {
                    int current = queue.Dequeue();
                    foreach (int num in map[current])
                    {
                        if (visited.Contains(num)) continue;

                        visited.Add(num);
                        queue.Enqueue(num);
                    }
                    levelSize--;
                }
                minute++;
            }

            static void convert(TreeNode0? current, int parent, Dictionary<int, HashSet<int>> map)
            {
                if (current == null) return;

                if (!map.ContainsKey(current.val)) map.Add(current.val, []);

                HashSet<int> adjacentList = map[current.val];
                if (parent != 0) adjacentList.Add(parent);

                if (current.left != null) adjacentList.Add(current.left.val);

                if (current.right != null) adjacentList.Add(current.right.val);

                convert(current.left, current.val, map);
                convert(current.right, current.val, map);
            }

            return minute - 1;
        }
    }
}
