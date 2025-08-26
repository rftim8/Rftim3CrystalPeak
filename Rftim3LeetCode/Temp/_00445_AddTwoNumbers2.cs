using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00445_AddTwoNumbers2
    {
        /// <summary>
        /// You are given two non-empty linked lists representing two non-negative integers. 
        /// The most significant digit comes first and each of their nodes contains a single digit. 
        /// Add the two numbers and return the sum as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        public _00445_AddTwoNumbers2()
        {
            ListNode a3 = new(3);
            ListNode a2 = new(4, a3);
            ListNode a1 = new(2, a2);
            ListNode a0 = new(7, a1);

            ListNode b2 = new(4);
            ListNode b1 = new(6, b2);
            ListNode b0 = new(5, b1);

            Console.WriteLine(AddTwoNumbers(a0, b0)?.val);
        }

        private static ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            Stack<int> s1 = new();
            Stack<int> s2 = new();

            while (l1 is not null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            };

            while (l2 is not null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }

            int totalSum = 0, carry = 0;
            ListNode ans = new();
            while (s1.Count != 0 || s2.Count != 0)
            {
                if (s1.Count != 0) totalSum += s1.Pop();
                if (s2.Count != 0) totalSum += s2.Pop();

                ans.val = totalSum % 10;
                carry = totalSum / 10;
                ListNode head = new(carry)
                {
                    next = ans
                };
                ans = head;
                totalSum = carry;
            }

            return carry == 0 ? ans.next : ans;
        }

        // Reverse
        private static ListNode? ReverseList(ListNode? head)
        {
            ListNode? prev = null, temp;
            while (head is not null)
            {
                temp = head.next;
                head.next = prev;
                prev = head;
                head = temp;
            }

            return prev;
        }

        private static ListNode? AddTwoNumbers0(ListNode? l1, ListNode? l2)
        {
            ListNode? r1 = ReverseList(l1);
            ListNode? r2 = ReverseList(l2);

            int totalSum = 0, carry = 0;
            ListNode ans = new();
            while (r1 is not null || r2 is not null)
            {
                if (r1 is not null) totalSum += r1.val;
                if (r2 is not null) totalSum += r2.val;

                ans.val = totalSum % 10;
                carry = totalSum / 10;
                ListNode head = new(carry)
                {
                    next = ans
                };
                ans = head;
                totalSum = carry;

                r1 = r1?.next;
                r2 = r2?.next;
            }

            return carry == 0 ? ans.next : ans;
        }
    }
}
