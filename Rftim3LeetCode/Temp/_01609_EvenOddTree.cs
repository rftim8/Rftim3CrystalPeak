using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01609_EvenOddTree
    {
        /// <summary>
        /// A binary tree is named Even-Odd if it meets the following conditions:
        /// 
        /// The root of the binary tree is at level index 0, its children are at level index 1, their children are at level index 2, etc.
        /// For every even-indexed level, all nodes at the level have odd integer values in strictly increasing order(from left to right).
        /// For every odd-indexed level, all nodes at the level have even integer values in strictly decreasing order(from left to right).
        /// Given the root of a binary tree, return true if the binary tree is Even-Odd, otherwise return false.
        /// </summary>
        public _01609_EvenOddTree()
        {
            int?[] a0 = [1, 10, 4, 3, null, 7, 9, 12, 8, 6, null, null, 2];
            TreeNode? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);
            Console.WriteLine(EvenOddTree0(a1));

            int?[] b0 = [5, 4, 2, 3, 3, 7];
            TreeNode? b1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(b0);
            Console.WriteLine(EvenOddTree0(b1));

            int?[] c0 = [5, 9, 1, 3, 5, 7];
            TreeNode? c1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(c0);
            Console.WriteLine(EvenOddTree0(c1));
        }

        public static bool EvenOddTree0(TreeNode? a0) => RftEvenOddTree0(a0);

        public static bool EvenOddTree1(TreeNode? a0) => RftEvenOddTree1(a0);

        private static bool RftEvenOddTree0(TreeNode? root)
        {
            if (root is null) return true;

            Queue<TreeNode> q = [];
            q.Enqueue(root);
            int r = 1;

            while (q.Count != 0)
            {
                int c = q.Count;
                int r0 = r == -1 ? 0 : 1;
                List<int?> w = [];

                for (int i = 0; i < c; i++)
                {
                    TreeNode t = q.Dequeue();
                    w.Add(t.val);

                    if (t.left is not null) q.Enqueue(t.left);
                    if (t.right is not null) q.Enqueue(t.right);
                }

                w = [.. w.Where(o => o != null)];
                int? prev = 0;
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i] % 2 != r0) return false;
                    if (i == 0) prev = w[i];
                    else
                    {
                        if (r0 == 1 && w[i] <= prev) return false;
                        if (r0 == 0 && w[i] >= prev) return false;

                        prev = w[i];
                    }
                }

                r *= -1;
            }

            return true;
        }

        private static bool RftEvenOddTree1(TreeNode? root)
        {
            if (root is null) return true;

            Queue<TreeNode> q = new();
            q.Enqueue(root);
            int level = 0;
            int? max = int.MaxValue;
            int? min = int.MinValue;
            while (q.Count != 0)
            {
                int count = q.Count;

                for (int i = 0; i < count; i++)
                {
                    TreeNode n = q.Dequeue();
                    if (n.val != null)
                    {
                        if (level % 2 == 0)
                        {
                            if (min >= n.val || n.val % 2 != 1) return false;

                            min = n.val;
                        }
                        else
                        {
                            if (max <= n.val || n.val % 2 != 0) return false;

                            max = n.val;
                        }
                    }

                    if (n.left != null) q.Enqueue(n.left);
                    if (n.right != null) q.Enqueue(n.right);
                }
                max = int.MaxValue;
                min = int.MinValue;
                level++;
            }

            return true;
        }
    }
}
