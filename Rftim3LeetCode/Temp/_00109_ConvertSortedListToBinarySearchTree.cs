using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00109_ConvertSortedListToBinarySearchTree
    {
        /// <summary>
        /// Given the head of a singly linked list where elements are sorted in ascending order, convert it to a height-balanced binary search tree.
        /// </summary>
        public _00109_ConvertSortedListToBinarySearchTree()
        {
            ListNode a4 = new(9);
            ListNode a3 = new(5, a4);
            ListNode a2 = new(0, a3);
            ListNode a1 = new(-3, a2);
            ListNode a0 = new(-10, a1);

            Console.WriteLine(ConvertSortedListToBinarySearchTree0(a0)?.val);
        }

        public static TreeNode0? ConvertSortedListToBinarySearchTree0(ListNode? a0) => RftConvertSortedListToBinarySearchTree0(a0);

        private static TreeNode0? RftConvertSortedListToBinarySearchTree0(ListNode? head)
        {
            if (head is null) return null;

            ListNode? slow = head;
            ListNode? fast = head;
            ListNode? dummy = new() { next = head };

            while (fast is not null && fast?.next is not null)
            {
                dummy = dummy?.next;
                slow = slow?.next;
                fast = fast?.next?.next;
            }

            TreeNode0? treenode = new(slow!.val);
            dummy!.next = null;

            if (slow != head) treenode.left = RftConvertSortedListToBinarySearchTree0(head);
            treenode.right = RftConvertSortedListToBinarySearchTree0(slow?.next);

            return treenode;
        }
    }
}