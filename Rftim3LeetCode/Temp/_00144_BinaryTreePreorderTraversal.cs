using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00144_BinaryTreePreorderTraversal
    {
        /// <summary>
        /// Given the root of a binary tree, return the preorder traversal of its nodes' values.
        /// </summary>
        public _00144_BinaryTreePreorderTraversal()
        {
            int[] a0 = [1, 0, 2, 3];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            IList<int> x = PreorderTraversal0(l0);
            RftTerminal.RftReadResult(x);
        }

        public static IList<int> PreorderTraversal0(TreeNode0? a0) => RftPreorderTraversal0(a0);

        private static IList<int> RftPreorderTraversal0(TreeNode0? root)
        {
            List<int> x = [];
            Stack<TreeNode0?> s = new();
            s.Push(root);

            while (s.Count != 0)
            {
                TreeNode0? c = s.Pop();
                if (c is not null)
                {
                    x.Add(c.val);
                    s.Push(c.right);
                    s.Push(c.left);
                }
            }

            return [.. x];
        }
    }
}
