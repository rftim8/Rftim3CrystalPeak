using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00235_LowestCommonAncestorOfABST
    {
        /// <summary>
        /// Given a binary search tree (BST), find the lowest common ancestor (LCA) node of two given nodes in the BST.
        /// According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T 
        /// that has both p and q as descendants(where we allow a node to be a descendant of itself).”
        /// </summary>
        public _00235_LowestCommonAncestorOfABST()
        {
            TreeNode0 a8 = new(9, null, null);
            TreeNode0 a7 = new(7, null, null);
            TreeNode0 a6 = new(5, null, null);
            TreeNode0 a5 = new(3, null, null);
            TreeNode0 a4 = new(4, a5, a6);
            TreeNode0 a3 = new(0, null, null);
            TreeNode0 a2 = new(8, a7, a8);
            TreeNode0 a1 = new(2, a3, a4);
            TreeNode0 a0 = new(6, a1, a2);

            Console.WriteLine(LowestCommonAncestor(a0, a1, a2)?.val);
        }

        private TreeNode0? LowestCommonAncestor(TreeNode0? root, TreeNode0 p, TreeNode0 q)
        {
            if (root is null) return null;
            else if (root.val >= p.val && root.val <= q.val || root.val <= p.val && root.val >= q.val) return root;
            else if (root.val >= p.val) return LowestCommonAncestor(root.left, p, q);
            else return LowestCommonAncestor(root.right, p, q);
        }
    }
}
