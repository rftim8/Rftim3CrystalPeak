using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00024_SwapNodesInPairs
    {
        /// <summary>
        /// Given a linked list, swap every two adjacent nodes and return its head. 
        /// You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)
        /// </summary>
        public _00024_SwapNodesInPairs()
        {
            ListNode a3 = new(4);
            ListNode a2 = new(3, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            SwapNodesInPairs0(a0);
        }

        public static ListNode? SwapNodesInPairs0(ListNode? a0) => RftSwapNodesInPairs0(a0);

        private static ListNode? RftSwapNodesInPairs0(ListNode? head)
        {
            if (head is null) return null;

            ListNode? x = head;
            ListNode? y = x;
            ListNode? z = x.next;

            while (z is not null)
            {
                (z.val, y.val) = (y.val, z.val);
                if (z.next is null || y.next?.next is null) break;

                y = y.next.next;
                z = z.next.next;
            }

            return x;
        }
    }
}
