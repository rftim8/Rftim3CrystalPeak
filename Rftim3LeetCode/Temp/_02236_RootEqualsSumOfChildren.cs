using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _02236_RootEqualsSumOfChildren
    {
        /// <summary>
        /// You are given the root of a binary tree that consists of exactly 3 nodes: the root, its left child, and its right child.
        /// Return true if the value of the root is equal to the sum of the values of its two children, or false otherwise.
        /// </summary>
        public _02236_RootEqualsSumOfChildren()
        {
            TreeNode0 a2 = new(6);
            TreeNode0 a1 = new(4);
            TreeNode0 a0 = new(10, a1, a2);

            Console.WriteLine(CheckTree(a0));
        }

        private static bool CheckTree(TreeNode0 root)
        {
            int c = 0;
            Stack<TreeNode0> r = new();
            r.Push(root);

            while (r.Count != 0)
            {
                TreeNode0 t = r.Pop();

                if (t.left is not null)
                {
                    r.Push(t.left);
                    c += t.left.val;
                }
                if (t.right is not null)
                {
                    r.Push(t.right);
                    c += t.right.val;
                }
            }

            return c == root.val;
        }
    }
}
