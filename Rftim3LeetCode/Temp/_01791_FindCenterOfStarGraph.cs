namespace Rftim3LeetCode.Temp
{
    public class _01791_FindCenterOfStarGraph
    {
        /// <summary>
        /// There is an undirected star graph consisting of n nodes labeled from 1 to n. 
        /// A star graph is a graph where there is one center node and exactly n - 1 edges that connect the center node with every other node.
        /// You are given a 2D integer array edges where each edges[i] = [ui, vi] indicates that there is an edge between the nodes ui and vi.
        /// Return the center of the given star graph.
        /// </summary>
        public _01791_FindCenterOfStarGraph()
        {
            Console.WriteLine(FindCenter(
            [
                [1,2],
                [2,3],
                [4,2]
            ]));
            Console.WriteLine(FindCenter(
            [
                [1,2],
                [5,1],
                [1,3],
                [1,4]
            ]));
        }

        private static int FindCenter(int[][] edges)
        {
            int n = edges.Length;
            int m = edges[0].Length;
            Dictionary<int, int> r = [];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (r.TryGetValue(edges[i][j], out int value)) r[edges[i][j]] = ++value;
                    else r[edges[i][j]] = 1;
                }
            }

            return r.MaxBy(o => o.Value).Key;
        }
    }
}
