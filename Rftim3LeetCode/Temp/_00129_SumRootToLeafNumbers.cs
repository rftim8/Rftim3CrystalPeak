using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00129_SumRootToLeafNumbers
    {
        private static int sum = 0;

        /// <summary>
        /// You are given the root of a binary tree containing digits from 0 to 9 only.
        /// Each root-to-leaf path in the tree represents a number.
        /// For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123.
        /// Return the total sum of all root-to-leaf numbers.Test cases are generated so that the answer will fit in a 32-bit integer.
        /// A leaf node is a node with no children.
        /// </summary>
        public _00129_SumRootToLeafNumbers()
        {
            TreeNode0 a4 = new(1);
            TreeNode0 a3 = new(5);
            TreeNode0 a2 = new(0);
            TreeNode0 a1 = new(9, a3, a4);
            TreeNode0 a0 = new(4, a1, a2);

            Console.WriteLine(SumNumbers(a0));
        }

        private static int SumNumbers(TreeNode0 root)
        {
            if (root is null) return 0;

            string c = "";
            DFS(root, c);

            return sum;
        }

        private static void DFS(TreeNode0 node, string c)
        {
            if (node.left is null && node.right is null)
            {
                c += node.val.ToString();
                sum += int.Parse(c);
            }
            else
            {
                if (node.left is not null) DFS(node.left, c + node.val.ToString());
                if (node.right is not null) DFS(node.right, c + node.val.ToString());
            }
        }
    }
}
