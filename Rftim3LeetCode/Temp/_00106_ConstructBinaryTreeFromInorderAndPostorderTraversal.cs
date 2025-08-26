using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00106_ConstructBinaryTreeFromInorderAndPostorderTraversal
    {
        /// <summary>
        /// Given two integer arrays inorder and postorder where inorder is the inorder traversal of a binary tree 
        /// and postorder is the postorder traversal of the same tree, construct and return the binary tree.
        /// </summary>
        public _00106_ConstructBinaryTreeFromInorderAndPostorderTraversal()
        {
            // inorder, postorder
            ConstructBinaryTreeFromInorderAndPostorderTraversal0([9, 3, 15, 20, 7], [9, 15, 7, 20, 3]);
        }

        public static TreeNode0? ConstructBinaryTreeFromInorderAndPostorderTraversal0(int[] a0, int[] a1) => RftConstructBinaryTreeFromInorderAndPostorderTraversal0(a0, a1);

        private static TreeNode0? RftConstructBinaryTreeFromInorderAndPostorderTraversal0(int[] inorder, int[] postorder)
        {
            if (inorder is null || inorder.Length == 0 || postorder is null || postorder.Length == 0) return null;

            return BuildTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        private static TreeNode0? BuildTree(int[] inorder, int i, int j, int[] postorder, int k, int l)
        {
            if (i > j || k > l) return null;

            TreeNode0 node = new(postorder[l]);
            Console.WriteLine($"{node.val}");

            if (k != l)
            {
                int m = 0;

                for (int n = 0; n < inorder.Length; n++)
                {
                    m = n;
                    if (inorder[n] == postorder[l]) break;
                }

                node.left = BuildTree(inorder, i, m - 1, postorder, k, k + m - i - 1);
                node.right = BuildTree(inorder, m + 1, j, postorder, k + m - i, l - 1);
            }

            return node;
        }
    }
}