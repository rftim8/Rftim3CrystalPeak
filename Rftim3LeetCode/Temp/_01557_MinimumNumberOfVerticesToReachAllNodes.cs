using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01557_MinimumNumberOfVerticesToReachAllNodes
    {
        /// <summary>
        /// Given a directed acyclic graph, with n vertices numbered from 0 to n-1, and an array edges where edges[i] = [fromi, toi] 
        /// represents a directed edge from node fromi to node toi.
        /// Find the smallest set of vertices from which all nodes in the graph are reachable.It's guaranteed that a unique solution exists.
        /// Notice that you can return the vertices in any order.
        /// </summary>
        public _01557_MinimumNumberOfVerticesToReachAllNodes()
        {
            IList<int> x = FindSmallestSetOfVertices(6, [
                [ 0,1 ],
                [ 0,2 ],
                [ 2,5 ],
                [ 3,4 ],
                [ 4,2 ]
            ]);

            RftTerminal.RftReadResult(x);
        }

        private static List<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            bool[] isIncomingEdgeExists = new bool[n];
            foreach (List<int> edge in edges.Cast<List<int>>())
            {
                isIncomingEdgeExists[edge[1]] = true;
            }

            List<int> requiredNodes = new();
            for (int i = 0; i < n; i++)
            {
                if (!isIncomingEdgeExists[i]) requiredNodes.Add(i);
            }

            return requiredNodes;
        }

        private static List<int> FindSmallestSetOfVertices0(int n, IList<IList<int>> edges)
        {
            List<int> result = [];
            HashSet<int> set = [];

            for (int i = 0; i < edges.Count; i++)
            {
                set.Add(edges[i][1]);
            }

            for (int i = 0; i < n; i++)
            {
                if (!set.Contains(i)) result.Add(i);
            }

            return result;
        }
    }
}
