using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00098_ValidateBinarySearchTree
    {
        /// <summary>
        /// Given the root of a binary tree, determine if it is a valid binary search tree (BST).
        /// A valid BST is defined as follows:
        /// The left
        /// subtree
        ///  of a node contains only nodes with keys less than the node's key.
        /// The right subtree of a node contains only nodes with keys greater than the node's key.
        /// Both the left and right subtrees must also be binary search trees.
        /// </summary>
        public _00098_ValidateBinarySearchTree()
        {
            TreeNode0 a2 = new(3);
            TreeNode0 a1 = new(1);
            TreeNode0 a0 = new(2, a1, a2);

            Console.WriteLine(IsValidBST(a0));
        }

        private static bool IsValidBST(TreeNode0 root)
        {
            return Validate(root, null, null);
        }

        private static bool Validate(TreeNode0? root, int? low, int? high)
        {
            if (root is null) return true;

            if (low is not null && root.val <= low || high is not null && root.val >= high) return false;

            return Validate(root.right, root.val, high) && Validate(root.left, low, root.val);
        }
    }
}
