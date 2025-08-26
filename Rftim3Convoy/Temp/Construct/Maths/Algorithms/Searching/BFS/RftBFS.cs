namespace Rftim3Convoy.Temp.Construct.Maths.Algorithms.Searching.BFS
{
    public class RftBFS
    {
        // Queue
        public RftBFS()
        {
            int nv = 4;
            int start = 2;

            LinkedList<int>[] nodes = new LinkedList<int>[nv];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new LinkedList<int>();
            }
            Console.WriteLine("Following is Breadth First Traversal(starting from vertex 2)");

            nodes[0].AddLast(1);
            nodes[0].AddLast(2);
            nodes[1].AddLast(2);
            nodes[2].AddLast(0);
            nodes[2].AddLast(3);
            nodes[3].AddLast(3);

            BFS(nv, nodes, start);
        }

        private static void BFS(int nv, LinkedList<int>[] nodes, int start)
        {
            bool[] vis = new bool[nv];

            for (int i = 0; i < nv; i++)
            {
                vis[i] = false;
            }

            Queue<int> q = new();

            vis[start] = true;
            q.Enqueue(start);

            while (q.Count != 0)
            {
                start = q.Dequeue();
                Console.Write($"{start} ");

                LinkedList<int> list = nodes[start];

                foreach (int val in list)
                {
                    if (!vis[val])
                    {
                        vis[val] = true;
                        q.Enqueue(val);
                    }
                }
            }
        }
    }
}
