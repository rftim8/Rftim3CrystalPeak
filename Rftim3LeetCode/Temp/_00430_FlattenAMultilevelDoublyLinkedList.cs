using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00430_FlattenAMultilevelDoublyLinkedList
    {
        /// <summary>
        /// You are given a doubly linked list, which contains nodes that have a next pointer, 
        /// a previous pointer, and an additional child pointer. 
        /// This child pointer may or may not point to a separate doubly linked list, 
        /// also containing these special nodes. 
        /// These child lists may have one or more children of their own, and so on, 
        /// to produce a multilevel data structure as shown in the example below.
        /// 
        /// Given the head of the first level of the list, 
        /// flatten the list so that all the nodes appear in a single-level, 
        /// doubly linked list.Let curr be a node with a child list.
        /// The nodes in the child list should appear after curr and before curr.next in the flattened list.
        /// 
        /// Return the head of the flattened list.
        /// The nodes in the list must have all of their child pointers set to null.
        /// </summary>
        public _00430_FlattenAMultilevelDoublyLinkedList()
        {

        }

        public static int FlattenAMultilevelDoublyLinkedList0(int[] a0) => RftFlattenAMultilevelDoublyLinkedList0(a0);

        private static int RftFlattenAMultilevelDoublyLinkedList0(int[] a0)
        {
            int res = 0;



            return res;
        }

        // DFS by iteration
        private static Node Flatten(Node head)
        {
            if (head == null) return head;

            Node pseudoHead = new(0, null, head, null);
            Node curr, prev = pseudoHead;

            Stack<Node> stack = [];
            stack.Push(head);

            while (stack.Count != 0)
            {
                curr = stack.Pop();
                prev.right = curr;
                curr.left = prev;

                if (curr.right != null) stack.Push(curr.right);
                if (curr.next != null)
                {
                    stack.Push(curr.next);
                    curr.next = null;
                }
                prev = curr;
            }
            pseudoHead.next.left = null;

            return pseudoHead.next;
        }

        // DFS by recursion
        private static Node Flatten0(Node head)
        {
            if (head == null) return head;

            Node pseudoHead = new(0, null, head, null);

            FlattenDFS(pseudoHead, head);

            pseudoHead.right.left = null;

            return pseudoHead.right;
        }

        private static Node FlattenDFS(Node prev, Node curr)
        {
            if (curr == null) return prev;

            curr.left = prev;
            prev.right = curr;

            Node tempNext = curr.right;

            Node tail = FlattenDFS(curr, curr.next);
            curr.next = null;

            return FlattenDFS(tail, tempNext);
        }
    }
}
