using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00234_PalindromeLinkedList
    {
        /// <summary>
        /// Given the head of a singly linked list, return true if it is a palindrome or false otherwise.
        /// </summary>
        public _00234_PalindromeLinkedList()
        {
            int[] a0 = [1, 2, 2, 1];
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);

            Console.WriteLine(IsPalindrome0(l0));
        }

        public static bool IsPalindrome0(ListNode? a0) => RftIsPalindrome0(a0);

        private static bool RftIsPalindrome0(ListNode? head)
        {
            List<int> x = [];
            ListNode? y = head;

            while (y is not null)
            {
                x.Add(y.val);
                y = y.next;
            }

            int l = 0;
            int r = x.Count - 1;
            while (l < r)
            {
                if (!x[l].Equals(x[r])) return false;

                l++;
                r--;
            }

            return true;
        }
    }
}
