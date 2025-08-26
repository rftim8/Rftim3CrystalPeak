using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00332_ReconstructItinerary
    {
        /// <summary>
        /// You are given a list of airline tickets where tickets[i] = [fromi, toi] represent the departure and the arrival airports of one flight. 
        /// Reconstruct the itinerary in order and return it.
        /// All of the tickets belong to a man who departs from "JFK", thus, the itinerary must begin with "JFK". 
        /// If there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order when read as a single string.
        /// For example, the itinerary["JFK", "LGA"] has a smaller lexical order than["JFK", "LGB"].
        /// You may assume all tickets form at least one valid itinerary.You must use all the tickets once and only once.
        /// </summary>
        public _00332_ReconstructItinerary()
        {
            IList<string> x = FindItinerary(
                [
                    [ "MUC", "LHR" ],
                    [ "JFK","MUC" ],
                    [ "SFO","SJC" ],
                    [ "LHR", "SFO" ]
            ]);
            RftTerminal.RftReadResult(x);

            IList<string> x0 = FindItinerary(
                [
                    [ "JFK","SFO" ],
                    [ "JFK","ATL" ],
                    [ "SFO","ATL" ],
                    [ "ATL", "JFK" ],
                    [ "ATL", "SFO" ]
            ]);
            RftTerminal.RftReadResult(x0);
        }

        private static List<string> FindItinerary(IList<IList<string>> tickets)
        {
            Dictionary<string, List<string>> d = [];
            Stack<string> s = new();
            foreach (IList<string> ticket in tickets)
            {
                if (!d.ContainsKey(ticket[0])) d.Add(ticket[0], []);
                d[ticket[0]].Add(ticket[1]);
            }

            foreach (List<string> item in d.Values)
            {
                item.Sort((a, b) => b.CompareTo(a));
            }

            Dfs(d, "JFK", s);

            return [.. s];
        }

        private static void Dfs(Dictionary<string, List<string>> d, string from, Stack<string> s)
        {
            if (d.TryGetValue(from, out List<string>? value))
            {
                List<string> destinations = value;
                while (destinations.Count > 0)
                {
                    string dest = destinations[^1];
                    destinations.RemoveAt(destinations.Count - 1);
                    Dfs(d, dest, s);
                }
            }
            s.Push(from);
        }

        private static List<string> FindItinerary0(IList<IList<string>> tickets)
        {
            List<string> ans = [];
            Dictionary<string, List<string>> graph = [];

            foreach (IList<string> ticket in tickets)
            {
                string a = ticket[0];
                string b = ticket[1];

                if (!graph.ContainsKey(a)) graph[a] = [];

                graph[a].Add(b);
            }

            foreach (string? u in graph.Keys.ToList())
            {
                graph[u].Sort();
            }

            void DFS(string u)
            {
                while (graph.ContainsKey(u) && graph[u].Count > 0)
                {
                    string v = graph[u][0];
                    graph[u].RemoveAt(0);
                    DFS(v);
                }
                ans.Insert(0, u);
            }

            DFS("JFK");

            return ans;
        }
    }
}
