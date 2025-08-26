using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00501_FindModeInBinarySearchTree
    {
        /// <summary>
        /// Given the root of a binary search tree (BST) with duplicates, return all the mode(s) (i.e., the most frequently occurred element) in it.
        /// If the tree has more than one mode, return them in any order.
        /// Assume a BST is defined as follows:
        /// The left subtree of a node contains only nodes with keys less than or equal to the node's key.
        /// The right subtree of a node contains only nodes with keys greater than or equal to the node's key.
        /// Both the left and right subtrees must also be binary search trees.
        /// </summary>
        public _00501_FindModeInBinarySearchTree()
        {
            int[] a0 = [1, 0, 2, 2];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            int[] x = FindMode0(l0);
            RftTerminal.RftReadResult(x);
        }

        public static int[] FindMode0(TreeNode0? a0) => RftFindMode0(a0);

        private static int[] RftFindMode0(TreeNode0? root)
        {
            if (root is null) return [];

            Stack<TreeNode0> s = new();
            s.Push(root);
            Dictionary<int, int> r = [];

            while (s.Count != 0)
            {
                TreeNode0 t = s.Pop();

                if (r.TryGetValue(t.val, out int value)) r[t.val] = ++value;
                else r[t.val] = 1;

                if (t.right is not null) s.Push(t.right);
                if (t.left is not null) s.Push(t.left);
            }

            int max = r.Max(o => o.Value);

            return r.Where(o => o.Value == max).Select(o => o.Key).ToArray();
        }
    }
}
