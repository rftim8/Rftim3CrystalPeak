using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00559_MaximumDepthOfNaryTree
    {
        /// <summary>
        /// Given a n-ary tree, find its maximum depth.
        /// The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
        /// Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).
        /// </summary>
        public _00559_MaximumDepthOfNaryTree()
        {
            List<Node> x = [new(1), new(3), new(2), new(4), new(5), new(6)];
            x[0].children = [x[1], x[2], x[3]];
            x[1].children = [x[4], x[5]];
            Console.WriteLine(MaxDepth0(x[0]));
        }

        public static int MaxDepth0(Node a0) => RftMaxDepth0(a0);

        private static int RftMaxDepth0(Node root)
        {
            if (root is null) return 0;

            int x = 0;
            Queue<Node> q = new();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                x++;
                int n = q.Count;
                for (int i = 0; i < n; i++)
                {
                    Node c = q.Dequeue();

                    if (c.children is not null)
                    {
                        foreach (Node item in c.children)
                        {
                            q.Enqueue(item);
                        }
                    }
                }
            }

            return x;
        }
    }
}
