using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00450_DeleteNodeInABST
    {
        /// <summary>
        /// Given a root node reference of a BST and a key, delete the node with the given key in the BST.
        /// Return the root node reference (possibly updated) of the BST.
        /// Basically, the deletion can be divided into two stages:
        /// Search for a node to remove.
        /// If the node is found, delete the node.
        /// </summary>
        public _00450_DeleteNodeInABST()
        {
            TreeNode0 a5 = new(7, null, null);
            TreeNode0 a4 = new(4, null, null);
            TreeNode0 a3 = new(2, null, null);
            TreeNode0 a2 = new(6, null, a5);
            TreeNode0 a1 = new(3, a3, a4);
            TreeNode0 a0 = new(5, a1, a2);

            Console.WriteLine(DeleteNode(a0, 3)?.val);
        }

        private static TreeNode0? DeleteNode(TreeNode0? root, int key)
        {
            if (root is null) return null;

            if (key < root.val) root.left = DeleteNode(root.left, key);
            else if (key > root.val) root.right = DeleteNode(root.right, key);
            else
            {
                if (root.left is null) return root.right;
                else if (root.right is null) return root.left;

                TreeNode0 minNode = MinNode(root.right);
                root.val = minNode.val;
                root.right = DeleteNode(root.right, root.val);
            }

            return root;
        }

        private static TreeNode0 MinNode(TreeNode0 root)
        {
            while (root.left is not null) root = root.left;

            return root;
        }

        private static TreeNode0? DeleteNode0(TreeNode0 root, int key)
        {
            if (root is null) return null;
            if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
                return root;
            }
            if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
                return root;
            }
            if (root.left is null) return root.right;
            if (root.right is null) return root.left;
            TreeNode0 node = root.right;

            while (node.left is not null)
            {
                node = node.left;
            }

            node.left = root.left;
            root = root.right;

            return root;
        }
    }
}
