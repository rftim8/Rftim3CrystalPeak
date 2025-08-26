using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01669_MergeInBetweenLinkedLists
    {
        /// <summary>
        /// You are given two linked lists: list1 and list2 of sizes n and m respectively.
        /// 
        /// Remove list1's nodes from the ath node to the bth node, and put list2 in their place.
        /// 
        /// The blue edges and nodes in the following figure indicate the result:
        /// 
        /// Build the result list and return its head.
        /// </summary>
        public _01669_MergeInBetweenLinkedLists()
        {
            ListNode? a0 = RftListNodesBuilder.RftCreateNodesFromArray([10, 1, 13, 6, 9, 5]);
            ListNode? a1 = RftListNodesBuilder.RftCreateNodesFromArray([1000000, 1000001, 1000002]);
            ListNode? a2 = MergeInBetweenLinkedLists0(a0, 3, 4, a1);

            while (a2 is not null)
            {
                Console.Write($"{a2.val} ");
                a2 = a2.next;
            }
            Console.WriteLine();

            ListNode? b0 = RftListNodesBuilder.RftCreateNodesFromArray([0, 1, 2, 3, 4, 5, 6]);
            ListNode? b1 = RftListNodesBuilder.RftCreateNodesFromArray([1000000, 1000001, 1000002, 1000003, 1000004]);
            ListNode? b2 = MergeInBetweenLinkedLists0(b0, 2, 5, b1);

            while (b2 is not null)
            {
                Console.Write($"{b2.val} ");
                b2 = b2.next;
            }
            Console.WriteLine();
        }

        public static ListNode MergeInBetweenLinkedLists0(ListNode? a0, int a1, int a2, ListNode? a3) => RftMergeInBetweenLinkedLists0(a0, a1, a2, a3);

        private static ListNode RftMergeInBetweenLinkedLists0(ListNode? list1, int a, int b, ListNode? list2)
        {
            Queue<ListNode> q = [];

            int i = 0;
            bool f = true;
            while (list1 is not null)
            {
                if (i < a || i > b) q.Enqueue(list1);
                else
                {
                    if (f)
                    {
                        while (list2 is not null)
                        {
                            q.Enqueue(list2);
                            list2 = list2.next;
                        }
                        f = false;
                    }
                }

                list1 = list1.next;
                i++;
            }

            ListNode t = q.Dequeue();
            ListNode? n = t;
            while (q.Count != 0)
            {
                n.next = q.Dequeue();
                n = n.next;
            }

            return t;
        }
    }
}
