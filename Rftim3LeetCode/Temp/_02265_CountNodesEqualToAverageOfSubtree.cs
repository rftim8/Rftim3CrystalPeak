using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _02265_CountNodesEqualToAverageOfSubtree
    {
        /// <summary>
        /// Given the root of a binary tree, return the number of nodes where the value of the node is equal to the average of the values in its subtree.
        /// 
        /// Note:
        /// 
        /// The average of n elements is the sum of the n elements divided by n and rounded down to the nearest integer.
        /// A subtree of root is a tree consisting of root and all of its descendants.
        /// </summary>
        public _02265_CountNodesEqualToAverageOfSubtree()
        {
            int[] a0 = [4, 8, 5, 0, 1, 0, 6];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            Console.WriteLine(l0);
        }

        public static int CountNodesEqualToAverageOfSubtree0(TreeNode0? a0) => RftCountNodesEqualToAverageOfSubtree0(a0);

        private static int count;

        private static int RftCountNodesEqualToAverageOfSubtree0(TreeNode0? root)
        {
            count = 0;
            PostOrder(root);

            return count;
        }

        private static (int, int) PostOrder(TreeNode0? root)
        {
            if (root is null) return new(0, 0);

            (int, int) left = PostOrder(root.left);
            (int, int) right = PostOrder(root.right);

            int nodeSum = left.Item1 + right.Item1 + root.val;
            int nodeCount = left.Item2 + right.Item2 + 1;

            if (root.val == nodeSum / nodeCount) count++;

            return new(nodeSum, nodeCount);
        }
    }
}
