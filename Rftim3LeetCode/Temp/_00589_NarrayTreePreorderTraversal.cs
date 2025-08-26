using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00589_NarrayTreePreorderTraversal
    {
        /// <summary>
        /// Given the root of an n-ary tree, return the preorder traversal of its nodes' values.
        /// Nary-Tree input serialization is represented in their level order traversal.Each group of children is separated by the null value (See examples)
        /// </summary>
        public _00589_NarrayTreePreorderTraversal()
        {
            Node a5 = new(6);
            Node a4 = new(5);
            Node a3 = new(4);
            Node a2 = new(2);
            Node a1 = new(3, [a4, a5]);
            Node a0 = new(1, [a1, a2, a3]);

            IList<int> x = Preorder(a0);

            RftTerminal.RftReadResult(x);
        }

        private static List<int> Preorder(Node root)
        {
            if (root is null) return [];

            List<int> x = [];
            Stack<Node> y = new();
            y.Push(root);

            while (y.Count != 0)
            {
                Node z = y.Pop();
                x.Add(z.val);

                if (z.children is not null)
                {
                    for (int i = z.children.Count - 1; i >= 0; i--)
                    {
                        y.Push(z.children[i]);
                    }
                }
            }

            return x;
        }
    }
}
