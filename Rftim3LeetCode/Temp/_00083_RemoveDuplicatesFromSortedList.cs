using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00083_RemoveDuplicatesFromSortedList
    {
        /// <summary>
        /// Given the head of a sorted linked list, delete all duplicates such that each element appears only once. 
        /// Return the linked list sorted as well.
        /// </summary>
        public _00083_RemoveDuplicatesFromSortedList()
        {
            int[] a0 = [1, 1, 2];
            ListNode? x0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);

            while (x0 is not null)
            {
                Console.WriteLine(x0.val);
                x0 = x0.next;
            }
        }

        public static ListNode? DeleteDuplicates0(ListNode? a0) => RftDeleteDuplicates0(a0);

        private static ListNode? RftDeleteDuplicates0(ListNode? head)
        {
            if (head is null || head.next is null) return head;

            ListNode? x = head;
            ListNode? y = head.next;

            while (y is not null)
            {
                if (x.val == y.val)
                {
                    x.next = y.next;
                    y.next = null;
                    y = x.next;
                }
                else
                {
                    x = y;
                    y = y.next;
                }
            }

            return head;
        }
    }
}
