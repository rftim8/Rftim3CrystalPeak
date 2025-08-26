using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00725_SplitLinkedListInParts
    {
        /// <summary>
        /// Given the head of a singly linked list and an integer k, split the linked list into k consecutive linked list parts.
        /// The length of each part should be as equal as possible: no two parts should have a size differing by more than one.
        /// This may lead to some parts being null.
        /// The parts should be in the order of occurrence in the input list, and parts occurring earlier should always have a size greater than or equal to parts occurring later.
        /// Return an array of the k parts.
        /// </summary>
        public _00725_SplitLinkedListInParts()
        {
            ListNode a2 = new(3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            ListNode?[] x = SplitListToParts(a0, 5);

            foreach (ListNode? item in x)
            {
                Console.Write($"{item?.val} ");
            }
            Console.WriteLine();
        }

        private static ListNode?[] SplitListToParts(ListNode head, int k)
        {
            ListNode? h = head;
            int n = 0;

            while (h is not null)
            {
                h = h.next;
                n++;
            }

            int width = n / k, rem = n % k;

            ListNode?[] ans = new ListNode[k];
            h = head;
            for (int i = 0; i < k; ++i)
            {
                ListNode t = new(0), write = t;
                for (int j = 0; j < width + (i < rem ? 1 : 0); ++j)
                {
                    write = write.next = new ListNode(h!.val);
                    if (h is not null) h = h.next;
                }
                ans[i] = t.next;
            }

            return ans;
        }
    }
}
