using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree
    {
        /// <summary>
        /// Given two binary trees original and cloned and given a reference to a node target in the original tree.
        /// The cloned tree is a copy of the original tree.
        /// Return a reference to the same node in the cloned tree.
        /// Note that you are not allowed to change any of the two trees or the target node and the answer must be a reference to a node in the cloned tree.
        /// </summary>
        public _01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree()
        {
            TreeNode0 a4 = new(19);
            TreeNode0 a3 = new(6);
            TreeNode0 a2 = new(3, a3, a4);
            TreeNode0 a1 = new(4);
            TreeNode0 a0 = new(7, a1, a2);

            TreeNode0 b4 = new(19);
            TreeNode0 b3 = new(6);
            TreeNode0 b2 = new(3, b3, b4);
            TreeNode0 b1 = new(4);
            TreeNode0 b0 = new(7, b1, b2);

            Console.WriteLine(FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree0(a0, b0, b2).val);
        }

        public static TreeNode0 FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree0(TreeNode0 a0, TreeNode0 a1, TreeNode0 a2) => RftFindACorrespondingNodeOfABinaryTreeInACloneOfThatTree0(a0, a1, a2);

        private static TreeNode0 RftFindACorrespondingNodeOfABinaryTreeInACloneOfThatTree0(TreeNode0 original, TreeNode0 cloned, TreeNode0 target)
        {
            Stack<TreeNode0> s = new();
            s.Push(original);
            Stack<TreeNode0> s0 = new();
            s0.Push(cloned);

            while (s.Count != 0)
            {
                TreeNode0 t = s.Pop();
                TreeNode0 t0 = s0.Pop();

                if (t.val == target.val) return t0;

                if (t.left is not null) s.Push(t.left);
                if (t.right is not null) s.Push(t.right);
                if (t0.left is not null) s0.Push(t0.left);
                if (t0.right is not null) s0.Push(t0.right);
            }

            return original;
        }
    }
}