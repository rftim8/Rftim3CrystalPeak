using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00617_MergeTwoBinaryTrees
    {
        /// <summary>
        /// You are given two binary trees root1 and root2.
        /// Imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.
        /// You need to merge the two trees into a new binary tree.The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.
        /// Otherwise, the NOT null node will be used as the node of the new tree.
        /// Return the merged tree.
        /// Note: The merging process must start from the root nodes of both trees.
        /// </summary>
        public _00617_MergeTwoBinaryTrees()
        {
            TreeNode0? a3 = new(5);
            TreeNode0? a2 = new(2);
            TreeNode0? a1 = new(3, a3);
            TreeNode0? a0 = new(1, a1, a2);

            TreeNode0? b4 = new(7);
            TreeNode0? b3 = new(4);
            TreeNode0? b2 = new(3, null, b4);
            TreeNode0? b1 = new(1, null, b3);
            TreeNode0? b0 = new(2, b1, b2);

            Console.WriteLine(MergeTrees(a0, b0)?.val);
        }

        private static TreeNode0? MergeTrees(TreeNode0? root1, TreeNode0? root2)
        {
            if (root1 is null) return root2;
            if (root2 is null) return root1;

            root1.val += root2.val;
            Console.WriteLine($"{root1.val}");
            root1.left = MergeTrees(root1.left, root2.left);
            root1.right = MergeTrees(root1.right, root2.right);

            return root1;
        }
    }
}
