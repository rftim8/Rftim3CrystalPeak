using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00094_BinaryTreeInorderTraversal
    {
        /// <summary>
        /// Given the root of a binary tree, return the inorder traversal of its nodes' values.
        /// </summary>
        public _00094_BinaryTreeInorderTraversal()
        {
            int[] a0 = [1, 0, 2, 3];
            TreeNode0? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            List<int> a2 = InorderTraversal0(a1);
            RftTerminal.RftReadResult(a2);
        }

        public static List<int> InorderTraversal0(TreeNode0? a0) => RftInorderTraversal0(a0);

        private static List<int> RftInorderTraversal0(TreeNode0? root)
        {
            List<int> x = [];
            Stack<TreeNode0?> s = new();
            TreeNode0? c = root;

            while (c is not null || s.Count != 0)
            {
                while (c is not null)
                {
                    s.Push(c);
                    c = c.left;
                }

                c = s.Pop();
                x.Add(c!.val);
                c = c?.right;
            }

            return x;
        }
    }
}
