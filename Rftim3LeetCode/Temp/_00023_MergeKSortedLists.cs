using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00023_MergeKSortedLists
    {
        /// <summary>
        /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
        /// Merge all the linked-lists into one sorted linked-list and return it.
        /// </summary>
        public _00023_MergeKSortedLists()
        {
            ListNode a2 = new(5);
            ListNode a1 = new(4, a2);
            ListNode a0 = new(1, a1);

            ListNode b2 = new(4);
            ListNode b1 = new(3, b2);
            ListNode b0 = new(1, b1);

            ListNode c1 = new(6);
            ListNode c0 = new(2, c1);

            ListNode[] x = [a0, b0, c0];

            Console.WriteLine(MergeKSortedLists0(x)?.val);
        }

        public static ListNode? MergeKSortedLists0(ListNode[] a0) => RftMergeKSortedLists0(a0);

        private static ListNode? RftMergeKSortedLists0(ListNode[] lists)
        {
            if (lists is null) return null;

            int n = lists.Length;
            ListNode x = new();
            ListNode z = x;

            List<int> y = [];

            for (int i = 0; i < n; i++)
            {
                while (lists[i] is not null)
                {
                    y.Add(lists[i].val);
                    lists[i] = lists[i].next!;
                }
            }

            y.Sort();

            foreach (int item in y)
            {
                z.next = new(item);
                z = z.next;
            }

            return x.next;
        }
    }
}
