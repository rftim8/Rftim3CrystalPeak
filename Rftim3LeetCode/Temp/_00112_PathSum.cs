using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00112_PathSum
    {
        /// <summary>
        /// Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such 
        /// that adding up all the values along the path equals targetSum.
        /// A leaf is a node with no children.
        /// </summary>
        public _00112_PathSum()
        {
            int[] a0 = [5, 4, 8, 11, 0, 13, 4, 7, 2, 0, 0, 0, 1];
            int a1 = 22;
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            Console.WriteLine(HasPathSum0(l0, a1));
        }

        public static bool HasPathSum0(TreeNode0? a0, int a1) => RftHasPathSum0(a0, a1);

        private static bool RftHasPathSum0(TreeNode0? root, int targetSum)
        {
            if (root is null) return false;

            Stack<(TreeNode0, int)> s = new();
            s.Push((root, root.val));

            while (s.Count != 0)
            {
                (TreeNode0, int) t = s.Pop();
                TreeNode0 node = t.Item1;
                int tSum = t.Item2;

                if (node.right is not null) s.Push((node.right, node.right.val + tSum));
                if (node.left is not null) s.Push((node.left, node.left.val + tSum));

                if (node.left is null && node.right is null && tSum == targetSum) return true;
            }

            return false;
        }
    }
}
