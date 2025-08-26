using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00382_LinkedListRandomNode
    {
        private ListNode? head;
        private Random? random;

        /// <summary>
        /// Given a singly linked list, return a random node's value from the linked list. 
        /// Each node must have the same probability of being chosen.
        /// Implement the Solution class:
        /// Solution(ListNode head) Initializes the object with the head of the singly-linked list head.
        /// int getRandom() Chooses a node randomly from the list and returns its value.All the nodes of the list should be equally likely to be chosen.
        /// </summary>
        public _00382_LinkedListRandomNode()
        {
            ListNode a2 = new(3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(1, a1);

            Solve(a0);
        }

        private void Solve(ListNode listNode)
        {
            random = new();
            head = listNode;
            int x = GetRandom();
            Console.WriteLine(x);
        }

        private int GetRandom()
        {
            int scope = 1, chosenValue = 0;
            ListNode? curr = head;

            while (curr != null)
            {
                if (random?.Next(0, scope) == 0) chosenValue = curr.val;

                scope += 1;
                curr = curr.next;
            }

            return chosenValue;
        }
    }
}
