namespace Rftim3LeetCode.Temp
{
    public class _00787_CheapestFlightsWithinKStops
    {
        /// <summary>
        /// There are n cities connected by some number of flights. 
        /// You are given an array flights where flights[i] = [fromi, toi, pricei] indicates that there is a flight from city fromi to city toi with cost pricei.
        /// 
        /// You are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k stops.
        /// If there is no such route, return -1.
        /// </summary>
        public _00787_CheapestFlightsWithinKStops()
        {
            Console.WriteLine(CheapestFlightsWithinKStops0(4, [[0, 1, 100], [1, 2, 100], [2, 0, 100], [1, 3, 600], [2, 3, 200]], 0, 3, 1));
            Console.WriteLine(CheapestFlightsWithinKStops0(3, [[0, 1, 100], [1, 2, 100], [0, 2, 500]], 0, 2, 1));
            Console.WriteLine(CheapestFlightsWithinKStops0(3, [[0, 1, 100], [1, 2, 100], [0, 2, 500]], 0, 2, 0));
        }

        public static int CheapestFlightsWithinKStops0(int a0, int[][] a1, int a2, int a3, int a4) => RftCheapestFlightsWithinKStops0(a0, a1, a2, a3, a4);

        private static int RftCheapestFlightsWithinKStops0(int n, int[][] flights, int src, int dst, int k)
        {
            int[] cost = new int[n];
            Array.Fill(cost, int.MaxValue);
            cost[src] = 0;

            for (int i = 0; i <= k; i++)
            {
                int[] temp = new int[n];
                Array.Copy(cost, temp, n);

                foreach (int[] flight in flights)
                {
                    int curr = flight[0], next = flight[1], price = flight[2];
                    if (cost[curr] == int.MaxValue) continue;

                    temp[next] = Math.Min(temp[next], cost[curr] + price);
                }
                cost = temp;
            }

            return cost[dst] == int.MaxValue ? -1 : cost[dst];
        }
    }
}
