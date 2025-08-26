using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00108_ConvertSortedArrayToBinarySearchTree
    {
        // <summary>
        /// Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.
        /// </summary>
        public _00108_ConvertSortedArrayToBinarySearchTree()
        {

        }

        public static TreeNode0? ConvertSortedArrayToBinarySearchTree0(int[] a0) => RftConvertSortedArrayToBinarySearchTree0(a0);

        private static TreeNode0? RftConvertSortedArrayToBinarySearchTree0(int[] nums)
        {
            int n = nums.Length;

            return Dfs(nums, 0, n - 1);
        }


        private static TreeNode0? Dfs(int[] nums, int i, int j)
        {
            if (j < i) return null;

            Console.WriteLine($"{i} -> {j}");
            int mid = j + (i - j) / 2;
            Console.WriteLine(mid);

            TreeNode0 node = new(nums[mid])
            {
                left = Dfs(nums, i, mid - 1),
                right = Dfs(nums, mid + 1, j)
            };

            return node;
        }
    }
}