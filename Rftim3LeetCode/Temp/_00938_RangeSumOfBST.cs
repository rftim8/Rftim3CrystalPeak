using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00938_RangeSumOfBST
    {
        /// <summary>
        /// Given the root node of a binary search tree and two integers low and high, return the sum of values of all nodes with a value in the inclusive range [low, high].
        /// </summary>
        public _00938_RangeSumOfBST()
        {
            TreeNode0 a5 = new(18);
            TreeNode0 a4 = new(7);
            TreeNode0 a3 = new(3);
            TreeNode0 a2 = new(15, null, a5);
            TreeNode0 a1 = new(5, a3, a4);
            TreeNode0 a0 = new(10, a1, a2);

            Console.WriteLine(RangeSumBST(a0, 7, 15));
        }

        private static int RangeSumBST(TreeNode0 root, int low, int high)
        {
            Stack<TreeNode0> s = new();
            s.Push(root);

            int r = 0;

            while (s.Count != 0)
            {
                TreeNode0 t = s.Pop();
                if (t.val >= low && t.val <= high) r += t.val;

                if (t.left is not null) s.Push(t.left);
                if (t.right is not null) s.Push(t.right);
            }

            return r;
        }

        private static int RangeSumBST0(TreeNode0? root, int low, int high)
        {
            if (root is null) return 0;

            int result = 0;
            if (root.val >= low && root.val <= high) result += root.val;

            int left = RangeSumBST0(root.left, low, high);
            int right = RangeSumBST0(root.right, low, high);

            return result + left + right;
        }
    }
}
