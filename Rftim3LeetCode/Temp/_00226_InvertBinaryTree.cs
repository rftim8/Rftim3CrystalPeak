using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00226_InvertBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, invert the tree, and return its root.
        /// </summary>
        public _00226_InvertBinaryTree()
        {
            int[] a0 = [4, 2, 7, 1, 3, 6, 9];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);
            Console.WriteLine(InvertTree0(l0));
        }

        public static TreeNode0? InvertTree0(TreeNode0? a0) => RftInvertTree0(a0);

        private static TreeNode0? RftInvertTree0(TreeNode0? root)
        {
            if (root is null) return null;

            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                TreeNode0 c = q.Dequeue();

                (c.right, c.left) = (c.left, c.right);

                if (c.left is not null) q.Enqueue(c.left);
                if (c.right is not null) q.Enqueue(c.right);
            }

            return root;
        }
    }
}
