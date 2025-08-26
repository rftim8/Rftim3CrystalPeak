using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00143_ReorderList
    {
        /// <summary>
        /// You are given the head of a singly linked-list. The list can be represented as:
        /// L0 → L1 → … → Ln - 1 → Ln
        /// Reorder the list to be on the following form:
        /// L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
        /// You may not modify the values in the list's nodes. Only nodes themselves may be changed.
        /// </summary>
        public _00143_ReorderList()
        {
            ListNode? a4 = new(4, null);
            ListNode? a3 = new(4, a4);
            ListNode? a2 = new(3, a3);
            ListNode? a1 = new(2, a2);
            ListNode? a0 = new(1, a1);

            ReorderList(a0);
        }

        private static void ReorderList(ListNode head)
        {
            List<ListNode> arr = new();
            ListNode? index = head;

            while (index is not null)
            {
                arr.Add(index);
                index = index.next;
            }

            for (int l = 0; l < arr.Count; l++)
            {
                int r = arr.Count - 1 - l;
                if (l >= r)
                {
                    arr[l].next = null;
                    break;
                }
                arr[l].next = arr[r];
                arr[r].next = arr[l + 1];
            }
        }

        private static void ReorderList0(ListNode? head)
        {
            if (head is null || head.next is null) return;

            ListNode? slow = head;
            ListNode? fast = head;
            while (fast.next is not null && fast.next.next is not null)
            {
                slow = slow?.next;
                fast = fast.next.next;
            }

            ListNode? prev = null;
            ListNode? curr = slow?.next;
            slow!.next = null;
            while (curr is not null)
            {
                ListNode? nextNode = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextNode;
            }

            ListNode? first = head;
            ListNode? second = prev;
            while (first is not null && second is not null)
            {
                ListNode? nextNode1 = first.next;
                ListNode? nextNode2 = second.next;
                first.next = second;
                second.next = nextNode1;
                first = nextNode1;
                second = nextNode2;
            }
        }
    }
}
