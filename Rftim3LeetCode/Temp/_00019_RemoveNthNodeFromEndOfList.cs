using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00019_RemoveNthNodeFromEndOfList
    {
        /// <summary>
        /// Given the head of a linked list, remove the nth node from the end of the list and return its head.
        /// </summary>
        public _00019_RemoveNthNodeFromEndOfList()
        {
            int n = 2;

            for (int i = 0; i < 5; i++)
            {
                LinkedList<ListNode> x = new();
                ListNode? a4 = new(5);
                ListNode? a3 = new(4, a4);
                ListNode? a2 = new(3, a3);
                ListNode? a1 = new(2, a2);
                ListNode? a0 = new(1, a1);

                x.AddFirst(a4);
                x.AddFirst(a3);
                x.AddFirst(a2);
                x.AddFirst(a1);
                x.AddFirst(a0);

                RemoveNthNodeFromEndOfList0(x.ElementAt(i), n);
            }
        }

        public static ListNode? RemoveNthNodeFromEndOfList0(ListNode? a0, int a1) => RftRemoveNthNodeFromEndOfList0(a0, a1);

        private static ListNode? RftRemoveNthNodeFromEndOfList0(ListNode? head, int n)
        {
            ListNode? r = new();
            ListNode? r1 = r;
            ListNode? r2 = r;

            if (head is not null) r.next = head;

            int i = 0;
            while (i < n)
            {
                if (r2.next is not null) r2 = r2.next;
                i++;
            }

            while (r2.next != null)
            {
                if (r1.next is not null) r1 = r1.next;
                if (r2.next is not null) r2 = r2.next;
            }

            if (r1.next is not null) r1.next = r1.next.next;

            return r.next;
        }
    }
}
