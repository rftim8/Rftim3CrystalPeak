using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00236_LowestCommonAncestorOfABinaryTree
    {
        /// <summary>
        /// Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
        /// According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q 
        /// as the lowest node in T that has both p and q as descendants(where we allow a node to be a descendant of itself).”
        /// </summary>
        public _00236_LowestCommonAncestorOfABinaryTree()
        {
            TreeNode0 a8 = new(4);
            TreeNode0 a7 = new(7);
            TreeNode0 a6 = new(8);
            TreeNode0 a5 = new(0);
            TreeNode0 a4 = new(2, a7, a8);
            TreeNode0 a3 = new(6);
            TreeNode0 a2 = new(1, a5, a6);
            TreeNode0 a1 = new(5, a3, a4);
            TreeNode0 a0 = new(3, a1, a2);

            LowestCommonAncestor(a0, a1, a2);
        }

        private static TreeNode0? LowestCommonAncestor(TreeNode0 root, TreeNode0? p, TreeNode0? q)
        {
            Stack<TreeNode0> stack = new();
            Dictionary<TreeNode0, TreeNode0?> parent = new()
            {
                { root, null }
            };
            stack.Push(root);

            while (!parent.ContainsKey(p!) || !parent.ContainsKey(q!))
            {
                TreeNode0 node = stack.Pop();

                if (node.left is not null)
                {
                    parent.Add(node.left, node);
                    stack.Push(node.left);
                }
                if (node.right is not null)
                {
                    parent.Add(node.right, node);
                    stack.Push(node.right);
                }
            }

            HashSet<TreeNode0?> ancestors = new();

            while (p is not null)
            {
                ancestors.Add(p);
                p = parent[p];
            }

            while (!ancestors.Contains(q))
            {
                q = parent[q];
            }

            Console.WriteLine(q);

            return q;
        }

        private static TreeNode0? ans;

        private static TreeNode0? LowestCommonAncestor0(TreeNode0 root, TreeNode0 p, TreeNode0 q)
        {
            RecurseTree(root, p, q);
            return ans;
        }

        private static bool RecurseTree(TreeNode0? currentNode, TreeNode0 p, TreeNode0 q)
        {
            if (currentNode is null) return false;

            int left = RecurseTree(currentNode.left, p, q) ? 1 : 0;
            int right = RecurseTree(currentNode.right, p, q) ? 1 : 0;
            int mid = currentNode == p || currentNode == q ? 1 : 0;

            if (mid + left + right >= 2) ans = currentNode;

            return mid + left + right > 0;
        }
    }
}
