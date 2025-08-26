using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00437_PathSum3
    {
        /// <summary>
        /// Given the root of a binary tree and an integer targetSum, return the number of paths where the sum of the values along the path equals targetSum.
        /// The path does not need to start or end at the root or a leaf, but it must go downwards(i.e., traveling only from parent nodes to child nodes).
        /// </summary>
        public _00437_PathSum3()
        {
            TreeNode0 a8 = new(11, null, null);
            TreeNode0 a7 = new(1, null, null);
            TreeNode0 a6 = new(-2, null, null);
            TreeNode0 a5 = new(3, null, null);
            TreeNode0 a4 = new(2, null, a7);
            TreeNode0 a3 = new(3, a5, a6);
            TreeNode0 a2 = new(-3, null, a8);
            TreeNode0 a1 = new(5, a3, a4);
            TreeNode0 a0 = new(10, a1, a2);

            Console.WriteLine(PathSum(a0, 8));
        }

        private static int PathSum(TreeNode0? root, int targetSum)
        {
            if (root is null) return 0;

            return Sum(root, targetSum) +
                PathSum(root.left, targetSum) +
                PathSum(root.right, targetSum);
        }

        private static int Sum(TreeNode0? node, int targetSum)
        {
            if (node is null) return 0;

            return (node.val == targetSum ? 1 : 0) +
                Sum(node.left, targetSum - node.val) +
                Sum(node.right, targetSum - node.val);
        }

        private static int PathSum0(TreeNode0? root, int sum, bool start = true)
        {
            if (root is null) return 0;

            int count = PathSum0(root.left, sum - root.val, false) + PathSum0(root.right, sum - root.val, false);

            if (start) count += PathSum0(root.left, sum, true) + PathSum0(root.right, sum, true);
            if (sum - root.val == 0) count++;

            return count;
        }
    }
}
