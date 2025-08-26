using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00124_BinaryTreeMaximumPathSum
    {
        /// <summary>
        /// A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. 
        /// A node can only appear in the sequence at most once. 
        /// Note that the path does not need to pass through the root.
        /// The path sum of a path is the sum of the node's values in the path.
        /// Given the root of a binary tree, return the maximum path sum of any non-empty path.
        /// </summary>
        public _00124_BinaryTreeMaximumPathSum()
        {
            TreeNode0 a4 = new(7);
            TreeNode0 a3 = new(15);
            TreeNode0 a2 = new(20, a3, a4);
            TreeNode0 a1 = new(9);
            TreeNode0 a0 = new(-10, a1, a2);

            Console.WriteLine(MaxPathSum(a0));
        }

        private static int x;

        private static int MaxPathSum(TreeNode0 root)
        {
            x = int.MinValue;
            DFS(root);

            return x;
        }

        private static int DFS(TreeNode0? root)
        {
            if (root is null) return 0;

            int l = Math.Max(0, DFS(root.left));
            int r = Math.Max(0, DFS(root.right));

            x = Math.Max(x, l + r + root.val);

            return Math.Max(l, r) + root.val;
        }
    }
}
