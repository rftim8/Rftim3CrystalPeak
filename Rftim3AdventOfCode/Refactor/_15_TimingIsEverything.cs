using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _15_TimingIsEverything : I_15_TimingIsEverything
    {
        #region Static
        private readonly List<string>? data;

        public _15_TimingIsEverything()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_15_TimingIsEverything));
        }

        /// <summary>
        /// The halls open into an interior plaza containing a large kinetic sculpture.
        /// The sculpture is in a sealed enclosure and seems to involve a set of identical spherical capsules that are carried to the 
        /// top and allowed to bounce through the maze of spinning pieces.
        /// 
        /// Part of the sculpture is even interactive! When a button is pressed, a capsule is dropped and tries to fall through slots 
        /// in a set of rotating discs to finally go through a little hole at the bottom and come out of the sculpture.
        /// If any of the slots aren't aligned with the capsule as it passes, the capsule bounces off the disc and soars away. 
        /// You feel compelled to get one of those capsules.
        /// 
        /// The discs pause their motion each second and come in different sizes; 
        /// they seem to each have a fixed number of positions at which they stop.
        /// You decide to call the position with the slot 0, and count up for each position it reaches next.
        /// 
        /// Furthermore, the discs are spaced out so that after you push the button, one second elapses before the first disc is reached, 
        /// and one second elapses as the capsule passes from one disc to the one below it.
        /// So, if you push the button at time = 100, then the capsule reaches the top disc at time = 101, the second disc at time = 102, the third disc at time = 103, and so on.
        /// 
        /// The button will only drop a capsule at an integer time - no fractional seconds allowed.
        /// 
        /// For example, at time = 0, suppose you see the following arrangement:
        /// 
        /// Disc #1 has 5 positions; at time=0, it is at position 4.
        /// Disc #2 has 2 positions; at time=0, it is at position 1.
        /// If you press the button exactly at time = 0, the capsule would start to fall; it would reach the first disc at time = 1.
        /// Since the first disc was at position 4 at time = 0, by time=1 it has ticked one position forward.
        /// As a five-position disc, the next position is 0, and the capsule falls through the slot.
        /// 
        /// Then, at time = 2, the capsule reaches the second disc. 
        /// The second disc has ticked forward two positions at this point: it started at position 1, then continued to position 0, and finally ended up at position 1 again.
        /// Because there's only a slot at position 0, the capsule bounces away.
        /// 
        /// If, however, you wait until time = 5 to push the button, then when the capsule reaches each disc,
        /// the first disc will have ticked forward 5+1 = 6 times (to position 0), and the second disc will have ticked forward 5+2 = 7 times(also to position 0). 
        /// In this case, the capsule would fall through the discs and come out of the machine.
        /// However, your situation has more than two discs; you've noted their positions in your puzzle input. 
        /// What is the first time you can press the button to get a capsule?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<List<int>> discs = [];
            foreach (string item in input)
            {
                List<string> s = [.. item.Replace(".", "").Replace("#", "").Split(' ')];
                List<int> t = s.Where(o => int.TryParse(o, out int value)).Select(int.Parse).ToList();
                discs.Add(t);
            }

            int time = 0;

            int fallen;
            while (true)
            {
                fallen = 0;
                for (int i = 0; i < discs.Count; i++)
                {
                    if ((discs[i][0] + time + discs[i][2]) % discs[i][1] == 0) fallen++;
                }

                if (fallen == discs.Count) break;

                time++;
            }

            return time;
        }

        /// <summary>
        /// After getting the first capsule (it contained a star! what great fortune!), the machine detects your success and begins to rearrange itself.
        /// 
        /// When it's done, the discs are back in their original configuration as if it were time=0 again, but a new disc with 11 positions and starting at
        /// position 0 has appeared exactly one second below the previously-bottom disc.
        /// 
        /// With this new disc, and counting again starting from time = 0 with the configuration in your puzzle input, 
        /// what is the first time you can press the button to get another capsule?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<List<int>> discs = [];
            foreach (string item in input)
            {
                List<string> s = [.. item.Replace(".", "").Replace("#", "").Split(' ')];
                List<int> t = s.Where(o => int.TryParse(o, out int value)).Select(int.Parse).ToList();
                discs.Add(t);
            }
            discs.Add([7, 11, 0]);

            int time = 0;

            int fallen;
            while (true)
            {
                fallen = 0;
                for (int i = 0; i < discs.Count; i++)
                {
                    if ((discs[i][0] + time + discs[i][2]) % discs[i][1] == 0) fallen++;
                }

                if (fallen == discs.Count) break;

                time++;
            }

            return time;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _15_TimingIsEverything(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_15_TimingIsEverything));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}