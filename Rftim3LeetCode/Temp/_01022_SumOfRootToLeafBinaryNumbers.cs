using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01022_SumOfRootToLeafBinaryNumbers
    {
        /// <summary>
        /// You are given the root of a binary tree where each node has a value 0 or 1. 
        /// Each root-to-leaf path represents a binary number starting with the most significant bit.
        /// For example, if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 13.
        /// For all leaves in the tree, consider the numbers represented by the path from the root to that leaf.Return the sum of these numbers.
        /// The test cases are generated so that the answer fits in a 32-bits integer.
        /// </summary>
        public _01022_SumOfRootToLeafBinaryNumbers()
        {
            TreeNode0 a6 = new(1);
            TreeNode0 a5 = new(0);
            TreeNode0 a4 = new(1);
            TreeNode0 a3 = new(0);
            TreeNode0 a2 = new(1, a5, a6);
            TreeNode0 a1 = new(0, a3, a4);
            TreeNode0 a0 = new(1, a1, a2);

            Console.WriteLine(SumRootToLeaf(a0));
        }

        private static int SumRootToLeaf(TreeNode0 root)
        {
            int rootToLeaf = 0;
            Stack<(TreeNode0, int)> stack = new();
            stack.Push((root, 0));

            while (stack.Count != 0)
            {
                (TreeNode0, int) t = stack.Pop();
                root = t.Item1;
                int currNumber = t.Item2;

                if (root is not null)
                {
                    currNumber = currNumber << 1 | root.val;
                    if (root.left is null && root.right is null) rootToLeaf += currNumber;
                    else
                    {
                        if (root.right is not null) stack.Push((root.right, currNumber));
                        if (root.left is not null) stack.Push((root.left, currNumber));
                    }
                }
            }

            return rootToLeaf;
        }

        private static int SumRootToLeaf0(TreeNode0 root)
        {
            return Sum(root, 0);
        }

        private static int Sum(TreeNode0 root, int before)
        {
            int val = before * 2 + root.val;
            if (root.left is null && root.right is null) return val;
            int total = 0;
            if (root.left is not null) total += Sum(root.left, val);
            if (root.right is not null) total += Sum(root.right, val);

            return total;
        }
    }
}
