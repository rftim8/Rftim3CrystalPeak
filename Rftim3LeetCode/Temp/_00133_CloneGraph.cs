using Rftim3Atlas.Models;

namespace Rftim3LeetCode.Temp
{
    public class _00133_CloneGraph
    {
        /// <summary>
        /// Given a reference of a node in a connected undirected graph.
        /// Return a deep copy(clone) of the graph.
        /// Each node in the graph contains a value(int) and a list(List[Node]) of its neighbors.
        /// class Node
        /// {
        ///     public int val;
        ///     public List<Node> neighbors;
        /// }
        /// Test case format:
        /// For simplicity, each node's value is the same as the node's index(1-indexed). For example, the first node with val == 1, the second node with val == 2, and so on.The graph is represented in the test case using an adjacency list.
        /// An adjacency list is a collection of unordered lists used to represent a finite graph.Each list describes the set of neighbors of a node in the graph.
        /// The given node will always be the first node with val = 1.You must return the copy of the given node as a reference to the cloned graph.
        /// </summary>
        public _00133_CloneGraph()
        {
            Node a3 = new(4);
            Node a2 = new(3);
            Node a1 = new(2);
            Node a0 = new(1);

            a3.children?.Add(a2);
            a3.children?.Add(a0);
            a2.children?.Add(a1);
            a2.children?.Add(a3);
            a1.children?.Add(a0);
            a1.children?.Add(a2);
            a0.children?.Add(a3);
            a0.children?.Add(a1);

            Console.WriteLine(CloneGraph(a0)?.val);
        }

        private static Node? CloneGraph(Node node)
        {
            if (node is null) return null;

            Queue<Node> q = new();
            q.Enqueue(node);

            Dictionary<Node, Node> x = new()
            {
                { node, new Node(node.val) }
            };

            while (q.Any())
            {
                Node? c = q.Dequeue();

                foreach (Node item in c.children!)
                {
                    if (!x.ContainsKey(item))
                    {
                        x.Add(item, new Node(item.val));
                        q.Enqueue(item);
                    }

                    x[c].children?.Add(x[item]);
                }
            }

            return x[node];
        }
    }
}
