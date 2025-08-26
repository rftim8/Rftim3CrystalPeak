using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01436_DestinationCity
    {
        /// <summary>
        /// You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.
        /// Return the destination city, that is, the city without any path outgoing to another city.
        /// It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        /// </summary>
        public _01436_DestinationCity()
        {
            Console.WriteLine(DestCity(
            [
                [ "London","New York" ],
                [ "New York","Lima" ],
                [ "Lima", "Sao Paulo" ]
            ]));
            Console.WriteLine(DestCity(
            [
                [ "B","C" ],
                [ "D","B" ],
                [ "C", "A" ]
            ]));
            Console.WriteLine(DestCity(
            [
                [ "A","Z" ]
            ]));
        }

        private static string DestCity(IList<IList<string>> paths)
        {
            Dictionary<string, string> dict = paths.ToDictionary(x => x[0], x => x[1]);
            RftTerminal.RftReadResult(dict);

            string dest = dict.First().Value;

            while (dict.ContainsKey(dest))
            {
                dest = dict[dest];
            }

            return dest;
        }

        private static string DestCity0(IList<IList<string>> paths)
        {
            Dictionary<string, int> outgoingPaths = [];
            foreach (IList<string> cities in paths)
            {
                outgoingPaths[cities[0]] = outgoingPaths.TryGetValue(cities[0], out int value) ? value + 1 : 1;
                outgoingPaths[cities[1]] = outgoingPaths.TryGetValue(cities[1], out int value0) ? value0 : 0;
            }

            foreach (KeyValuePair<string, int> element in outgoingPaths)
            {
                if (element.Value == 0) return element.Key;
            }

            return "";
        }
    }
}
