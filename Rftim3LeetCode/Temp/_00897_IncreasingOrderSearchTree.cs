using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00897_IncreasingOrderSearchTree
    {
        /// <summary>
        /// Given the root of a binary search tree, rearrange the tree in in-order so that the leftmost node in the tree is now the root of the tree,
        /// and every node has no left child and only one right child.
        /// </summary>
        public _00897_IncreasingOrderSearchTree()
        {
            TreeNode0 a8 = new(9);
            TreeNode0 a7 = new(7);
            TreeNode0 a6 = new(1);
            TreeNode0 a5 = new(8, a7, a8);
            TreeNode0 a4 = new(4);
            TreeNode0 a3 = new(2, a6);
            TreeNode0 a2 = new(6, null, a5);
            TreeNode0 a1 = new(3, a3, a4);
            TreeNode0 a0 = new(5, a1, a2);

            Console.WriteLine(IncreasingBST(a0)!.val);
        }

        private static TreeNode0? IncreasingBST(TreeNode0 root)
        {
            Stack<TreeNode0> s = new();
            s.Push(root);

            List<int> r = [];

            while (s.Count != 0)
            {
                TreeNode0 t = s.Pop();
                r.Add(t.val);

                if (t.left is not null) s.Push(t.left);
                if (t.right is not null) s.Push(t.right);
            }

            r.Sort();

            TreeNode0 n = new(0), c = n;
            foreach (int item in r)
            {
                c.right = new(item);
                c = c.right;
            }

            return n.right;
        }

        private static TreeNode0? IncreasingBST0(TreeNode0? root)
        {
            TreeNode0? res_s = null;
            TreeNode0? res_e = null;

            TreeNode0? curr = root;
            Stack<TreeNode0> stack = new();

            while (curr is not null || stack.Count > 0)
            {
                while (curr is not null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }

                curr = stack.Pop();

                if (res_s is null) res_s = res_e = curr;
                else
                {
                    res_e!.left = null;
                    res_e.right = curr;
                    res_e = curr;
                }

                curr = curr.right;
            }

            if (res_e is not null) res_e.left = null;

            return res_s;
        }

        private static TreeNode0? IncreasingBST1(TreeNode0? root)
        {
            List<int> vals = [];

            Inorder(root, vals);

            TreeNode0 ans = new(0), cur = ans;

            foreach (int v in vals)
            {
                cur.right = new TreeNode0(v);
                cur = cur.right;
            }

            return ans.right;
        }

        private static void Inorder(TreeNode0? node, List<int> vals)
        {
            if (node is null) return;

            Inorder(node.left, vals);
            vals.Add(node.val);
            Inorder(node.right, vals);
        }
    }
}
