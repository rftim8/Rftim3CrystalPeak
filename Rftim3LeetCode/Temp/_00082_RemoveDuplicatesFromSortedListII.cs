using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00082_RemoveDuplicatesFromSortedListII
    {
        /// <summary>
        /// Given the head of a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. 
        /// Return the linked list sorted as well.
        /// </summary>
        public _00082_RemoveDuplicatesFromSortedListII()
        {
            ListNode a6 = new(5, null);
            ListNode a5 = new(4, a6);
            ListNode a4 = new(4, a5);
            ListNode a3 = new(3, a4);
            ListNode a2 = new(3, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            Console.WriteLine(RemoveDuplicatesFromSortedListII0(a0)?.val);
        }

        public static ListNode? RemoveDuplicatesFromSortedListII0(ListNode? a0) => RftRemoveDuplicatesFromSortedListII0(a0);

        private static ListNode? RftRemoveDuplicatesFromSortedListII0(ListNode? head)
        {
            ListNode x = new(0, head);
            ListNode? y = x;

            while (head is not null)
            {
                if (head.next is not null && head.val == head.next.val)
                {
                    while (head.next is not null && head.val == head.next.val)
                    {
                        head = head.next;
                    }
                    y!.next = head.next;
                }
                else y = y!.next;

                head = head.next;
            }

            return x.next;
        }
    }
}
