using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00328_OddEvenLinkedList
    {
        /// <summary>
        /// Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, and return the reordered list.
        /// The first node is considered odd, and the second node is even, and so on.
        /// Note that the relative order inside both the even and odd groups should remain as it was in the input.
        /// You must solve the problem in O(1) extra space complexity and O(n) time complexity.
        /// </summary>
        public _00328_OddEvenLinkedList()
        {
            ListNode a4 = new(5, null);
            ListNode a3 = new(4, a4);
            ListNode a2 = new(3, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            Console.WriteLine(OddEvenList(a0)?.val);
        }

        private static ListNode? OddEvenList(ListNode head)
        {
            if (head is null) return null;

            ListNode? odd = head;
            ListNode? even = head.next;
            ListNode? evenHead = even;

            while (even is not null && even.next is not null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;

            return head;
        }
    }
}
