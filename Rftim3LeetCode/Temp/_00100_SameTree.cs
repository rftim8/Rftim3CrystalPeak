using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00100_SameTree
    {
        /// <summary>
        /// Given the roots of two binary trees p and q, write a function to check if they are the same or not.
        /// Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
        /// </summary>
        public _00100_SameTree()
        {
            int[] a0 = [1, 2, 3];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            int[] a1 = [1, 2, 3];
            TreeNode0? l1 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a1);

            Console.WriteLine(IsSameTree0(l0, l1));
        }

        public static bool IsSameTree0(TreeNode0? a0, TreeNode0? a1) => RftIsSameTree0(a0, a1);

        private static bool RftIsSameTree0(TreeNode0? p, TreeNode0? q)
        {
            if (p is null && q is null) return true;
            if (!Check(p, q)) return false;

            Queue<TreeNode0?> x = new();
            x.Enqueue(p);
            Queue<TreeNode0?> y = new();
            y.Enqueue(q);

            while (x.Count != 0)
            {
                p = x.Dequeue();
                q = y.Dequeue();

                if (!Check(p, q)) return false;
                if (p is not null)
                {
                    if (!Check(p.left, q?.left)) return false;
                    if (p.left is not null)
                    {
                        x.Enqueue(p.left);
                        y.Enqueue(q?.left);
                    }
                    if (!Check(p.right, q?.right)) return false;
                    if (p.right is not null)
                    {
                        x.Enqueue(p.right);
                        y.Enqueue(q?.right);
                    }
                }
            }

            return true;
        }

        private static bool Check(TreeNode0? p, TreeNode0? q)
        {
            if (p is null && q is null) return true;
            if (q is null || p is null) return false;
            if (p.val != q.val) return false;
            return true;
        }
    }
}
