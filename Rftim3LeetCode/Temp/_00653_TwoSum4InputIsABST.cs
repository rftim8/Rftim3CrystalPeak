using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00653_TwoSum4InputIsABST
    {
        /// <summary>
        /// Given the root of a binary search tree and an integer k, return true if there exist two elements in the BST such that their sum is equal to k, or false otherwise.
        /// </summary>
        public _00653_TwoSum4InputIsABST()
        {
            TreeNode0 a5 = new(7, null, null);
            TreeNode0 a4 = new(4, null, null);
            TreeNode0 a3 = new(2, null, null);
            TreeNode0 a2 = new(6, null, a5);
            TreeNode0 a1 = new(3, a3, a4);
            TreeNode0 a0 = new(5, a1, a2);

            Console.WriteLine(FindTarget(a0, 9));
        }

        private static bool FindTarget(TreeNode0 root, int k)
        {
            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                TreeNode0 c = q.Dequeue();

                if (c.val != k - c.val && Rec(root, k - c.val)) return true;

                if (c.left is not null) q.Enqueue(c.left);
                if (c.right is not null) q.Enqueue(c.right);
            }

            return false;
        }

        private static bool Rec(TreeNode0? root, int k)
        {
            if (root is null) return false;

            if (root.val == k) return true;
            if (root.val > k) return Rec(root.left, k);
            else return Rec(root.right, k);
        }
    }
}
