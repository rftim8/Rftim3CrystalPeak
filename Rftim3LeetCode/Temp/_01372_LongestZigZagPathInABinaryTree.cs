using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01372_LongestZigZagPathInABinaryTree
    {
        /// <summary>
        /// You are given the root of a binary tree.
        /// A ZigZag path for a binary tree is defined as follow:
        /// Choose any node in the binary tree and a direction(right or left).
        /// If the current direction is right, move to the right child of the current node; otherwise, move to the left child.
        /// Change the direction from right to left or from left to right.
        /// Repeat the second and third steps until you can't move in the tree.
        /// Zigzag length is defined as the number of nodes visited - 1. (A single node has a length of 0).
        /// Return the longest ZigZag path contained in that tree.
        /// </summary>
        public _01372_LongestZigZagPathInABinaryTree()
        {
            TreeNode0 a7 = new(1);
            TreeNode0 a6 = new(1, null, a7);
            TreeNode0 a5 = new(1);
            TreeNode0 a4 = new(1, null, a6);
            TreeNode0 a3 = new(1, a4, a5);
            TreeNode0 a2 = new(1);
            TreeNode0 a1 = new(1, a2, a3);
            TreeNode0 a0 = new(1, null, a1);

            Console.WriteLine(LongestZigZag(a0));
        }

        private static int LongestZigZag(TreeNode0 root)
        {
            return Dfs(root, true, -1);
        }

        private static int Dfs(TreeNode0? node, bool goLeft, int steps)
        {
            if (node is null) return steps;

            int l, r;

            if (goLeft)
            {
                l = Dfs(node.left, false, steps + 1);
                r = Dfs(node.right, true, 0);
            }
            else
            {
                l = Dfs(node.right, true, steps + 1);
                r = Dfs(node.left, false, 0);
            }

            return Math.Max(l, r);
        }
    }
}
