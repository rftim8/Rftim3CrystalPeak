using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00783_MinimumDistanceBetweenBSTNodes
    {
        /// <summary>
        /// Given the root of a Binary Search Tree (BST), return the minimum difference between the values of any two different nodes in the tree.
        /// </summary>
        public _00783_MinimumDistanceBetweenBSTNodes()
        {
            TreeNode0 a4 = new(3);
            TreeNode0 a3 = new(1);
            TreeNode0 a2 = new(6);
            TreeNode0 a1 = new(2, a3, a4);
            TreeNode0 a0 = new(4, a1, a2);

            Console.WriteLine(MinDiffInBST(a0));
        }

        private static int MinDiffInBST(TreeNode0 root)
        {
            Stack<TreeNode0> s = new();
            s.Push(root);

            List<int> x = [];

            while (s.Count != 0)
            {
                TreeNode0 t = s.Pop();
                x.Add(t.val);

                if (t.left is not null) s.Push(t.left);
                if (t.right is not null) s.Push(t.right);
            }
            x.Sort();

            int r = int.MaxValue;

            for (int i = 1; i < x.Count; i++)
            {
                r = Math.Min(x[i] - x[i - 1], r);
            }

            return r;
        }
    }
}
