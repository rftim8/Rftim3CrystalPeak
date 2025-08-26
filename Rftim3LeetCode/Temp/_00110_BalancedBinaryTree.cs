using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00110_BalancedBinaryTree
    {
        /// <summary>
        /// Given a binary tree, determine if it is height-balanced
        /// </summary>
        public _00110_BalancedBinaryTree()
        {
            int[] a0 = [3, 9, 20, 0, 0, 15, 7];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);
            Console.WriteLine(IsBalanced0(l0));
        }

        public static bool IsBalanced0(TreeNode0? a0) => RftIsBalanced0(a0);

        public static bool IsBalanced1(TreeNode0? a0) => RftIsBalanced1(a0);

        // DFS
        private static bool RftIsBalanced0(TreeNode0? root)
        {
            return Dfs(root) != -1;
        }

        private static int Dfs(TreeNode0? root)
        {
            if (root is null) return 0;

            int l = Dfs(root.left);
            int r = Dfs(root.right);

            if (l == -1 || r == -1 || Math.Abs(l - r) > 1) return -1;

            return Math.Max(l, r) + 1;
        }


        private static bool RftIsBalanced1(TreeNode0? root)
        {
            if (root == null) return true;

            int left = GetHeight(root.left);
            int right = GetHeight(root.right);

            if (Math.Abs(left - right) > 1) return false;

            return RftIsBalanced1(root.left) && RftIsBalanced1(root.right);
        }

        private static int GetHeight(TreeNode0? root)
        {
            if (root == null) return 0;

            return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
        }
    }
}
