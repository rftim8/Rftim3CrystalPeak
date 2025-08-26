using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00797_AllPathsFromSourceToTarget
    {
        /// <summary>
        /// Given a directed acyclic graph (DAG) of n nodes labeled from 0 to n - 1, find all possible paths from node 0 to node n - 1 and return them in any order.
        /// The graph is given as follows: graph[i] is a list of all nodes you can visit from node i(i.e., there is a directed edge from node i to node graph[i][j]).
        /// </summary>
        public _00797_AllPathsFromSourceToTarget()
        {
            IList<IList<int>> x = AllPathsSourceTarget([
                [1,2],
                [3],
                [3],
                []
            ]);

            RftTerminal.RftReadResult(x);
        }

        private static List<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            List<IList<int>> list = [];

            Backtrack(list, graph, [0], 0);

            return list;
        }

        private static void Backtrack(List<IList<int>> list, int[][] graph, List<int> temp, int p)
        {
            if (temp.Count > 1 && temp[^1] == graph.Length - 1) list.Add(new List<int>(temp));

            for (int i = 0; i < graph[p].Length; i++)
            {
                temp.Add(graph[p][i]);
                Backtrack(list, graph, temp, graph[p][i]);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
