using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00203_RemoveLinkedListElements
    {
        /// <summary>
        /// Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.
        /// </summary>
        public _00203_RemoveLinkedListElements()
        {
            int[] a0 = [1, 2, 6, 3, 4, 5, 6];
            int a1 = 6;
            ListNode? x = RftListNodesBuilder.RftCreateNodesFromArray(a0);
            Console.WriteLine(RemoveElements0(x!, a1));
        }

        public static ListNode? RemoveElements0(ListNode a0, int a1) => RftRemoveElements0(a0, a1);

        private static ListNode? RftRemoveElements0(ListNode head, int val)
        {
            if (head is null) return head;

            ListNode x = new() { next = head };
            ListNode? y = x;

            while (y is not null)
            {
                if (y.next is not null && y.next.val == val)
                {
                    if (y.next.next is not null) y.next = y.next.next;
                    else y.next = null;
                }
                else y = y.next;
            }

            return x.next;
        }
    }
}
