using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00160_IntersectionOfTwoLinkedLists
    {
        /// <summary>
        /// Given the heads of two singly linked-lists headA and headB, return the node at which the two lists intersect.
        /// If the two linked lists have no intersection at all, return null.
        /// The test cases are generated such that there are no cycles anywhere in the entire linked structure.
        /// Note that the linked lists must retain their original structure after the function returns.
        /// Custom Judge:
        /// The inputs to the judge are given as follows (your program is not given these inputs):
        /// intersectVal - The value of the node where the intersection occurs.This is 0 if there is no intersected node.
        ///         listA - The first linked list.
        ///         listB - The second linked list.
        /// skipA - The number of nodes to skip ahead in listA (starting from the head) to get to the intersected node.
        ///         skipB - The number of nodes to skip ahead in listB (starting from the head) to get to the intersected node.
        /// The judge will then create the linked structure based on these inputs and pass the two heads, headA and headB to your program.
        /// If you correctly return the intersected node, then your solution will be accepted.
        /// </summary>
        public _00160_IntersectionOfTwoLinkedLists()
        {

        }

        public static ListNode? IntersectionOfTwoLinkedLists0(ListNode? a0, ListNode? a1) => RftIntersectionOfTwoLinkedLists0(a0, a1);

        private static ListNode? RftIntersectionOfTwoLinkedLists0(ListNode? headA, ListNode? headB)
        {
            ListNode? a = headA;
            ListNode? b = headB;

            while (a?.val != b?.val)
            {
                a = a is null ? headB : a.next;
                b = b is null ? headA : b.next;
            }

            return a;
        }
    }
}