using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00111_MinimumDepthOfBinaryTree
    {
        /// <summary>
        /// Given a binary tree, find its minimum depth.
        /// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
        /// Note: A leaf is a node with no children.
        /// </summary>
        public _00111_MinimumDepthOfBinaryTree()
        {

        }

        public static int MinimumDepthOfBinaryTree0(TreeNode0? a0) => RftMinimumDepthOfBinaryTree0(a0);

        private static int RftMinimumDepthOfBinaryTree0(TreeNode0? root)
        {
            if (root is null) return 0;

            int left = RftMinimumDepthOfBinaryTree0(root.left);
            int right = RftMinimumDepthOfBinaryTree0(root.right);

            if (left == 0) return right + 1;
            if (right == 0) return left + 1;

            return Math.Min(left + 1, right + 1);
        }
    }
}