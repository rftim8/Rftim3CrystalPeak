using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00092_ReverseLinkedList2
    {
        /// <summary>
        /// Given the head of a singly linked list and two integers left and right where left <= right, 
        /// reverse the nodes of the list from position left to position right, and return the reversed list.
        /// </summary>
        public _00092_ReverseLinkedList2()
        {
            ListNode a4 = new(5);
            ListNode a3 = new(4, a4);
            ListNode a2 = new(3, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            Console.WriteLine(ReverseBetween(a0, 2, 4)?.val);
        }

        private static ListNode? ReverseBetween(ListNode head, int left, int right)
        {
            if (right == 1 && left == right) return head;

            ListNode? h = head;
            int c = 1;
            while (c < left - 1)
            {
                h = h?.next;
                c++;
            }

            ListNode? crt = h?.next;
            ListNode? prev = h;
            while (c++ < right)
            {
                ListNode? t = crt?.next;
                crt!.next = prev;
                prev = crt;
                crt = t;
            }

            if (left == 1)
            {
                h!.next = crt;
                return prev;
            }
            else
            {
                h!.next!.next = crt;
                h.next = prev;
            }

            return head;
        }

        private static ListNode? ReverseBetween0(ListNode head, int left, int right)
        {

            if (head is null || left == right) return head;

            ListNode? dummy = new(0)
            {
                next = head
            };
            ListNode? prev = dummy;

            for (int i = 1; i < left; i++)
            {
                prev = prev?.next;
            }

            ListNode? curr = prev?.next;
            ListNode? next;

            for (int i = 0; i < right - left; i++)
            {
                next = curr?.next;
                curr!.next = next?.next;
                next!.next = prev?.next;
                prev!.next = next;
            }

            return dummy.next;
        }
    }
}
