using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _02130_MaximumTwinSumOfALinkedList
    {
        /// <summary>
        /// In a linked list of size n, where n is even, the ith node (0-indexed) of the linked list is known as the twin of the (n-1-i)th node, if 0 <= i <= (n / 2) - 1.
        /// For example, if n = 4, then node 0 is the twin of node 3, and node 1 is the twin of node 2. These are the only nodes with twins for n = 4.
        /// The twin sum is defined as the sum of a node and its twin.
        /// Given the head of a linked list with even length, return the maximum twin sum of the linked list.
        /// </summary>
        public _02130_MaximumTwinSumOfALinkedList()
        {
            ListNode a3 = new(1);
            ListNode a2 = new(2, a3);
            ListNode a1 = new(4, a2);
            ListNode a0 = new(5, a1);

            Console.WriteLine(PairSum(a0));
        }

        private static int PairSum(ListNode head)
        {
            ListNode? x = head;
            List<int> y = [];

            while (x is not null)
            {
                y.Add(x.val);
                x = x.next;
            }

            int i = 0, j = y.Count - 1;
            int max = 0;
            while (i < j)
            {
                max = Math.Max(max, y[i] + y[j]);
                i++;
                j--;
            }

            return max;
        }

        private static int PairSum0(ListNode head)
        {
            ListNode? current = head;
            Stack<int> st = new();

            while (current is not null)
            {
                st.Push(current.val);
                current = current.next;
            }

            current = head;
            int size = st.Count, count = 1;
            int maximumSum = 0;
            while (count <= size / 2)
            {
                maximumSum = Math.Max(maximumSum, current!.val + st.Peek());
                current = current.next;
                st.Pop();
                count++;
            }

            return maximumSum;
        }

        private static int PairSum1(ListNode head)
        {
            ListNode? slow = head;
            ListNode? fast = head;

            while (fast is not null && fast.next is not null)
            {
                fast = fast.next.next;
                slow = slow?.next;
            }

            ListNode? nextNode, prev = null;
            while (slow is not null)
            {
                nextNode = slow.next;
                slow.next = prev;
                prev = slow;
                slow = nextNode;
            }

            ListNode? start = head;
            int maximumSum = 0;
            while (prev is not null)
            {
                maximumSum = Math.Max(maximumSum, start!.val + prev.val);
                prev = prev.next;
                start = start.next;
            }

            return maximumSum;
        }
    }
}
