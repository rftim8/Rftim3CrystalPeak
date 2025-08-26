using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00148_SortList
    {
        /// <summary>
        /// Given the head of a linked list, return the list after sorting it in ascending order.
        /// </summary>
        public _00148_SortList()
        {
            ListNode a3 = new(3, null);
            ListNode a2 = new(1, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(4, a1);

            Console.WriteLine(SortList(a0).val);
        }

        private static ListNode SortList(ListNode head)
        {
            ListNode? x = head;
            List<int> y = new();

            int i = 0;

            while (x is not null)
            {
                y.Add(x.val);
                x = x.next;
            };

            y.Sort((a, b) => a.CompareTo(b));
            x = head;

            while (x is not null)
            {
                x.val = y[i++];
                x = x.next;
            };

            return head;
        }
    }
}
