using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00250_CountUnivalueSubtrees
    {
        /// <summary>
        /// Given the root of a binary tree, return the number of uni-value 
        /// subtrees.
        /// 
        /// A uni-value subtree means all nodes of the subtree have the same value.
        /// </summary>
        public _00250_CountUnivalueSubtrees()
        {
            int?[] a0 = [5, 1, 5, 5, 5, null, 5];
            TreeNode? a1 = RftTreeNodesBuilder.RftCreateListOfBinaryNullableTreeNodes(a0);

            Console.WriteLine(CountUnivalueSubtrees0(a1));
        }

        public static int CountUnivalueSubtrees0(TreeNode? a0) => RftCountUnivalueSubtrees0(a0);

        private static int count;

        private static int RftCountUnivalueSubtrees0(TreeNode? root)
        {
            count = 0;
            Dfs(root);

            return count;
        }

        private static bool Dfs(TreeNode? node)
        {
            if (node == null) return true;

            bool left = Dfs(node.left);
            bool right = Dfs(node.right);

            if (left && right)
            {
                if (node.left != null && node.left.val != node.val) return false;
                if (node.right != null && node.right.val != node.val) return false;

                count++;

                return true;
            }

            return false;
        }
    }
}
