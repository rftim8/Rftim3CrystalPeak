using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00141_LinkedListCycle
    {
        /// <summary>
        /// Given head, the head of a linked list, determine if the linked list has a cycle in it.
        /// There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer.
        /// Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.
        /// Return true if there is a cycle in the linked list.Otherwise, return false.
        /// </summary>
        public _00141_LinkedListCycle()
        {
            int[] a0 = [3, 2, 0, -4];
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);
            Console.WriteLine(HasCycle0(l0));
        }

        public static bool HasCycle0(ListNode? a0) => RftHasCycle0(a0);

        private static bool RftHasCycle0(ListNode? head)
        {
            if (head is null) return false;

            ListNode? x = head;
            ListNode? y = x.next;

            while (x is not null && y is not null)
            {
                if (x == y) return true;

                x = x.next;
                y = y.next?.next;
            }

            return false;
        }
    }
}
