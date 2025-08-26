using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00206_ReverseLinkedList
    {
        /// <summary>
        /// Given the head of a singly linked list, reverse the list, and return the reversed list.
        /// </summary>
        public _00206_ReverseLinkedList()
        {
            int[] a0 = [1, 2, 3, 4, 5];
            ListNode? x = RftListNodesBuilder.RftCreateNodesFromArray(a0);
            Console.WriteLine(ReverseList0(x!)!.val);
        }

        public static ListNode? ReverseList0(ListNode a0) => RftReverseList0(a0);

        private static ListNode? RftReverseList0(ListNode head)
        {
            if (head is null || head.next is null) return head;

            ListNode x = head;
            ListNode? y = x.next;
            ListNode? z = y.next;

            x.next = null;

            while (y is not null)
            {
                y.next = x;
                x = y;
                y = z;

                if (y != null) z = y.next;
            }

            return x;
        }
    }
}
