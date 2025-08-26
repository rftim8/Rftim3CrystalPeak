using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00021_MergeTwoSortedLists
    {
        /// <summary>
        /// You are given the heads of two sorted linked lists list1 and list2.
        /// Merge the two lists in a one sorted list.
        /// The list should be made by splicing together the nodes of the first two lists.
        /// Return the head of the merged linked list.
        /// </summary>
        public _00021_MergeTwoSortedLists()
        {

        }

        public static ListNode? MergeTwoLists0(ListNode? a0, ListNode? a1) => MergeTwoLists0(a0, a1);

        public static ListNode? RftMergeTwoLists0(ListNode? list1, ListNode? list2)
        {
            if (list1 is null) return list2;
            else if (list2 is null) return list1;

            ListNode d = new();
            ListNode c = d;

            while (list1 is not null && list2 is not null)
            {
                if (list1.val < list2.val)
                {
                    c.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    c.next = list2;
                    list2 = list2.next;
                }

                c = c.next;
            }

            if (list1 is not null) c.next = list1;
            if (list2 is not null) c.next = list2;

            return d.next;
        }
    }
}
