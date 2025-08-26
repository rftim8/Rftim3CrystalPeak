using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00965_UnivaluedBinaryTree
    {
        /// <summary>
        /// A binary tree is uni-valued if every node in the tree has the same value.
        /// Given the root of a binary tree, return true if the given tree is uni-valued, or false otherwise.
        /// </summary>
        public _00965_UnivaluedBinaryTree()
        {
            TreeNode0 a5 = new(1);
            TreeNode0 a4 = new(1);
            TreeNode0 a3 = new(1);
            TreeNode0 a2 = new(1, null, a5);
            TreeNode0 a1 = new(1, a3, a4);
            TreeNode0 a0 = new(1, a1, a2);

            Console.WriteLine(IsUnivalTree(a0));
        }

        private static bool IsUnivalTree(TreeNode0 root)
        {
            Stack<TreeNode0> s = new();
            s.Push(root);

            while (s.Count != 0)
            {
                TreeNode0 t = s.Pop();
                if (t.val != root.val) return false;

                if (t.left is not null) s.Push(t.left);
                if (t.right is not null) s.Push(t.right);
            }

            return true;
        }
    }
}
