using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00199_BinaryTreeRightSideView
    {
        /// <summary>
        /// Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
        /// </summary>
        public _00199_BinaryTreeRightSideView()
        {
            TreeNode0 a4 = new(4, null, null);
            TreeNode0 a3 = new(5, null, null);
            TreeNode0 a2 = new(3, null, a4);
            TreeNode0 a1 = new(2, null, a3);
            TreeNode0 a0 = new(1, a1, a2);

            IList<int> x = RightSideView(a0);

            RftTerminal.RftReadResult(x);
        }

        private static List<int> RightSideView(TreeNode0 root)
        {
            if (root is null) return [];

            List<int> x = [];
            Queue<TreeNode0> q = new();

            q.Enqueue(root);

            while (q.Count != 0)
            {
                int c = q.Count;

                while (c > 0)
                {
                    TreeNode0 crt = q.Dequeue();

                    if (c == 1) x.Add(crt.val);
                    if (crt.left is not null) q.Enqueue(crt.left);
                    if (crt.right is not null) q.Enqueue(crt.right);

                    c--;
                }
            }

            return x;
        }

        private static List<int> RightSideView0(TreeNode0 root)
        {
            List<int> x = [];
            Queue<TreeNode0> level = new();

            if (root is not null)
            {
                level.Enqueue(root);

                while (level.Count != 0)
                {
                    int countInLevel = level.Count;

                    while (countInLevel > 0)
                    {
                        TreeNode0 crt = level.Dequeue();
                        if (crt.left is not null) level.Enqueue(crt.left);
                        if (crt.right is not null) level.Enqueue(crt.right);

                        if (countInLevel == 1) x.Add(crt.val);

                        countInLevel--;
                    }
                }
            }

            return x;
        }
    }
}
