using Rftim3Atlas.Models;

namespace Rftim3Convoy.Temp.Construct.ListNodes
{
    public class RftListNodesBuilder
    {
        public static ListNode? RftCreateNodesFromArray(int[] a)
        {
            if (a.Length == 0) return null;

            ListNode head = new(a[0]);
            ListNode x = head;
            for (int i = 1; i < a.Length; i++)
            {
                ListNode y = new(a[i]);
                x.next = y;
                x = x.next!;
            }

            return head;
        }

        public static ListNode[]? RftCreateListOfNodes(int[] a)
        {
            if (a.Length == 0) return null;

            ListNode[] r = new ListNode[a.Length];

            ListNode? ln = new();
            for (int i = 0; i < a.Length; i++)
            {
                ln!.val = a[i];
                if (i < a.Length - 1)
                {
                    ln.next = new(a[i + 1]);
                    r[i] = ln;
                }
                else r[i] = ln;
                ln = ln.next;
            }

            return r;
        }

        public static Node? RftCreateArrayFromNodes(int[] a)
        {
            if (a.Length == 0) return null;

            Node head = new(a[0]);
            Node x = head;
            for (int i = 1; i < a.Length; i++)
            {
                Node y = new(a[i]);
                x.next = y;
                x = x.next!;
            }

            return head;
        }

        public static Node0? RftCreateCircularArrayFromNodes(int[] a)
        {
            if (a.Length == 0) return null;

            Node0? head = new(a[0]);
            Node0? x = head;
            for (int i = 1; i < a.Length; i++)
            {
                Node0 y = new(a[i]);
                x.next = y;
                x = x.next!;
            }
            x.next = head;

            return head;
        }
    }
}
