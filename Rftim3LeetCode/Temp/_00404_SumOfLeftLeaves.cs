using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00404_SumOfLeftLeaves
    {
        /// <summary>
        /// Given the root of a binary tree, return the sum of all left leaves.
        /// A leaf is a node with no children.A left leaf is a leaf that is the left child of another node.
        /// </summary>
        public _00404_SumOfLeftLeaves()
        {
            int[] a0 = [3, 9, 20, 0, 0, 15, 7];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            Console.WriteLine(SumOfLeftLeaves0(l0));
        }

        public static int SumOfLeftLeaves0(TreeNode0? a0) => RftSumOfLeftLeaves0(a0);

        public static int SumOfLeftLeaves1(TreeNode0? a0) => RftSumOfLeftLeaves1(a0);

        private static int res;

        private static int RftSumOfLeftLeaves0(TreeNode0? root)
        {
            res = 0;
            if (root is null) return res;

            Dfs(root);

            return res;
        }

        private static bool Dfs(TreeNode0 node)
        {
            if (node.left is null && node.right is null) return true;
            if (node.left is not null && Dfs(node.left)) res += node.left.val;
            if (node.right is not null) Dfs(node.right);

            return false;
        }

        private static int RftSumOfLeftLeaves1(TreeNode0? root)
        {
            res = 0;
            if (root is null) return 0;

            int x = 0;

            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int n = q.Count;
                for (int s = 0; s < n; s++)
                {
                    TreeNode0 crt = q.Dequeue();

                    if (crt.left is not null && crt.left.left is null && crt.left.right is null)
                    {
                        x += crt.left.val;
                    }

                    if (crt.left is not null) q.Enqueue(crt.left);
                    if (crt.right is not null) q.Enqueue(crt.right);
                }
            }

            return x;
        }
    }
}
