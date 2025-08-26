namespace Rftim3Atlas.Models
{
    public class Node
    {
        public int val;
        public Node? left;
        public Node? right;
        public Node? next;
        public Node? random;
        public IList<Node>? children;

        public Node() { }

        public Node(int val)
        {
            this.val = val;
        }

        public Node(int val, IList<Node>? children = null)
        {
            this.val = val;
            this.children = children;
        }

        public Node(int val, Node? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public Node(int val, Node? left = null, Node? right = null, Node? next = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.next = next;
        }
    }
}
