using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01161_MaximumLevelSumOfABinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.
        /// Return the smallest level x such that the sum of all the values of nodes at level x is maximal.
        /// </summary>
        public _01161_MaximumLevelSumOfABinaryTree()
        {
            TreeNode0 a4 = new(-8);
            TreeNode0 a3 = new(7);
            TreeNode0 a2 = new(0);
            TreeNode0 a1 = new(7, a3, a4);
            TreeNode0 a0 = new(1, a1, a2);

            Console.WriteLine(MaxLevelSum(a0));
        }

        private static int MaxLevelSum(TreeNode0 root)
        {
            int maxSum = int.MinValue;
            int ans = 0, level = 0;

            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                level++;
                int sumAtCurrentLevel = 0;
                for (int i = q.Count; i > 0; --i)
                {
                    TreeNode0 node = q.Dequeue();
                    sumAtCurrentLevel += node.val;

                    if (node.left is not null) q.Enqueue(node.left);
                    if (node.right is not null) q.Enqueue(node.right);
                }

                if (maxSum < sumAtCurrentLevel)
                {
                    maxSum = sumAtCurrentLevel;
                    ans = level;
                }
            }

            return ans;
        }
    }
}
