namespace Rftim3LeetCode.Temp
{
    public class _00547_NumberOfProvinces
    {
        /// <summary>
        /// There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b, 
        /// and city b is connected directly with city c, then city a is connected indirectly with city c.
        /// A province is a group of directly or indirectly connected cities and no other cities outside of the group.
        /// You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly connected, 
        /// and isConnected[i][j] = 0 otherwise.
        /// Return the total number of provinces.
        /// </summary>
        public _00547_NumberOfProvinces()
        {
            Console.WriteLine(FindCircleNum([
                [1,1,0],
                [1,1,0],
                [0,0,1]
            ]));
            Console.WriteLine(FindCircleNum([
                [1,0,0],
                [0,1,0],
                [0,0,1]
            ]));

            Console.WriteLine(FindCircleNum([
                [1,0,0,1],
                [0,1,1,0],
                [0,1,1,1],
                [1,0,1,1]
            ]));
        }

        private static int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            int c = 0;
            bool[] visit = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visit[i])
                {
                    c++;
                    Dfs(i, isConnected, visit);
                }
            }

            return c;
        }

        private static void Dfs(int node, int[][] isConnected, bool[] visit)
        {
            visit[node] = true;
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (isConnected[node][i] == 1 && !visit[i]) Dfs(i, isConnected, visit);
            }
        }
    }
}
