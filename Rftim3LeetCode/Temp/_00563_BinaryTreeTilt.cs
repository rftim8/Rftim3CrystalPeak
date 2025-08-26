using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00563_BinaryTreeTilt
    {
        /// <summary>
        /// Given the root of a binary tree, return the sum of every tree node's tilt.
        /// The tilt of a tree node is the absolute difference between the sum of all left subtree node values and all right subtree node values.
        /// If a node does not have a left child, then the sum of the left subtree node values is treated as 0. 
        /// The rule is similar if the node does not have a right child.
        /// </summary>
        public _00563_BinaryTreeTilt()
        {
            TreeNode0 a2 = new(3);
            TreeNode0 a1 = new(2);
            TreeNode0 a0 = new(1, a1, a2);

            Console.WriteLine(FindTilt(a0));
        }

        private static int totalTilt = 0;

        private static int FindTilt(TreeNode0? root)
        {
            totalTilt = 0;
            ValueSum(root);

            return totalTilt;
        }

        private static int ValueSum(TreeNode0? node)
        {
            if (node is null) return 0;

            int leftSum = ValueSum(node.left);
            int rightSum = ValueSum(node.right);
            int tilt = Math.Abs(leftSum - rightSum);
            totalTilt += tilt;

            return node.val + leftSum + rightSum;
        }
    }
}
