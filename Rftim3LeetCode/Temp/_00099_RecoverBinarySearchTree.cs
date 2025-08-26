using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00099_RecoverBinarySearchTree
    {
        /// <summary>
        /// You are given the root of a binary search tree (BST), where the values of exactly two nodes of the tree were swapped by mistake. 
        /// Recover the tree without changing its structure.
        /// </summary>
        public _00099_RecoverBinarySearchTree()
        {
            TreeNode0 a2 = new(2);
            TreeNode0 a1 = new(3, null, a2);
            TreeNode0 a0 = new(1, a1);

            RecoverTree(a0);
        }

        private static List<int>? r;
        private static int i;

        private static void RecoverTree(TreeNode0? root)
        {
            r = [];
            i = 0;

            static void DFS(TreeNode0? root)
            {
                if (root is not null)
                {
                    DFS(root.left);
                    r?.Add(root.val);
                    DFS(root.right);
                }
            }

            DFS(root);
            r.Sort();

            static void Tree(ref TreeNode0? root)
            {
                if (root is not null)
                {
                    Tree(ref root.left);
                    root.val = r![i++];
                    Tree(ref root.right);
                }
            }

            Tree(ref root);
        }
    }
}
