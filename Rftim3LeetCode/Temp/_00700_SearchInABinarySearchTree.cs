using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00700_SearchInABinarySearchTree
    {
        /// <summary>
        /// You are given the root of a binary search tree (BST) and an integer val.
        /// Find the node in the BST that the node's value equals val and return the subtree rooted with that node. 
        /// If such a node does not exist, return null.
        /// </summary>
        public _00700_SearchInABinarySearchTree()
        {
            TreeNode0 a4 = new(3, null, null);
            TreeNode0 a3 = new(1, null, null);
            TreeNode0 a2 = new(7, null, null);
            TreeNode0 a1 = new(2, a3, a4);
            TreeNode0 a0 = new(4, a1, a2);

            int val = 2;
            SearchBST(a0, val);
        }

        private static TreeNode0? SearchBST(TreeNode0? root, int val)
        {
            if (root is null) return null;
            if (root.val == val) return root;

            Console.WriteLine($"root: {root.val}");
            if (root.left is not null) Console.WriteLine($"{root.left.val}");
            if (root.right is not null) Console.WriteLine($"{root.right.val}");
            TreeNode0? l = SearchBST(root.left, val);
            TreeNode0? r = SearchBST(root.right, val);

            return l ?? r;
        }
    }
}
