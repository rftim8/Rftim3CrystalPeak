using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01171_RemoveZeroSumConsecutiveNodesFromLinkedList
    {
        /// <summary>
        /// Given the head of a linked list, we repeatedly delete consecutive sequences of nodes that sum to 0 until there are no such sequences.
        /// 
        /// After doing so, return the head of the final linked list.You may return any such answer.
        /// 
        /// (Note that in the examples below, all sequences are serializations of ListNode objects.)
        /// </summary>
        public _01171_RemoveZeroSumConsecutiveNodesFromLinkedList()
        {
            ListNode? a0 = RftListNodesBuilder.RftCreateNodesFromArray([1, 2, -3, 3, 1]);
            ListNode? a1 = RemoveZeroSumConsecutiveNodesFromLinkedList0(a0!);
            while (a1 is not null)
            {
                Console.WriteLine(a1.val);
                a1 = a1.next;
            }

            ListNode? b0 = RftListNodesBuilder.RftCreateNodesFromArray([-1, 1, 0, 1]);
            ListNode? b1 = RemoveZeroSumConsecutiveNodesFromLinkedList0(b0!);
            while (b1 is not null)
            {
                Console.WriteLine(b1.val);
                b1 = b1.next;
            }

            ListNode? c0 = RftListNodesBuilder.RftCreateNodesFromArray([1, 2, 3, -3, 4]);
            ListNode? c1 = RemoveZeroSumConsecutiveNodesFromLinkedList0(c0!);
            while (c1 is not null)
            {
                Console.WriteLine(c1.val);
                c1 = c1.next;
            }

            ListNode? d0 = RftListNodesBuilder.RftCreateNodesFromArray([1, 2, 3, -3, -2]);
            ListNode? d1 = RemoveZeroSumConsecutiveNodesFromLinkedList0(d0!);
            while (d1 is not null)
            {
                Console.WriteLine(d1.val);
                d1 = d1.next;
            }
        }

        public static ListNode? RemoveZeroSumConsecutiveNodesFromLinkedList0(ListNode a0) => RftRemoveZeroSumConsecutiveNodesFromLinkedList0(a0);

        public static ListNode? RemoveZeroSumConsecutiveNodesFromLinkedList1(ListNode a0) => RftRemoveZeroSumConsecutiveNodesFromLinkedList1(a0);

        private static ListNode? RftRemoveZeroSumConsecutiveNodesFromLinkedList0(ListNode? head)
        {
            List<int> l = [];
            while (head is not null)
            {
                l.Add(head.val);
                head = head.next;
            }

            for (int i = 0; i < l.Count; i++)
            {
                int sum = l[i];
                if (sum == 0)
                {
                    l.RemoveAt(i);
                    i--;
                    continue;
                }
                for (int j = i + 1; j < l.Count; j++)
                {
                    sum += l[j];
                    if (sum == 0)
                    {
                        l.RemoveRange(i, j - i + 1);
                        i = -1;
                        break;
                    }
                }
            }
            if (l.Count == 0) return null;

            ListNode x = new(l[0]);
            ListNode y = x;
            for (int i = 1; i < l.Count; i++)
            {
                y.next = new(l[i]);
                y = y.next;
            }

            return x;
        }

        private static ListNode? RftRemoveZeroSumConsecutiveNodesFromLinkedList1(ListNode head)
        {
            Stack<int> stack = new();
            stack.Push(0);
            HashSet<int> set = [0];
            int sum = 0;
            ListNode? curr = head;

            while (curr != null)
            {
                sum += curr.val;
                if (set.Contains(sum))
                {
                    while (stack.Peek() != sum)
                    {
                        int item = stack.Pop();
                        set.Remove(item);
                    }
                }
                else
                {
                    stack.Push(sum);
                    set.Add(sum);
                }
                curr = curr.next;
            }
            ListNode? rs = null;

            while (stack.Count > 1)
            {
                rs = new ListNode(stack.Pop() - stack.Peek(), rs);
            }

            return rs;
        }
    }
}
