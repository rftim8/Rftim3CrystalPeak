using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00107_BinaryTreeLevelOrderTraversal2
    {
        /// <summary>
        /// Given the root of a binary tree, return the bottom-up level order traversal of its nodes' values. 
        /// (i.e., from left to right, level by level from leaf to root).
        /// </summary>
        public _00107_BinaryTreeLevelOrderTraversal2()
        {
            TreeNode0 a4 = new(7);
            TreeNode0 a3 = new(15);
            TreeNode0 a2 = new(20, a3, a4);
            TreeNode0 a1 = new(9);
            TreeNode0 a0 = new(3, a1, a2);

            IList<IList<int>> x = LevelOrderBottom(a0);
            RftTerminal.RftReadResult(x);
        }

        private static List<IList<int>> LevelOrderBottom(TreeNode0 root)
        {
            List<IList<int>> r = [];
            if (root is null) return r;

            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int n = q.Count;
                List<int> t = [];

                for (int i = 0; i < n; i++)
                {
                    TreeNode0 c = q.Dequeue();
                    t.Add(c.val);

                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);
                }

                r.Add(t);
            }

            r.Reverse();

            return r;
        }
    }
}
