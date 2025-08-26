using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00147_InsertionSortList
    {
        /// <summary>
        /// Given the head of a singly linked list, sort the list using insertion sort, and return the sorted list's head.
        /// The steps of the insertion sort algorithm:
        /// Insertion sort iterates, consuming one input element each repetition and growing a sorted output list.
        /// At each iteration, insertion sort removes one element from the input data, finds the location it belongs within the sorted list and inserts it there.
        /// It repeats until no input elements remain.
        /// The following is a graphical example of the insertion sort algorithm. 
        /// The partially sorted list (black) initially contains only the first element in the list. 
        /// One element (red) is removed from the input data and inserted in-place into the sorted list with each iteration.
        /// </summary>
        public _00147_InsertionSortList()
        {
            ListNode a3 = new(3);
            ListNode a2 = new(1, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(4, a1);

            Console.WriteLine(InsertionSortList0(a0)?.val);
            Console.WriteLine(InsertionSortList0(a1)?.val);
            Console.WriteLine(InsertionSortList0(a2)?.val);
            Console.WriteLine(InsertionSortList0(a3)?.val);
        }

        private static ListNode? InsertionSortList0(ListNode head)
        {
            if (head is null || head.next is null) return head;
            ListNode x = new();
            while (head is not null)
            {
                ListNode? next = head.next;
                ListNode crt = x;
                while (crt.next is not null && crt.next.val < head.val)
                {
                    crt = crt.next;
                }

                head.next = crt.next;
                crt.next = head;
                if (next is not null) head = next;
            }

            return x.next;
        }
    }
}
