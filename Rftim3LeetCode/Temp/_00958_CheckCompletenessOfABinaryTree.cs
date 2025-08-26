using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00958_CheckCompletenessOfABinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, determine if it is a complete binary tree.
        /// In a complete binary tree, every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible.
        /// It can have between 1 and 2h nodes inclusive at the last level h.
        /// </summary>
        public _00958_CheckCompletenessOfABinaryTree()
        {
            TreeNode0 a5 = new(6, null, null);
            TreeNode0 a4 = new(5, null, null);
            TreeNode0 a3 = new(4, null, null);
            TreeNode0 a2 = new(3, a5, null);
            TreeNode0 a1 = new(2, a3, a4);
            TreeNode0 a0 = new(1, a1, a2);

            Console.WriteLine(IsCompleteTree(a0));
        }
        private static bool IsCompleteTree(TreeNode0 root)
        {
            if (root is null) return true;

            bool nullNodeFound = false;
            Queue<TreeNode0?> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                TreeNode0? node = q.Dequeue();

                if (node is null) nullNodeFound = true;
                else
                {
                    if (nullNodeFound) return false;

                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }

            return true;
        }
    }
}
