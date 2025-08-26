using Rftim3Atlas.Models;
using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00606_ConstructStringFromBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, construct a string consisting of parenthesis and integers from a binary tree with the preorder traversal way, and return it.
        /// Omit all the empty parenthesis pairs that do not affect the one-to-one mapping relationship between the string and the original binary tree.
        /// </summary>
        public _00606_ConstructStringFromBinaryTree()
        {
            TreeNode0 a3 = new(4);
            TreeNode0 a2 = new(3);
            TreeNode0 a1 = new(2, a3);
            TreeNode0 a0 = new(1, a1, a2);

            Console.WriteLine(Tree2str(a0));
        }

        private static string Tree2str(TreeNode0? root)
        {
            if (root is null) return "";

            Stack<TreeNode0> stack = new();
            stack.Push(root);

            HashSet<TreeNode0> visited = [];
            StringBuilder s = new();

            while (stack.Count != 0)
            {
                root = stack.Peek();
                if (visited.Contains(root))
                {
                    stack.Pop();
                    s.Append(')');
                }
                else
                {
                    visited.Add(root);
                    s.Append($"({root.val}");

                    if (root.left is null && root.right is not null) s.Append("()");
                    if (root.right is not null) stack.Push(root.right);
                    if (root.left is not null) stack.Push(root.left);
                }
            }

            return s.ToString()[1..^1];
        }

        private static StringBuilder? sb;

        private static string Tree2str0(TreeNode0 root)
        {
            if (root is null) return "";

            sb = new();
            TraverseTree(root);
            return sb.ToString();
        }

        private static void TraverseTree(TreeNode0? n)
        {
            if (n is null) return;

            sb!.Append(n.val);
            if (n.left is null && n.right is null) return;

            sb.Append('(');
            TraverseTree(n.left);
            sb.Append(')');
            if (n.right is not null)
            {
                sb.Append('(');
                TraverseTree(n.right);
                sb.Append(')');
            }
        }
    }
}
