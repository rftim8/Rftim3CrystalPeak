using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00530_MinimumAbsoluteDifferenceInBST
    {
        /// <summary>
        /// Given the root of a Binary Search Tree (BST), return the minimum absolute difference between the values of any two different nodes in the tree.
        /// </summary>
        public _00530_MinimumAbsoluteDifferenceInBST()
        {
            int[] a0 = [4, 2, 6, 1, 3];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            Console.WriteLine(GetMinimumDifference0(l0));
        }

        private static int diff;
        private static TreeNode0? prevNode;

        public static int GetMinimumDifference0(TreeNode0? a0) => RftGetMinimumDifference0(a0);

        private static int RftGetMinimumDifference0(TreeNode0? root)
        {
            diff = int.MaxValue;
            prevNode = null;

            InorderTraversal(root);

            return diff;
        }

        private static void InorderTraversal(TreeNode0? node)
        {
            if (node is null) return;

            InorderTraversal(node.left);

            if (prevNode is not null) diff = Math.Min(diff, node.val - prevNode.val);

            prevNode = node;

            InorderTraversal(node.right);
        }
    }
}
