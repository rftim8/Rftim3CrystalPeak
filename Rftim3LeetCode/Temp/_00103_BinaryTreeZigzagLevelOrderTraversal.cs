using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00103_BinaryTreeZigzagLevelOrderTraversal
    {
        /// <summary>
        /// Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. 
        /// (i.e., from left to right, then right to left for the next level and alternate between).
        /// </summary>
        public _00103_BinaryTreeZigzagLevelOrderTraversal()
        {
            TreeNode0 a4 = new(7, null, null);
            TreeNode0 a3 = new(15, null, null);
            TreeNode0 a2 = new(20, a3, a4);
            TreeNode0 a1 = new(9, null, null);
            TreeNode0 a0 = new(3, a1, a2);

            IList<IList<int>> x = ZigzagLevelOrder(a0);

            RftTerminal.RftReadResult(x);
        }

        private static List<IList<int>> ZigzagLevelOrder(TreeNode0 root)
        {
            List<IList<int>> x = [];
            if (root is null) return x;

            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int n = q.Count;
                List<int> y = [];
                for (int s = 0; s < n; s++)
                {
                    TreeNode0 crt = q.Dequeue();
                    y.Add(crt.val);

                    if (crt.left is not null) q.Enqueue(crt.left);
                    if (crt.right is not null) q.Enqueue(crt.right);
                }

                if (x.Count % 2 == 1) y.Reverse();
                x.Add(y);
            }

            return x;
        }
    }
}
