using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00102_BinaryTreeLevelOrderTraversal
    {
        /// <summary>
        /// Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
        /// </summary>
        public _00102_BinaryTreeLevelOrderTraversal()
        {
            TreeNode0 a4 = new(7);
            TreeNode0 a3 = new(15);
            TreeNode0 a2 = new(20, a3, a4);
            TreeNode0 a1 = new(9);
            TreeNode0 a0 = new(3, a1, a2);

            IList<IList<int>> x = LevelOrder(a0);

            RftTerminal.RftReadResult(x);
        }

        private static IList<IList<int>> LevelOrder(TreeNode0? root)
        {
            if (root is null) return [];

            IList<IList<int>> x = [];
            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int n = q.Count;
                IList<int> y = [];

                while (n != 0)
                {
                    TreeNode0 c = q.Dequeue();
                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);

                    y.Add(c.val);
                    n--;
                }

                x.Add(y);
            }

            return x;
        }
    }
}
