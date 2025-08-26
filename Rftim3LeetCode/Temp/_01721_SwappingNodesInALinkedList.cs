using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01721_SwappingNodesInALinkedList
    {
        /// <summary>
        /// You are given the head of a linked list, and an integer k.
        /// Return the head of the linked list after swapping the values of the kth node from the beginning and the kth node from the end(the list is 1-indexed).
        /// </summary>
        public _01721_SwappingNodesInALinkedList()
        {
            ListNode a4 = new(5);
            ListNode a3 = new(4, a4);
            ListNode a2 = new(3, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            Console.WriteLine(SwapNodes(a0, 2)?.val);
        }

        private static ListNode? SwapNodes(ListNode? head, int k)
        {
            List<int> x = [];

            while (head is not null)
            {
                x.Add(head.val);
                head = head.next;
            }

            (x[k - 1], x[^k]) = (x[^k], x[k - 1]);

            head = new();
            ListNode t = head;
            while (x.Count != 0)
            {
                t.next = new(x[0]);
                x.RemoveAt(0);
                t = t.next;
            }

            return head.next;
        }

        private static ListNode? SwapNodes0(ListNode? head, int k)
        {
            ListNode? n1 = head;
            ListNode? n2 = head;

            int c = 1;
            while (c != k)
            {
                if (n1 is null) return head;

                n1 = n1?.next;
                c++;
            }

            ListNode? temp = n1?.next;
            while (temp is not null)
            {
                temp = temp?.next;
                n2 = n2?.next;
            }

            if (n1 == n2) return head;

            n1!.val += n2!.val;
            n2.val = n1.val - n2.val;
            n1.val -= n2.val;

            return head;
        }

        private static ListNode? SwapNodes1(ListNode head, int k)
        {
            ListNode? node = head;
            ListNode? kthFromEnd = head;

            for (int i = 0; i < k - 1; i++)
            {
                node = node?.next;
            }

            ListNode? kthFromStart = node;
            while (node?.next is not null)
            {
                kthFromEnd = kthFromEnd?.next;
                node = node?.next;
            }

            (kthFromEnd!.val, kthFromStart!.val) = (kthFromStart.val, kthFromEnd.val);

            return head;
        }
    }
}
