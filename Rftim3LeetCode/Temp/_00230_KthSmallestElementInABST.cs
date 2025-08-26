using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00230_KthSmallestElementinaBST
    {
        /// <summary>
        /// Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.
        /// </summary>
        public _00230_KthSmallestElementinaBST()
        {
            TreeNode0 a3 = new(2, null, null);
            TreeNode0 a2 = new(4, null, null);
            TreeNode0 a1 = new(1, null, a3);
            TreeNode0 a0 = new(3, a1, a2);

            Console.WriteLine(KthSmallestElementinaBST0(a0, 1));
        }

        public static int KthSmallestElementinaBST0(TreeNode0 a0, int a1) => RftKthSmallestElementinaBST0(a0, a1);

        public static int KthSmallestElementinaBST1(TreeNode0 a0, int a1) => RftKthSmallestElementinaBST1(a0, a1);

        private static int RftKthSmallestElementinaBST0(TreeNode0? root, int k)
        {
            Stack<TreeNode0> stack = new();

            while (true)
            {
                while (root is not null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (--k == 0) return root.val;
                root = root.right;
            }
        }


        private static int RftKthSmallestElementinaBST1(TreeNode0 root, int k)
        {
            List<int> nums = DfsInorder(root, []);

            return nums[k - 1];
        }

        private static List<int> DfsInorder(TreeNode0? root, List<int> x)
        {
            if (root is null) return x;

            DfsInorder(root.left, x);
            x.Add(root.val);
            DfsInorder(root.right, x);

            return x;
        }
    }
}