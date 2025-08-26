using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00872_LeafSimilarTrees
    {
        /// <summary>
        /// Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.
        /// For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).
        /// Two binary trees are considered leaf-similar if their leaf value sequence is the same.
        /// Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.
        /// </summary>
        public _00872_LeafSimilarTrees()
        {
            TreeNode0 a8 = new(4);
            TreeNode0 a7 = new(7);
            TreeNode0 a6 = new(8);
            TreeNode0 a5 = new(9);
            TreeNode0 a4 = new(2, a7, a8);
            TreeNode0 a3 = new(6);
            TreeNode0 a2 = new(1, a5, a6);
            TreeNode0 a1 = new(5, a3, a4);
            TreeNode0 a0 = new(3, a1, a2);

            TreeNode0 b8 = new(4);
            TreeNode0 b7 = new(7);
            TreeNode0 b6 = new(8);
            TreeNode0 b5 = new(9);
            TreeNode0 b4 = new(2, b7, b8);
            TreeNode0 b3 = new(6);
            TreeNode0 b2 = new(1, b5, b6);
            TreeNode0 b1 = new(5, b3, b4);
            TreeNode0 b0 = new(3, b1, b2);

            Console.WriteLine(LeafSimilar(a0, b0));
        }

        private static bool LeafSimilar(TreeNode0 root1, TreeNode0 root2)
        {
            Stack<TreeNode0> s0 = new();
            s0.Push(root1);

            Stack<TreeNode0> s1 = new();
            s1.Push(root2);

            List<int> r0 = ReturnLeafs(s0);
            List<int> r1 = ReturnLeafs(s1);

            return r0.SequenceEqual(r1);
        }

        private static List<int> ReturnLeafs(Stack<TreeNode0> s)
        {
            List<int> r = [];

            while (s.Count != 0)
            {
                TreeNode0 t = s.Pop();

                if (t.left is null && t.right is null) r.Add(t.val);

                if (t.left is not null) s.Push(t.left);
                if (t.right is not null) s.Push(t.right);
            }

            return r;
        }
    }
}
