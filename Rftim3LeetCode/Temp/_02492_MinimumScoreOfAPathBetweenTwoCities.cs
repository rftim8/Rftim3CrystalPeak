namespace Rftim3LeetCode.Temp
{
    public class _02492_MinimumScoreOfAPathBetweenTwoCities
    {
        /// <summary>
        /// You are given a positive integer n representing n cities numbered from 1 to n. 
        /// You are also given a 2D array roads where roads[i] = [ai, bi, distancei] indicates that there is a bidirectional road between cities ai and bi 
        /// with a distance equal to distancei. 
        /// The cities graph is not necessarily connected.
        /// The score of a path between two cities is defined as the minimum distance of a road in this path.
        /// Return the minimum possible score of a path between cities 1 and n.
        /// Note:
        /// A path is a sequence of roads between two cities.
        /// It is allowed for a path to contain the same road multiple times, and you can visit cities 1 and n multiple times along the path.
        /// The test cases are generated such that there is at least one path between 1 and n.
        /// </summary>
        public _02492_MinimumScoreOfAPathBetweenTwoCities()
        {
            Console.WriteLine(MinScore(4, [
                [1,2,9],
                [2,3,6],
                [2,4,5],
                [1,4,7]
            ]));
        }

        private static int MinScore(int n, int[][] roads)
        {
            HashSet<int> visited = [];
            Dictionary<int, List<(int city, int distance)>> graph = [];
            foreach (int[] item in roads)
            {
                int cityA = item[0];
                int cityB = item[1];
                int distance = item[2];

                graph[cityA] = graph.GetValueOrDefault(cityA, new List<(int, int)>());
                graph[cityA].Add((cityB, distance));

                graph[cityB] = graph.GetValueOrDefault(cityB, new List<(int, int)>());
                graph[cityB].Add((cityA, distance));
            }

            Queue<int> q = new();
            q.Enqueue(1);

            int x = int.MaxValue;

            while (q.Count > 0)
            {
                int city = q.Dequeue();
                if (!visited.Contains(city))
                {
                    visited.Add(city);

                    foreach ((int cityB, int distance) in graph.GetValueOrDefault(city, Enumerable.Empty<(int, int)>().ToList()))
                    {
                        x = Math.Min(x, distance);
                        if (!visited.Contains(cityB))
                        {
                            q.Enqueue(cityB);
                        }
                    }
                }
            }

            return x;
        }
    }
}