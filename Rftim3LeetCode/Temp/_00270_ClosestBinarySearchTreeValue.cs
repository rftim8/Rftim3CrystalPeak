using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00270_ClosestBinarySearchTreeValue
    {
        /// <summary>
        /// Given the root of a binary search tree and a target value, return the value in the BST that is closest to the target. 
        /// If there are multiple answers, print the smallest.
        /// </summary>
        public _00270_ClosestBinarySearchTreeValue()
        {
            int[] a0 = [4, 2, 5, 1, 3];
            TreeNode0? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);
            double a2 = 3.714286;
            Console.WriteLine(ClosestBinarySearchTreeValue0(a1!, a2));
        }

        public static int ClosestBinarySearchTreeValue0(TreeNode0 a0, double a1) => RftClosestBinarySearchTreeValue0(a0, a1);

        public static int ClosestBinarySearchTreeValue1(TreeNode0 a0, double a1) => RftClosestBinarySearchTreeValue1(a0, a1);

        private static int RftClosestBinarySearchTreeValue0(TreeNode0? root, double target)
        {
            int val, closest = root!.val;
            while (root != null)
            {
                val = root.val;
                closest = Math.Abs(val - target) < Math.Abs(closest - target) ||
                    Math.Abs(val - target) == Math.Abs(closest - target) && val < closest ?
                    val : closest;
                root = target < root.val ? root.left : root.right;
            }

            return closest;
        }

        private static int RftClosestBinarySearchTreeValue1(TreeNode0? root, double target)
        {
            int ans = root!.val;
            while (root is not null)
            {
                if (Math.Abs(root.val - target) < Math.Abs(ans - target)) ans = root.val;
                else if (Math.Abs(root.val - target) == Math.Abs(ans - target)) ans = Math.Min(ans, root.val);

                root = target < root.val ? root.left : root.right;
            }

            return ans;
        }
    }
}
