using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00237_DeleteNodeInALinkedList
    {
        /// <summary>
        /// There is a singly-linked list head and we want to delete a node node in it.
        /// 
        /// You are given the node to be deleted node.You will not be given access to the first node of head.
        /// 
        /// All the values of the linked list are unique, and it is guaranteed that the given node node is not the last node in the linked list.
        /// 
        /// Delete the given node. Note that by deleting the node, we do not mean removing it from memory. We mean:
        /// 
        /// The value of the given node should not exist in the linked list.
        /// The number of nodes in the linked list should decrease by one.
        /// All the values before node should be in the same order.
        /// All the values after node should be in the same order.
        /// Custom testing:
        /// 
        /// For the input, you should provide the entire linked list head and the node to be given node.
        /// node should not be the last node of the list and should be an actual node in the list.
        /// We will build the linked list and pass the node to your function.
        /// The output will be the entire list after calling your function.
        /// </summary>
        public _00237_DeleteNodeInALinkedList()
        {
            ListNode a3 = new(9);
            ListNode a2 = new(1, a3);
            ListNode a1 = new(5, a2);
            _ = new ListNode(4, a1);

            Console.WriteLine(DeleteNode0(a1));
        }

        public static int DeleteNode0(ListNode a0) => RftDeleteNode0(a0);

        private static int RftDeleteNode0(ListNode node)
        {
            int res = node.val;

            ListNode c = node.next!;
            node.val = c.val;
            node.next = c.next;
            c.next = null;

            return res;
        }
    }
}
