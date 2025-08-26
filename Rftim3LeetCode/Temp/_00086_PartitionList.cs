using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00086_PartitionList
    {
        /// <summary>
        /// Given the head of a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.
        /// You should preserve the original relative order of the nodes in each of the two partitions.
        /// </summary>
        public _00086_PartitionList()
        {
            ListNode a5 = new(2);
            ListNode a4 = new(5, a5);
            ListNode a3 = new(2, a4);
            ListNode a2 = new(3, a3);
            ListNode a1 = new(4, a2);
            ListNode a0 = new(1, a1);


            ListNode b1 = new(1);
            ListNode b0 = new(2, b1);

            Partition(a0, 3);
            Partition(b0, 2);
        }

        private static ListNode? Partition(ListNode? head, int x)
        {
            if (head is null) return head;

            ListNode l0 = new();
            ListNode l1 = new();

            ListNode crt0 = l0;
            ListNode crt1 = l1;

            while (head is not null)
            {
                if (head.val < x)
                {
                    crt0.next = head;
                    crt0 = crt0.next;
                }
                else
                {
                    crt1.next = head;
                    crt1 = crt1.next;
                }

                head = head.next;
                crt0.next = null;
                crt1.next = null;
            }

            if (l0.next is null) l0 = l1;
            else if (l1.next is not null) crt0.next = l1.next;

            return l0.next;
        }
    }
}
