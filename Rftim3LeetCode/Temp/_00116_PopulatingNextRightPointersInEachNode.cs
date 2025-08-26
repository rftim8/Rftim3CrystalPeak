using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00116_PopulatingNextRightPointersInEachNode
    {
        /// <summary>
        /// You are given a perfect binary tree where all leaves are on the same level, and every parent has two children. The binary tree has the following definition:
        /// struct Node
        /// {
        ///     int val;
        ///     Node* left;
        ///     Node* right;
        ///     Node* next;
        /// }
        /// Populate each next pointer to point to its next right node.If there is no next right node, the next pointer should be set to NULL.
        /// Initially, all next pointers are set to NULL.
        /// </summary>
        public _00116_PopulatingNextRightPointersInEachNode()
        {
            Node a6 = new(7);
            Node a5 = new(6, null, null, a6);
            Node a4 = new(5, null, null, a5);
            Node a3 = new(4, null, null, a4);
            Node a2 = new(3, a6, a5, null);
            Node a1 = new(2, a4, a3, a2);
            Node a0 = new(1, a2, a1, null);

            PopulatingNextRightPointersInEachNode0(a0);
        }

        public static Node? PopulatingNextRightPointersInEachNode0(Node a0) => RftPopulatingNextRightPointersInEachNode0(a0);

        private static Node? RftPopulatingNextRightPointersInEachNode0(Node root)
        {
            if (root is null) return root;

            Queue<Node> q = new();
            q.Enqueue(root);

            while (q.Any())
            {
                int n = q.Count;

                Node? prev = null;
                for (int i = 0; i < n; i++)
                {
                    Node c = q.Dequeue();
                    Console.WriteLine(c.val);
                    if (prev is null) prev = c;
                    else
                    {
                        prev.next = c;
                        prev = c;
                    }

                    if (c.left is not null) q.Enqueue(c.left);
                    if (c.right is not null) q.Enqueue(c.right);
                }
                prev!.next = null;
            }

            return root;
        }
    }
}