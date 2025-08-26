using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00104_MaximumDepthOfBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, return its maximum depth.
        /// A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
        /// </summary>
        public _00104_MaximumDepthOfBinaryTree()
        {

        }

        public static int MaximumDepthOfBinaryTree0(TreeNode0? a0) => RftMaximumDepthOfBinaryTree0(a0);

        private static int RftMaximumDepthOfBinaryTree0(TreeNode0? root)
        {
            if (root is null) return 0;

            int d = 0;
            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                d++;
                int n = q.Count;
                for (int i = 0; i < n; i++)
                {
                    TreeNode0 c = q.Dequeue();

                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);
                }
            }

            return d;
        }
    }
}