using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00513_FindBottomLeftTreeValue
    {
        /// <summary>
        /// Given the root of a binary tree, return the leftmost value in the last row of the tree.
        /// </summary>
        public _00513_FindBottomLeftTreeValue()
        {
            int?[] a0 = [2, 1, 3];
            TreeNode? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);
            Console.WriteLine(FindBottomLeftTreeValue1(a1));

            int?[] b0 = [1, 2, 3, 4, null, 5, 6, null, null, 7];
            TreeNode? b1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(b0);
            Console.WriteLine(FindBottomLeftTreeValue1(b1));
        }

        public static int FindBottomLeftTreeValue0(TreeNode? a0) => RftFindBottomLeftTreeValue0(a0);

        public static int FindBottomLeftTreeValue1(TreeNode? a0) => RftFindBottomLeftTreeValue1(a0);

        private static int RftFindBottomLeftTreeValue0(TreeNode? root)
        {
            if (root is null) return 0;
            Queue<TreeNode> q = new();
            q.Enqueue(root);
            List<int?> res = [(int)root.val!];

            while (q.Count != 0)
            {
                int n = q.Count;
                List<int?> y = [];
                for (int i = 0; i < n; i++)
                {
                    TreeNode c = q.Dequeue();

                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);

                    y.Add(c.val);
                }
                for (int i = 0; i < y.Count; i++)
                {
                    if (y[i] is not null)
                    {
                        res.Add(y[i]);
                        break;
                    }
                }
            }

            return (int)res.Last()!;
        }

        private static int RftFindBottomLeftTreeValue1(TreeNode? root)
        {
            if (root == null) return 0;

            Queue<TreeNode> qu = new();
            qu.Enqueue(root);
            int? nodeTmp = root.val;

            while (qu.Count > 0)
            {
                int countQu = qu.Count;

                for (int i = 0; i < countQu; i++)
                {
                    TreeNode nodeTmp0 = qu.Dequeue();
                    if (nodeTmp0.val is not null) nodeTmp = nodeTmp0.val;

                    if (nodeTmp0.right is not null) qu.Enqueue(nodeTmp0.right);
                    if (nodeTmp0.left is not null) qu.Enqueue(nodeTmp0.left);
                }
            }

            return (int)nodeTmp!;
        }
    }
}
