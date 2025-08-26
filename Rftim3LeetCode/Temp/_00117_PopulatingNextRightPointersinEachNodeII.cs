using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00117_PopulatingNextRightPointersInEachNodeII
    {
        /// <summary>
        /// Given a binary tree
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
        public _00117_PopulatingNextRightPointersInEachNodeII()
        {
            Node a6 = new(7, null, null, null);
            Node a4 = new(5, null, null, null);
            Node a3 = new(4, null, null, null);
            Node a2 = new(3, null, a6, a6);
            Node a1 = new(2, a3, a4, a3);
            Node a0 = new(1, a1, a2, a1);

            PopulatingNextRightPointersInEachNodeII0(a0);
        }

        public static Node? PopulatingNextRightPointersInEachNodeII0(Node? a0) => RftPopulatingNextRightPointersInEachNodeII0(a0);

        public static Node? PopulatingNextRightPointersInEachNodeII1(Node? a0) => RftPopulatingNextRightPointersInEachNodeII1(a0);

        private static Node? RftPopulatingNextRightPointersInEachNodeII0(Node? root)
        {
            if (root is null) return root;

            Queue<Node> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                int c = q.Count;

                while (c > 0)
                {
                    Node x = q.Dequeue();
                    Console.WriteLine(x.val);

                    if (c != 1) x.next = q.Peek();
                    if (x.left is not null) q.Enqueue(x.left);
                    if (x.right is not null) q.Enqueue(x.right);

                    c--;
                }
            }

            return root;
        }

        private static Node? RftPopulatingNextRightPointersInEachNodeII1(Node? root)
        {
            if (root is null) return null;

            Queue<(Node node, int level)> q = new();
            q.Enqueue((root, 0));

            while (q.Count != 0)
            {
                (Node node, int level) = q.Dequeue();

                if (q.TryPeek(out var next) && next.level == level) node.next = next.node;
                if (node.left is not null) q.Enqueue((node.left, level + 1));
                if (node.right is not null) q.Enqueue((node.right, level + 1));
            }

            return root;
        }
    }
}