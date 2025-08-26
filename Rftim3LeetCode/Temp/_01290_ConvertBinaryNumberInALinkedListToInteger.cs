using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _01290_ConvertBinaryNumberInALinkedListToInteger
    {
        /// <summary>
        /// Given head which is a reference node to a singly-linked list. 
        /// The value of each node in the linked list is either 0 or 1. 
        /// The linked list holds the binary representation of a number.
        /// Return the decimal value of the number in the linked list.
        /// The most significant bit is at the head of the linked list.
        /// </summary>
        public _01290_ConvertBinaryNumberInALinkedListToInteger()
        {
            ListNode a2 = new(1, null);
            ListNode a1 = new(0, a2);
            ListNode a0 = new(1, a1);

            Console.WriteLine(ConvertBinaryNumberInALinkedListToInteger0(a0));
        }

        public static int ConvertBinaryNumberInALinkedListToInteger0(ListNode a0) => RftConvertBinaryNumberInALinkedListToInteger0(a0);

        private static int RftConvertBinaryNumberInALinkedListToInteger0(ListNode head)
        {
            int x = head.val;

            while (head.next is not null)
            {
                x = x * 2 + head.next.val;
                head = head.next;
            }

            return x;
        }
    }
}