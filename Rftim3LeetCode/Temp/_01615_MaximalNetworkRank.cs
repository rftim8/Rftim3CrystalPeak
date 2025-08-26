namespace Rftim3LeetCode.Temp
{
    public class _01615_MaximalNetworkRank
    {
        /// <summary>
        /// There is an infrastructure of n cities with some number of roads connecting these cities. 
        /// Each roads[i] = [ai, bi] indicates that there is a bidirectional road between cities ai and bi.
        /// The network rank of two different cities is defined as the total number of directly connected roads to either city.
        /// If a road is directly connected to both cities, it is only counted once.
        /// The maximal network rank of the infrastructure is the maximum network rank of all pairs of different cities.
        /// Given the integer n and the array roads, return the maximal network rank of the entire infrastructure.
        /// </summary>
        public _01615_MaximalNetworkRank()
        {
            Console.WriteLine(MaximalNetworkRank(4, [
                [0,1],
                [0,3],
                [1,2],
                [1,3]
            ]));

            Console.WriteLine(MaximalNetworkRank(5, [
                [0,1],
                [0,3],
                [1,2],
                [1,3],
                [2,3],
                [2,4]
            ]));

            Console.WriteLine(MaximalNetworkRank(8, [
                [0,1],
                [1,2],
                [2,3],
                [2,4],
                [5,6],
                [5,7]
            ]));

            Console.WriteLine(MaximalNetworkRank(6, [
                [2,4]
            ]));
        }

        private static int MaximalNetworkRank(int n, int[][] roads)
        {
            if (roads.Length == 0) return 0;

            int[] countArray = new int[n];
            int[,] adjMatrix = new int[n, n];

            int maxRank = 0;

            foreach (int[] connection in roads)
            {
                countArray[connection[0]]++;
                countArray[connection[1]]++;
                adjMatrix[connection[0], connection[1]] = 1;
                adjMatrix[connection[1], connection[0]] = 1;
            }

            for (int i = 0; i < countArray.Length - 1; i++)
            {
                for (int j = i + 1; j < countArray.Length; j++)
                {
                    maxRank = Math.Max(maxRank, countArray[i] + countArray[j] - adjMatrix[i, j]);
                }
            }

            return maxRank;
        }

        private static int MaximalNetworkRank0(int n, int[][] roads)
        {
            if (roads.Length == 0) return 0;

            int maxRank = 0;
            Dictionary<int, HashSet<int>> adj = [];
            foreach (int[] road in roads)
            {
                if (adj.TryGetValue(road[0], out HashSet<int>? value)) value.Add(road[1]);
                else adj.Add(road[0], [road[1]]);

                if (adj.TryGetValue(road[1], out HashSet<int>? value0)) value0.Add(road[0]);
                else adj.Add(road[1], [road[0]]);
            }

            for (int node1 = 0; node1 < n; ++node1)
            {
                for (int node2 = node1 + 1; node2 < n; ++node2)
                {
                    int currentRank = 0;

                    if (adj.ContainsKey(node1))
                    {
                        if (adj.TryGetValue(node1, out HashSet<int>? x)) currentRank += x.Count;
                    }

                    if (adj.ContainsKey(node2))
                    {
                        if (adj.TryGetValue(node2, out HashSet<int>? y)) currentRank += y.Count;
                    }

                    if (adj.TryGetValue(node1, out HashSet<int>? value))
                    {
                        if (value.Contains(node2)) --currentRank;
                    }
                    maxRank = Math.Max(maxRank, currentRank);
                }
            }

            return maxRank;
        }
    }
}
