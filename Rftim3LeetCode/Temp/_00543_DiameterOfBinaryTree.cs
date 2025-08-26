using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00543_DiameterOfBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree, return the length of the diameter of the tree.
        /// The diameter of a binary tree is the length of the longest path between any two nodes in a tree.
        /// This path may or may not pass through the root.
        /// The length of a path between two nodes is represented by the number of edges between them.
        /// </summary>
        public _00543_DiameterOfBinaryTree()
        {
            int[] a0 = [1, 2, 3, 4, 5];
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(a0);

            Console.WriteLine(DiameterOfBinaryTree0(l0));
        }

        public static int DiameterOfBinaryTree0(TreeNode0? a0) => RftDiameterOfBinaryTree0(a0);

        private static int RftDiameterOfBinaryTree0(TreeNode0? root)
        {
            int x = 0;

            Dfs(root);

            int Dfs(TreeNode0? node)
            {
                if (node is null) return 0;

                int l = Dfs(node.left);
                int r = Dfs(node.right);

                x = Math.Max(x, l + r);

                return Math.Max(l, r) + 1;
            }

            return x;
        }
    }
}
