using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00101_SymmetricTree
    {
        /// <summary>
        /// Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
        /// </summary>
        public _00101_SymmetricTree()
        {
            int[] a0 = [1, 2, 2, 3, 4, 4, 3];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            Console.WriteLine(IsSymmetric0(l0));
        }

        public static bool IsSymmetric0(TreeNode0? a0) => RftIsSymmetric0(a0);

        private static bool RftIsSymmetric0(TreeNode0? root)
        {
            return Func(root?.left, root?.right);
        }

        private static bool Func(TreeNode0? l, TreeNode0? r)
        {
            if (l is null && r is null) return true;
            if (l is null || r is null) return false;

            if (!Func(l.left, r.right)) return false;
            if (l.val != r.val) return false;
            if (!Func(l.right, r.left)) return false;

            return true;
        }
    }
}
