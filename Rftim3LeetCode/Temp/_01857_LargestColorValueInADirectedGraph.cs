namespace Rftim3LeetCode.Temp
{
    public class _01857_LargestColorValueInADirectedGraph
    {
        /// <summary>
        /// There is a directed graph of n colored nodes and m edges. The nodes are numbered from 0 to n - 1.
        /// You are given a string colors where colors[i] is a lowercase English letter representing the color of the ith node in this graph(0-indexed). 
        /// You are also given a 2D array edges where edges[j] = [aj, bj] indicates that there is a directed edge from node aj to node bj.
        /// A valid path in the graph is a sequence of nodes x1 -> x2 -> x3 -> ... -> xk such that there is a directed edge from xi to xi+1 for every 1 <= i<k.
        /// The color value of the path is the number of nodes that are colored the most frequently occurring color along that path.
        /// Return the largest color value of any valid path in the given graph, or -1 if the graph contains a cycle.
        /// </summary>
        public _01857_LargestColorValueInADirectedGraph()
        {
            Console.WriteLine(LargestPathValue("abaca", [
                [0,1],
                [0,2],
                [2,3],
                [3,4]
            ]));

            Console.WriteLine(LargestPathValue("a", [
                [0,0]
            ]));
        }

        private static int LargestPathValue(string colors, int[][] edges)
        {
            List<HashSet<int>> parentToChildren = [];
            List<HashSet<int>> childToParents = [];
            int n = colors.Length;

            int[] outDegree = new int[n];
            for (int i = 0; i < n; i++)
            {
                parentToChildren.Add([]);
                childToParents.Add([]);
            }
            foreach (int[] edge in edges)
            {
                parentToChildren[edge[0]].Add(edge[1]);
                childToParents[edge[1]].Add(edge[0]);

                outDegree[edge[0]]++;
            }

            int[,] colorMap = new int[n, 26];

            Queue<int> q = new();
            for (int i = 0; i < n; i++)
            {
                if (outDegree[i] == 0) q.Enqueue(i);
            }

            int result = 0;
            int count = n;
            while (q.Count != 0)
            {
                count--;
                int node = q.Dequeue();

                for (int i = 0; i < 26; i++)
                {
                    foreach (int item in parentToChildren[node])
                    {
                        colorMap[node, i] = Math.Max(colorMap[node, i], colorMap[item, i]);
                    }
                }

                colorMap[node, colors[node] - 'a']++;
                result = Math.Max(result, colorMap[node, colors[node] - 'a']);

                foreach (int item in childToParents[node])
                {
                    outDegree[item]--;
                    if (outDegree[item] == 0) q.Enqueue(item);
                }
            }

            return count > 0 ? -1 : result;
        }
    }
}
