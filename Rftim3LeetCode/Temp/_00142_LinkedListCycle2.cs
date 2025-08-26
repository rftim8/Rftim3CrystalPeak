using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00142_LinkedListCycle2
    {
        /// <summary>
        /// Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return null.
        /// There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer.
        /// Internally, pos is used to denote the index of the node that tail's next pointer is connected to (0-indexed). It is -1 if there is no cycle. 
        /// Note that pos is not passed as a parameter.
        /// Do not modify the linked list.
        /// </summary>
        public _00142_LinkedListCycle2()
        {
            ListNode? a3 = new(-4);
            ListNode? a2 = new(0, a3);
            ListNode? a1 = new(2, a2);
            ListNode? a0 = new(3, a1);

            Console.WriteLine(DetectCycle(a0)?.val);
        }

        private static ListNode? DetectCycle(ListNode head)
        {
            List<ListNode> visited = new();
            ListNode? r = head;

            while (r is not null)
            {
                if (visited.Contains(r)) return r;
                else visited.Add(r);

                r = r.next;
            }

            return null;
        }
    }
}
