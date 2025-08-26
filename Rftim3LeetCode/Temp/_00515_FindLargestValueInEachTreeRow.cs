using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00515_FindLargestValueInEachTreeRow
    {
        /// <summary>
        /// Given the root of a binary tree, return an array of the largest value in each row of the tree (0-indexed).
        /// </summary>
        public _00515_FindLargestValueInEachTreeRow()
        {
            int[] a0 = [1, 3, 2, 5, 3, 0, 9];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            IList<int> x = LargestValues0(l0);
            RftTerminal.RftReadResult(x);
        }

        public static IList<int> LargestValues0(TreeNode0? a0) => RftLargestValues0(a0);

        private static List<int> RftLargestValues0(TreeNode0? root)
        {
            if (root is null) return [];
            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            List<int> x = [];
            while (q.Count != 0)
            {
                int n = q.Count;
                int y = int.MinValue;

                while (n != 0)
                {
                    TreeNode0 c = q.Dequeue();
                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);

                    y = Math.Max(y, c.val);
                    n--;
                }

                x.Add(y);
            }

            return x;
        }
    }
}
