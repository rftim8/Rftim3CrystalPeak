using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00708_InsertIntoASortedCircularLinkedList
    {
        /// <summary>
        /// Given a Circular Linked List node, which is sorted in non-descending order, 
        /// write a function to insert a value insertVal into the list such that it remains a sorted circular list. 
        /// The given node can be a reference to any single node in the list and may not necessarily be the smallest value in the circular list.
        /// 
        /// If there are multiple suitable places for insertion, you may choose any place to insert the new value.
        /// After the insertion, the circular list should remain sorted.
        /// 
        /// If the list is empty (i.e., the given node is null), you should create a new single circular list and return the reference to that single node.
        /// Otherwise, you should return the originally given node.
        /// </summary>
        public _00708_InsertIntoASortedCircularLinkedList()
        {
            List<int?> resa = [];
            int[] a0 = [3, 4, 1];
            Node0? a1 = RftListNodesBuilder.RftCreateCircularArrayFromNodes(a0);
            Node0? ar = InsertIntoASortedCircularLinkedList0(a1, 2);
            if (a1 is not null) resa.Add(a1!.val);
            Node0? heada = a1 is not null ? a1!.next : new();
            while (heada != a1)
            {
                resa.Add(heada!.val);
                heada = heada.next;
            }
            RftTerminal.RftReadResult(resa);

            List<int?> resb = [];
            int[] b0 = [];
            Node0? b1 = RftListNodesBuilder.RftCreateCircularArrayFromNodes(b0);
            Node0? br = InsertIntoASortedCircularLinkedList0(b1, 1);
            if (b1 is not null) resb.Add(b1!.val);
            Node0? headb = b1 is not null ? b1!.next : new();
            while (headb != b1)
            {
                resb.Add(headb!.val);
                headb = headb.next;
            }
            RftTerminal.RftReadResult(resb);

            List<int?> resc = [];
            int[] c0 = [1];
            Node0? c1 = RftListNodesBuilder.RftCreateCircularArrayFromNodes(c0);
            Node0? cr = InsertIntoASortedCircularLinkedList0(c1, 0);
            if (c1 is not null) resc.Add(c1!.val);
            Node0? headc = c1 is not null ? c1!.next : new();
            while (headc != c1)
            {
                resc.Add(headc!.val);
                headc = headc.next;
            }
            RftTerminal.RftReadResult(resc);
        }

        public static Node0? InsertIntoASortedCircularLinkedList0(Node0? a0, int a1) => RftInsertIntoASortedCircularLinkedList0(a0, a1);

        public static Node0? InsertIntoASortedCircularLinkedList1(Node0? a0, int a1) => RftInsertIntoASortedCircularLinkedList1(a0, a1);

        // Two-Pointers iteration
        private static Node0? RftInsertIntoASortedCircularLinkedList0(Node0? head, int insertVal)
        {
            if (head == null)
            {
                Node0 newNode0 = new(insertVal, null);
                newNode0.next = newNode0;
                return newNode0;
            }

            Node0 prev = head;
            Node0? curr = head.next;
            bool toInsert = false;

            do
            {
                if (prev.val <= insertVal && insertVal <= curr!.val) toInsert = true;
                else if (prev.val > curr!.val)
                {
                    if (insertVal >= prev.val || insertVal <= curr.val) toInsert = true;
                }

                if (toInsert)
                {
                    prev.next = new Node0(insertVal, curr);
                    return head;
                }

                prev = curr;
                curr = curr.next;
            } while (prev != head);

            prev.next = new Node0(insertVal, curr);

            return head;
        }

        private static Node0? RftInsertIntoASortedCircularLinkedList1(Node0? head, int insertVal)
        {

            if (head == null)
            {
                Node0 Node0 = new(insertVal, null as Node0);
                Node0.next = Node0;
                return Node0;
            }

            Node0 prev = head;
            Node0? curr = head.next;
            bool insert = false;

            do
            {
                if (insertVal >= prev.val && insertVal <= curr!.val) insert = true;
                else if (prev.val > curr!.val)
                {
                    if (insertVal >= prev.val || insertVal <= curr.val) insert = true;
                }

                if (insert == true)
                {
                    prev.next = new Node0(insertVal, curr);
                    return head;
                }

                prev = curr;
                curr = curr.next;
            } while (prev != head);

            prev.next = new Node0(insertVal, curr);

            return head;
        }
    }
}
