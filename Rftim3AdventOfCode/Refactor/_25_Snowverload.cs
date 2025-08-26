using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _25_Snowverload : I_25_Snowverload
    {
        #region Static
        private readonly List<string>? data;

        public _25_Snowverload()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_25_Snowverload));
        }

        /// <summary>
        /// Still somehow without snow, you go to the last place you haven't checked: the center of Snow Island, directly below the waterfall.
        /// 
        /// Here, someone has clearly been trying to fix the problem.
        /// Scattered everywhere are hundreds of weather machines, almanacs, communication modules, hoof prints, machine parts, mirrors, 
        /// lenses, and so on.
        /// 
        /// Somehow, everything has been wired together into a massive snow-producing apparatus, but nothing seems to be running. 
        /// You check a tiny screen on one of the communication modules: Error 2023. 
        /// It doesn't say what Error 2023 means, but it does have the phone number for a support line printed on it.
        /// 
        /// "Hi, you've reached Weather Machines And So On, Inc. How can I help you?" You explain the situation.
        /// 
        /// "Error 2023, you say? Why, that's a power overload error, of course! It means you have too many components plugged in. 
        /// Try unplugging some components and--" You explain that there are hundreds of components here and you're in a bit of a hurry.
        /// 
        /// "Well, let's see how bad it is; do you see a big red reset button somewhere? It should be on its own module. 
        /// If you push it, it probably won't fix anything, but it'll report how overloaded things are." 
        /// After a minute or two, you find the reset button; it's so big that it takes two hands just to get enough leverage to push it. 
        /// Its screen then displays:
        /// 
        /// SYSTEM OVERLOAD!
        /// 
        /// Connected components would require
        /// power equal to at least 100 stars!
        /// "Wait, how many components did you say are plugged in? 
        /// With that much equipment, you could produce snow for an entire--" You disconnect the call.
        /// 
        /// You have nowhere near that many stars - you need to find a way to disconnect at least half of the equipment here, 
        /// but it's already Christmas! You only have time to disconnect three wires.
        /// 
        /// Fortunately, someone left a wiring diagram (your puzzle input) that shows how the components are connected.For example:
        /// 
        /// jqt: rhn xhk nvd
        /// rsh: frs pzl lsr
        /// xhk: hfx
        /// cmg: qnr nvd lhk bvb
        /// rhn: xhk bvb hfx
        /// bvb: xhk hfx
        /// pzl: lsr hfx nvd
        /// qnr: nvd
        /// ntq: jqt hfx bvb xhk
        /// nvd: lhk
        /// lsr: lhk
        /// rzs: qnr cmg lsr rsh
        /// frs: qnr lhk lsr
        /// Each line shows the name of a component, a colon, and then a list of other components to which that component is connected.
        /// Connections aren't directional; abc: xyz and xyz: abc both represent the same configuration.
        /// Each connection between two components is represented only once, so some components might only ever appear on the left or right side
        /// of a colon.
        /// 
        /// In this example, if you disconnect the wire between hfx/pzl, the wire between bvb/cmg, and the wire between nvd/jqt,
        /// you will divide the components into two separate, disconnected groups:
        /// 
        /// 9 components: cmg, frs, lhk, lsr, nvd, pzl, qnr, rsh, and rzs.
        /// 6 components: bvb, hfx, jqt, ntq, rhn, and xhk.
        /// Multiplying the sizes of these groups together produces 54.
        /// 
        /// Find the three wires you need to disconnect in order to divide the components into two separate groups.
        /// What do you get if you multiply the sizes of these two groups together?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string result;
            List<(string, string)> edges;
            List<string> vertices;

            vertices = [];
            edges = [];

            foreach (string line in input)
            {
                string[] split = line.Split(": ");
                string component = split[0];
                split = split[1].Split(' ');
                HashSet<string> connected = new(split);

                if (!vertices.Contains(component)) vertices.Add(component);

                foreach (string c in connected)
                {
                    if (!vertices.Contains(c)) vertices.Add(c);
                    if (!edges.Contains((component, c)) && !edges.Contains((c, component))) edges.Add((component, c));
                }
            }

            List<List<string>> subsets = [];

            do
            {
                subsets = [];

                foreach (string vertex in vertices)
                {
                    subsets.Add([vertex]);
                }

                int i;
                List<string> subset1, subset2;

                while (subsets.Count > 2)
                {
                    i = new Random().Next() % edges.Count;

                    subset1 = subsets.Where(s => s.Contains(edges[i].Item1)).First();
                    subset2 = subsets.Where(s => s.Contains(edges[i].Item2)).First();

                    if (subset1 == subset2) continue;

                    subsets.Remove(subset2);
                    subset1.AddRange(subset2);
                }

            } while (CountCuts(subsets) != 3);

            int CountCuts(List<List<string>> subsets)
            {
                int cuts = 0;
                for (int i = 0; i < edges.Count; ++i)
                {
                    List<string> subset1 = subsets.First(s => s.Contains(edges[i].Item1));
                    List<string> subset2 = subsets.First(s => s.Contains(edges[i].Item2));
                    if (subset1 != subset2) ++cuts;
                }

                return cuts;
            }

            return int.Parse(result = "" + subsets.Aggregate(1, (p, s) => p * s.Count));
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _25_Snowverload(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_25_Snowverload));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
        }
        #endregion
    }
}