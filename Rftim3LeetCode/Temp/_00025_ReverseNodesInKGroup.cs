using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00025_ReverseNodesInKGroup
    {
        /// <summary>
        /// Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.
        /// k is a positive integer and is less than or equal to the length of the linked list.If the number of nodes is not a 
        /// multiple of k then left-out nodes, in the end, should remain as it is.
        /// You may not alter the values in the list's nodes, only nodes themselves may be changed.
        /// </summary>
        public _00025_ReverseNodesInKGroup()
        {
            ListNode a4 = new(5);
            ListNode a3 = new(4, a4);
            ListNode a2 = new(3, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            Console.WriteLine(ReverseKGroup0(a0, 2)?.val);
        }

        public static ListNode? ReverseKGroup0(ListNode? a0, int a1) => RftReverseKGroup0(a0, a1);

        public static ListNode? ReverseKGroup1(ListNode? a0, int a1) => RftReverseKGroup1(a0, a1);

        private static ListNode? RftReverseKGroup0(ListNode? head, int k)
        {
            ListNode? x = head;
            ListNode? y = head;
            ListNode? z = y?.next;
            int count = 1;

            while (true)
            {
                if (count == k)
                {
                    x = head;
                    count = 1;
                    break;
                }
                else if (x?.next is null && count < k) return head;
                else
                {
                    x = x?.next;
                    count++;
                }
            }

            y.next = null;

            while (z is not null && count < k)
            {
                ListNode? t = z.next;

                z.next = y;
                y = z;
                z = t;

                count++;
            }

            if (z is not null) x!.next = RftReverseKGroup0(z, k);

            return y;
        }

        private static ListNode? RftReverseKGroup1(ListNode? head, int k)
        {
            if (head is null) return null;
            ListNode[] node = new ListNode[k + 2];
            node[0] = head;

            for (int i = 1; i < k; i++)
            {
                if (node[i - 1] is null) return head;
                node[i] = node[i - 1].next!;
            }

            if (node[k - 1] is null) return head;

            node[k] = node[k - 1].next!;
            for (int i = 1; i < k; i++)
            {
                node[k - i].next = node[k - i - 1];
            }

            node[k + 1] = RftReverseKGroup1(node[k], k)!;
            if (node[k + 1] is null)
            {
                node[0].next = null;
                return node[k - 1];
            }
            node[0].next = node[k + 1];

            return node[k - 1];
        }
    }
}
