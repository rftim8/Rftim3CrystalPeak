using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00662_MaximumWidthOfBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, return the maximum width of the given tree.
        /// The maximum width of a tree is the maximum width among all levels.
        /// The width of one level is defined as the length between the end-nodes (the leftmost and rightmost non-null nodes), 
        /// where the null nodes between the end-nodes that would be present in a complete binary tree extending down to that level are also counted into the length calculation.
        /// It is guaranteed that the answer will in the range of a 32-bit signed integer.
        /// </summary>
        public _00662_MaximumWidthOfBinaryTree()
        {
            TreeNode0 a5 = new(9, null, null);
            TreeNode0 a4 = new(3, null, null);
            TreeNode0 a3 = new(5, null, null);
            TreeNode0 a2 = new(2, null, a5);
            TreeNode0 a1 = new(3, a3, a4);
            TreeNode0 a0 = new(1, a1, a2);

            Console.WriteLine(WidthOfBinaryTree(a0));
        }

        private static int WidthOfBinaryTree(TreeNode0 root)
        {
            if (root is null) return 1;
            int max = 1;
            Queue<(TreeNode0, int)> q = new();
            q.Enqueue((root, 1));
            while (q.Count != 0)
            {
                int n = q.Count;
                int l = 0;
                for (int i = 0; i < n; i++)
                {
                    (TreeNode0 node, int index) = q.Dequeue();

                    if (i == 0) l = index;
                    if (i == n - 1)
                    {
                        int r = index;
                        max = Math.Max(max, r - l + 1);
                    }
                    if (node.left is not null) q.Enqueue((node.left, 2 * index));
                    if (node.right is not null) q.Enqueue((node.right, 2 * index + 1));
                }
            }

            return max;
        }

        private static int WidthOfBinaryTree0(TreeNode0 root)
        {
            int x = 0;
            Queue<(TreeNode0, int)> q = new();

            q.Enqueue((root, 1));

            while (q.Count != 0)
            {
                int c = q.Count;
                int s = q.Peek().Item2;
                int e = 0;

                while (c > 0)
                {
                    (TreeNode0, int) crt = q.Dequeue();

                    if (c == 1) e = crt.Item2;
                    if (crt.Item1.left is not null) q.Enqueue((crt.Item1.left, crt.Item2 * 2));
                    if (crt.Item1.right is not null) q.Enqueue((crt.Item1.right, crt.Item2 * 2 + 1));

                    c--;
                }

                x = Math.Max(x, e - s + 1);
            }

            return x;
        }

        private static int WidthOfBinaryTree1(TreeNode0 root)
        {
            if (root is null) return 0;
            if (root.left is null && root.right is null) return 1;

            int max_width = 0;
            Queue<(TreeNode0, int)> queue = new();
            queue.Enqueue((root, 0));

            while (queue.Count != 0)
            {
                int size = queue.Count, left = int.MaxValue, right = int.MinValue;

                for (int i = 0; i < size; i++)
                {
                    (TreeNode0, int) node = queue.Dequeue();
                    left = Math.Min(left, node.Item2);
                    right = Math.Max(right, node.Item2);

                    if (node.Item1.left is not null) queue.Enqueue((node.Item1.left, 2 * node.Item2 + 1));
                    if (node.Item1.right is not null) queue.Enqueue((node.Item1.right, 2 * node.Item2 + 2));
                }

                max_width = Math.Max(max_width, right - left + 1);
            }

            return max_width;
        }
    }
}
