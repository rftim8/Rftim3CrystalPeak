using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00222_CountCompleteTreeNodes
    {
        /// <summary>
        /// Given the root of a complete binary tree, return the number of the nodes in the tree.
        /// According to Wikipedia, every level, except possibly the last, is completely filled in a complete binary tree, 
        /// and all nodes in the last level are as far left as possible.It can have between 1 and 2h nodes inclusive at the last level h.
        /// Design an algorithm that runs in less than O(n) time complexity.
        /// </summary>
        public _00222_CountCompleteTreeNodes()
        {
            int[] a0 = [1, 2, 3, 4, 5, 6];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            Console.WriteLine(CountNodes0(l0));
        }

        public static int CountNodes0(TreeNode0? a0) => RftCountNodes0(a0);

        private static int RftCountNodes0(TreeNode0? root)
        {
            if (root is null) return 0;

            int r = 0;
            Stack<TreeNode0> s = new();
            s.Push(root);

            while (s.Count != 0)
            {
                r++;
                TreeNode0? t = s.Pop();

                if (t.right is not null) s.Push(t.right);
                if (t.left is not null) s.Push(t.left);
            }

            return r;
        }
    }
}
