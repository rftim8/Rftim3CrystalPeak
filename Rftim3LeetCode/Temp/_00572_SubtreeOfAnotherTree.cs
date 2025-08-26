using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00572_SubtreeOfAnotherTree
    {
        /// <summary>
        /// Given the roots of two binary trees root and subRoot, return true if there is a subtree of root 
        /// with the same structure and node values of subRoot and false otherwise.
        /// A subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. 
        /// The tree tree could also be considered as a subtree of itself.
        /// </summary>
        public _00572_SubtreeOfAnotherTree()
        {
            TreeNode0 a4 = new(2, null, null);
            TreeNode0 a3 = new(1, null, null);
            TreeNode0 a2 = new(5, null, null);
            TreeNode0 a1 = new(4, a3, a4);
            TreeNode0 a0 = new(3, a1, a2);

            TreeNode0 b2 = new(2, null, null);
            TreeNode0 b1 = new(1, null, null);
            TreeNode0 b0 = new(4, b1, b2);

            Console.WriteLine(IsSubtree(a0, b0));
        }

        private static bool IsSubtree(TreeNode0? root, TreeNode0 subRoot)
        {
            if (root is null) return false;

            if (IsIdentical(root, subRoot)) return true;

            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        private static bool IsIdentical(TreeNode0? node1, TreeNode0? node2)
        {
            if (node1 is not null && node2 is not null) Console.WriteLine($"{node1.val} : {node2.val}");
            if (node1 is null || node2 is null) return node1 is null && node2 is null;

            return node1.val == node2.val && IsIdentical(node1.left, node2.left) && IsIdentical(node1.right, node2.right);
        }
    }
}
