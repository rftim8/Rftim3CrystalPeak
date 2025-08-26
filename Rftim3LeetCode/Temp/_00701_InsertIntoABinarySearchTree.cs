using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00701_InsertIntoABinarySearchTree
    {
        /// <summary>
        /// You are given the root node of a binary search tree (BST) and a value to insert into the tree. 
        /// Return the root node of the BST after the insertion. It is guaranteed that the new value does not exist in the original BST.
        /// Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion.You can return any of them.
        /// </summary>
        public _00701_InsertIntoABinarySearchTree()
        {
            TreeNode0 a4 = new(7, null, null);
            TreeNode0 a3 = new(3, null, null);
            TreeNode0 a2 = new(1, null, null);
            TreeNode0 a1 = new(2, a2, a3);
            TreeNode0 a0 = new(4, a1, a4);

            Console.WriteLine(InsertIntoBST(a0, 5)?.val);
        }

        private static TreeNode0? InsertIntoBST(TreeNode0 root, int val)
        {
            if (root is null) return new TreeNode0(val);

            DFS(root, val);

            return root;
        }

        private static void DFS(TreeNode0 node, int val)
        {
            if (node.val > val)
            {
                if (node.left is null) node.left = new TreeNode0(val);
                else DFS(node.left, val);
            }
            else
            {
                if (node.right is null) node.right = new TreeNode0(val);
                else DFS(node.right, val);
            }
        }
    }
}
