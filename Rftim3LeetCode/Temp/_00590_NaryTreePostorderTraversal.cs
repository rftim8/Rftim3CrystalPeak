using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00590_NaryTreePostorderTraversal
    {
        /// <summary>
        /// Given the root of an n-ary tree, return the postorder traversal of its nodes' values.
        /// Nary-Tree input serialization is represented in their level order traversal.
        /// Each group of children is separated by the null value (See examples)
        /// </summary>
        public _00590_NaryTreePostorderTraversal()
        {
            Node a5 = new(6);
            Node a4 = new(5);
            Node a3 = new(4);
            Node a2 = new(2);
            Node a1 = new(3, [a4, a5]);
            Node a0 = new(1, [a1, a2, a3]);

            IList<int> x = Postorder(a0);

            RftTerminal.RftReadResult(x);
        }

        private static List<int> Postorder(Node root)
        {
            if (root is null) return [];

            List<int> x = [];
            Stack<Node> s = new();

            s.Push(root);

            while (s.Count != 0)
            {
                Node node = s.Pop();

                x.Add(node.val);

                if (node.children is not null)
                {
                    foreach (Node item in node.children)
                    {
                        s.Push(item);
                    }
                }
            }

            x.Reverse();

            return x;
        }

        private static readonly List<int> list = [];

        private static List<int> Postorder0(Node root)
        {
            if (root is null) return list;

            if (root.children is not null)
            {
                foreach (Node c in root.children)
                {
                    Postorder0(c);
                }
            }
            list.Add(root.val);

            return list;
        }
    }
}
