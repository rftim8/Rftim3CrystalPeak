using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00002_AddTwoNumbers
    {
        /// <summary>
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The digits are stored in reverse order, and each of their nodes contains a single digit. 
        /// Add the two numbers and return the sum as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        public _00002_AddTwoNumbers()
        {
            ListNode a2 = new(3);
            ListNode a1 = new(4, a2);
            ListNode a0 = new(2, a1);

            ListNode b2 = new(4);
            ListNode b1 = new(6, b2);
            ListNode b0 = new(5, b1);

            int[] x0 = [2, 4, 3];
            int[] x1 = [5, 6, 4];

            Console.WriteLine(AddTwoNumbers0(a0, b0)?.val);
        }

        public static ListNode? AddTwoNumbers0(ListNode? a0, ListNode? a1) => RftAddTwoNumbers0(a0, a1);

        private static ListNode? RftAddTwoNumbers0(ListNode? l1, ListNode? l2)
        {
            ListNode l0 = new(0);
            ListNode l = l0;
            int c = 0;

            while (l1 is not null || l2 is not null || c != 0)
            {
                int x = l1 is not null ? l1.val : 0;
                int y = l2 is not null ? l2.val : 0;
                int sum = c + x + y;
                c = sum / 10;

                l.next = new ListNode(sum % 10);
                l = l.next;

                if (l1 is not null) l1 = l1.next;
                if (l2 is not null) l2 = l2.next;
            }

            return l0.next;
        }
    }
}
