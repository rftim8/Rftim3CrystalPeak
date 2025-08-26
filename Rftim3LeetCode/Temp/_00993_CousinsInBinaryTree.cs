using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00993_CousinsInBinaryTree
    {
        /// <summary>
        /// Given the root of a binary tree with unique values and the values of two different nodes of the tree x and y,
        /// return true if the nodes corresponding to the values x and y in the tree are cousins, or false otherwise.
        /// Two nodes of a binary tree are cousins if they have the same depth with different parents.
        /// Note that in a binary tree, the root node is at the depth 0, and children of each depth k node are at the depth k + 1.
        /// </summary>
        public _00993_CousinsInBinaryTree()
        {
            TreeNode0 a3 = new(4);
            TreeNode0 a2 = new(3);
            TreeNode0 a1 = new(2, a3);
            TreeNode0 a0 = new(1, a1, a2);

            TreeNode0 b4 = new(5);
            TreeNode0 b3 = new(4);
            TreeNode0 b2 = new(3, null, b4);
            TreeNode0 b1 = new(2, null, b3);
            TreeNode0 b0 = new(1, b1, b2);

            Console.WriteLine(IsCousins(b0, 5, 4));
        }

        private static bool IsCousins(TreeNode0 root, int x, int y)
        {
            int a = 0;
            Queue<TreeNode0> q = new();
            q.Enqueue(root);

            List<int> l = [];

            while (q.Count != 0)
            {
                a++;
                int n = q.Count;
                for (int i = 0; i < n; i++)
                {
                    TreeNode0 c = q.Dequeue();

                    bool lt = c.left is not null;
                    bool rt = c.right is not null;

                    int d = 0;

                    if (lt)
                    {
                        if (c.left!.val == x || c.left!.val == y)
                        {
                            l.Add(a);
                            d++;
                        }
                        q.Enqueue(c.left);
                    }

                    if (rt)
                    {
                        if (c.right!.val == x || c.right!.val == y)
                        {
                            l.Add(a);
                            d++;
                        }
                        q.Enqueue(c.right);
                    }

                    if (d == 2) return false;
                }
            }

            if (l.Count < 2) return false;

            return l[0] == l[1];
        }
    }
}
