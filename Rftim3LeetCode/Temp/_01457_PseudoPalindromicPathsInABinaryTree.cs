using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01457_PseudoPalindromicPathsInABinaryTree
    {
        /// <summary>
        /// Given a binary tree where node values are digits from 1 to 9. 
        /// A path in the binary tree is said to be pseudo-palindromic if at least one permutation of the node values in the path is a palindrome.
        /// 
        /// Return the number of pseudo-palindromic paths going from the root node to leaf nodes.
        /// </summary>
        public _01457_PseudoPalindromicPathsInABinaryTree()
        {
            int[] x = [2, 3, 1, 3, 1, 0, 1];
            TreeNode0? x0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(x);
            Console.WriteLine(PseudoPalindromicPaths0(x0));
        }

        public static int PseudoPalindromicPaths0(TreeNode0? a0) => RftPseudoPalindromicPaths0(a0);

        public static int PseudoPalindromicPaths1(TreeNode0? a0) => RftPseudoPalindromicPaths1(a0);

        public static int PseudoPalindromicPaths2(TreeNode0? a0) => RftPseudoPalindromicPaths2(a0);

        #region Iterative Preorder Traversal
        private static int RftPseudoPalindromicPaths0(TreeNode0? root)
        {
            int count = 0;

            Stack<(TreeNode0?, int)> stack = [];
            stack.Push((root, 0));
            while (stack.Count != 0)
            {
                (TreeNode0?, int) p = stack.Pop();
                TreeNode0? node = p.Item1;
                int path = p.Item2;

                if (node != null)
                {
                    path ^= 1 << node.val;
                    if (node.left == null && node.right == null)
                    {
                        if ((path & path - 1) == 0) ++count;
                    }
                    else
                    {
                        stack.Push((node.right, path));
                        stack.Push((node.left, path));
                    }
                }
            }

            return count;
        }
        #endregion

        #region Recursive Preorder Traversal
        private static int count;

        private static void Preorder(TreeNode0? node, int path)
        {
            if (node != null)
            {
                path ^= 1 << node.val;
                if (node.left == null && node.right == null)
                {
                    if ((path & path - 1) == 0) ++count;
                }

                Preorder(node.left, path);
                Preorder(node.right, path);
            }
        }

        private static int RftPseudoPalindromicPaths1(TreeNode0? root)
        {
            count = 0;
            Preorder(root, 0);

            return count;
        }
        #endregion

        #region Recursive Preorder Traversal
        private static int RftPseudoPalindromicPaths2(TreeNode0? root)
        {
            return CountPaths(root, new int[10]);
        }

        private static int CountPaths(TreeNode0? node, int[] count)
        {
            if (node == null) return 0;

            count[node.val]++;
            if (node.left == null && node.right == null)
            {
                int oddCount = 0;
                for (int i = 1; i <= 9; i++)
                {
                    if (count[i] % 2 == 1) oddCount++;
                }

                count[node.val]--;

                return oddCount <= 1 ? 1 : 0;
            }

            int leftCount = CountPaths(node.left, count);
            int rightCount = CountPaths(node.right, count);

            count[node.val]--;

            return leftCount + rightCount;
        }
        #endregion
    }
}
