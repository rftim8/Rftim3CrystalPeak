using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00061_RotateList
    {
        /// <summary>
        /// Given the head of a linked list, rotate the list to the right by k places.
        /// </summary>
        public _00061_RotateList()
        {
            ListNode a4 = new(5);
            ListNode a3 = new(4, a4);
            ListNode a2 = new(3, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            RotateRight(a0, 4);
        }

        public static ListNode? RotateRight(ListNode head, int k)
        {
            if (head is null || head.next is null) return head;

            ListNode? l0 = head, l1 = head, l2 = null;

            int i = 1;
            while (l0.next is not null)
            {
                l0 = l0.next;
                i++;

                Console.Write($"{l0.val} ");
            }
            Console.WriteLine();

            if (k > i) k %= i;
            if (k == i || k == 0) return head;

            i -= k;

            while (i > 0)
            {
                l2 = l1;
                l1 = l1?.next;
                Console.Write($"{l2?.val}: {l1.val}; ");

                i--;
            }
            Console.WriteLine();

            l2!.next = null;
            l0.next = head;

            return l1;
        }
    }
}
