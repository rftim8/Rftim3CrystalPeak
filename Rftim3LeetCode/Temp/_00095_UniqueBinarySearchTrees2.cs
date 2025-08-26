using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00095_UniqueBinarySearchTrees2
    {
        /// <summary>
        /// Given an integer n, return all the structurally unique BST's (binary search trees), which has exactly n nodes of unique values from 1 to n. 
        /// Return the answer in any order.
        /// </summary>
        public _00095_UniqueBinarySearchTrees2()
        {
            IList<TreeNode0?> x = GenerateTrees(3);

            foreach (TreeNode0? item in x)
            {
                if (item?.left is not null) Console.Write($"l: {item.left.val} ");
                Console.Write($"p: {item?.val} ");
                if (item?.right is not null) Console.Write($"r: {item.right.val} ");
                Console.WriteLine();
            }
        }

        private static List<TreeNode0?> GenerateTrees(int n)
        {
            return GenerateTree(1, n);
        }

        private static List<TreeNode0?> GenerateTree(int min, int max)
        {
            List<TreeNode0?> res = [];
            if (max < min)
            {
                res.Add(null);
                return res;
            }

            for (int i = min; i <= max; i++)
            {
                List<TreeNode0?> left = GenerateTree(min, i - 1);
                List<TreeNode0?> right = GenerateTree(i + 1, max);
                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        TreeNode0 root = new(i)
                        {
                            left = l,
                            right = r
                        };
                        res.Add(root);
                    }
                }
            }

            return res;
        }
    }
}
