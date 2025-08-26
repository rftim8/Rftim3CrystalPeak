using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00876_MiddleOfTheLinkedList
    {
        /// <summary>
        /// Given the head of a singly linked list, return the middle node of the linked list.
        /// 
        /// If there are two middle nodes, return the second middle node.
        /// </summary>
        public _00876_MiddleOfTheLinkedList()
        {
            for (int i = 0; i < 6; i++)
            {
                LinkedList<ListNode> x = new();
                ListNode? a5 = new(6);
                ListNode? a4 = new(5, a5);
                ListNode? a3 = new(4, a4);
                ListNode? a2 = new(3, a3);
                ListNode? a1 = new(2, a2);
                ListNode? a0 = new(1, a1);

                x.AddFirst(a5);
                x.AddFirst(a4);
                x.AddFirst(a3);
                x.AddFirst(a2);
                x.AddFirst(a1);
                x.AddFirst(a0);

                Console.WriteLine(MiddleNode(x.ElementAt(i))?.val);
            }
        }

        private static ListNode? MiddleNode(ListNode head)
        {
            ListNode? r = head.next;

            while (r is not null)
            {
                if (head.next is not null)
                {
                    head = head.next;
                    Console.WriteLine($"{head.val}: {r.val}");
                }

                if (r.next is not null) r = r.next.next;
                else r = null;
            }

            return head;
        }
    }
}
