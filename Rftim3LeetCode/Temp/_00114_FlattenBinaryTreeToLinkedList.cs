using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00114_FlattenBinaryTreeToLinkedList
    {
        /// <summary>
        /// Given the root of a binary tree, flatten the tree into a "linked list":
        /// The "linked list" should use the same TreeNode class where the right child pointer points to the next node in the list and the left child pointer is always null.
        /// The "linked list" should be in the same order as a pre-order traversal of the binary tree.
        /// </summary>
        public _00114_FlattenBinaryTreeToLinkedList()
        {
            TreeNode0 a5 = new(6);
            TreeNode0 a4 = new(4);
            TreeNode0 a3 = new(3);
            TreeNode0 a2 = new(5, null, a5);
            TreeNode0 a1 = new(2, a3, a4);
            TreeNode0 a0 = new(1, a1, a2);

            Flatten(a0);
        }

        private static void Flatten(TreeNode0 root)
        {
            if (root is null) return;

            DFS(root);
        }

        private static TreeNode0? DFS(TreeNode0 root)
        {
            if (root.left is null && root.right is null) return root;

            TreeNode0? l = root.left is null ? null : DFS(root.left);
            TreeNode0? r = root.right is null ? null : DFS(root.right);

            if (l is not null && r is not null)
            {
                l.right = root.right;
                root.right = root.left;
                root.left = null;

                return r;
            }
            else if (l is not null)
            {
                root.right = root.left;
                root.left = null;

                return l;
            }
            else return r;
        }

        private static void Flatten0(TreeNode0 root)
        {
            if (root is null) return;

            Helper(root);
        }

        private static TreeNode0? Helper(TreeNode0? root)
        {
            if (root?.right is null && root?.left is null) return root;
            if (root.left is not null)
            {
                TreeNode0? temp = Helper(root.left);
                TreeNode0? temp2 = root.right;

                root.right = root.left;
                temp!.right = temp2;
                root.left = null;

                if (temp2 is not null) return Helper(temp2);
                else return temp;
            }
            else return Helper(root.right);
        }
    }
}
