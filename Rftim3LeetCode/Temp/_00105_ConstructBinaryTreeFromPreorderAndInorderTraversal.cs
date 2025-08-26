using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00105_ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        /// <summary>
        /// Given two integer arrays preorder and inorder where preorder is the preorder traversal of a binary tree and 
        /// inorder is the inorder traversal of the same tree, construct and return the binary tree.
        /// </summary>
        public _00105_ConstructBinaryTreeFromPreorderAndInorderTraversal()
        {
            ConstructBinaryTreeFromPreorderAndInorderTraversal0([3, 9, 20, 15, 7], [9, 3, 15, 20, 7]);
        }

        public static TreeNode0? ConstructBinaryTreeFromPreorderAndInorderTraversal0(int[] a0, int[] a1) => RftConstructBinaryTreeFromPreorderAndInorderTraversal0(a0, a1);

        private static TreeNode0? RftConstructBinaryTreeFromPreorderAndInorderTraversal0(int[] preorder, int[] inorder)
        {
            int n = preorder.Length;
            int m = inorder.Length;

            return BuildTree(preorder, 0, n - 1, inorder, 0, m - 1);
        }

        private static TreeNode0? BuildTree(int[] preorder, int i, int j, int[] inorder, int k, int l)
        {
            if (i > j || k > l) return null;

            TreeNode0 node = new(preorder[i]);

            if (i != j)
            {
                int m = k;

                for (; m < inorder.Length; m++)
                {
                    if (inorder[m] == preorder[i]) break;
                }

                node.left = BuildTree(preorder, i + 1, i + m - k, inorder, k, m - 1);
                node.right = BuildTree(preorder, i + 1 + m - k, j, inorder, m + 1, l);
            }

            return node;
        }

        private static int preIndex = 0;
        private static TreeNode0? BuildTree0(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0) return null;

            return BuildTreeHelper(preorder, inorder, 0, inorder.Length - 1);
        }

        private static TreeNode0? BuildTreeHelper(int[] preorder, int[] inorder, int inStart, int inEnd)
        {
            if (inStart > inEnd) return null;

            TreeNode0 node = new(preorder[preIndex++]);
            if (inStart == inEnd) return node;

            int inIndex = Array.IndexOf(inorder, node.val);
            node.left = BuildTreeHelper(preorder, inorder, inStart, inIndex - 1);
            node.right = BuildTreeHelper(preorder, inorder, inIndex + 1, inEnd);

            return node;
        }
    }
}