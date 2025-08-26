using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00145_BinaryTreePostorderTraversal
    {
        /// <summary>
        /// Given the root of a binary tree, return the postorder traversal of its nodes' values.
        /// </summary>
        public _00145_BinaryTreePostorderTraversal()
        {
            int[] a0 = [1, 0, 2, 3];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            IList<int> x = PostorderTraversal0(l0);
            RftTerminal.RftReadResult(x);
        }

        public static IList<int> PostorderTraversal0(TreeNode0? a0) => RftPostorderTraversal0(a0);

        private static IList<int> RftPostorderTraversal0(TreeNode0? root)
        {
            if (root is null) return [];

            List<int> x = [];
            Stack<TreeNode0> s1 = new();

            s1.Push(root);

            while (s1.Count != 0)
            {
                TreeNode0 node = s1.Pop();

                x.Add(node.val);

                if (node.left is not null) s1.Push(node.left);
                if (node.right is not null) s1.Push(node.right);
            }

            x.Reverse();

            return [.. x];
        }
    }
}
