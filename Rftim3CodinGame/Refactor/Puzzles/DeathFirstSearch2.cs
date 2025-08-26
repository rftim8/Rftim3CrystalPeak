namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class DeathFirstSearch2
    {
        // 66%
        public DeathFirstSearch2()
        {

        }

        public static void DeathFirstSearch20() => RftDeathFirstSearch20();

        private static void RftDeathFirstSearch20()
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
            int L = int.Parse(inputs[1]); // the number of links
            int E = int.Parse(inputs[2]); // the number of exit gateways
            List<(int, int)> l = [];
            List<int> g = [];
            for (int i = 0; i < L; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
                int N2 = int.Parse(inputs[1]);
                l.Add((N1, N2));
            }
            for (int i = 0; i < E; i++)
            {
                int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
                g.Add(EI);
            }

            while (true)
            {
                int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn

                List<List<int>> l0 = [[SI]];
                bool f0 = false;
                int i = 0;
                while (!f0)
                {
                    List<int> l1 = [];

                    Dictionary<int, List<(int, int)>> kvp = [];
                    foreach (int item in l0[i])
                    {
                        Console.Error.WriteLine(item);
                        foreach ((int, int) item1 in l)
                        {
                            if (item1.Item1 == item && g.Contains(item1.Item2))
                            {
                                if (kvp.TryGetValue(item, out List<(int, int)>? value)) value.Add(item1);
                                else kvp[item] = [item1];
                                f0 = true;
                            }
                            else if (item1.Item2 == item && g.Contains(item1.Item1))
                            {
                                if (kvp.TryGetValue(item, out List<(int, int)>? value)) value.Add(item1);
                                else kvp[item] = [item1];
                                f0 = true;
                            }
                            else if (item1.Item1 == item && !g.Contains(item1.Item1)) l1.Add(item1.Item2);
                            else if (item1.Item2 == item && !g.Contains(item1.Item2)) l1.Add(item1.Item1);
                        }
                        foreach (var x in kvp)
                        {
                            Console.Error.WriteLine($"Key: {x.Key}");
                            foreach (var y in x.Value)
                            {
                                Console.Error.Write($"{y} ");
                            }
                            Console.Error.WriteLine();
                        }
                    }
                    if (kvp.Count > 0)
                    {
                        int t = kvp.MaxBy(o => o.Value.Count).Key;
                        Console.WriteLine($"{kvp[t][0].Item1} {kvp[t][0].Item2}");
                        l.Remove((kvp[t][0].Item1, kvp[t][0].Item2));
                    }

                    l0.Add(l1);
                    i++;
                }
            }
        }
    }
}
