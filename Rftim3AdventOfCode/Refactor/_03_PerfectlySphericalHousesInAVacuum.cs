using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _03_PerfectlySphericalHousesInAVacuum : I_03_PerfectlySphericalHousesInAVacuum
    {
        #region Static
        private readonly List<string>? data;

        public _03_PerfectlySphericalHousesInAVacuum()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_03_PerfectlySphericalHousesInAVacuum));
        }

        /// <summary>
        /// Santa is delivering presents to an infinite two-dimensional grid of houses.
        /// He begins by delivering a present to the house at his starting location, and then an elf at the North Pole calls him via radio and tells him where to move next.
        /// Moves are always exactly one house to the north (^), south(v), east(>), or west(<). After each move, he delivers another present to the house at his new location.
        /// However, the elf back at the north pole has had a little too much eggnog, and so his directions are a little off, and Santa ends up visiting some houses more than once.
        /// 
        /// How many houses receive at least one present?
        /// 
        /// For example:
        /// 
        /// > delivers presents to 2 houses: one at the starting location, and one to the east.
        /// ^>v<delivers presents to 4 houses in a square, including twice to the house at his starting/ending location.
        /// ^v^v^v^v^v delivers a bunch of presents to some very lucky children at only 2 houses.
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string data = input[0];
            List<House> h = [];
            int xs = 0;
            int ys = 0;
            h.Add(new House(xs, ys, 0));

            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case '^':
                        ys++;
                        break;
                    case '>':
                        xs++;
                        break;
                    case 'v':
                        ys--;
                        break;
                    case '<':
                        xs--;
                        break;
                    default:
                        break;
                }
                int f = h.Where(o => o.x == xs && o.y == ys).Count();

                if (f == 0) h.Add(new House(xs, ys, 0));
            }

            return h.Count;
        }

        /// <summary>
        /// The next year, to speed up the process, Santa creates a robot version of himself, Robo-Santa, to deliver presents with him.
        /// Santa and Robo-Santa start at the same location(delivering two presents to the same starting house), 
        /// then take turns moving based on instructions from the elf, who is eggnoggedly reading from the same script as the previous year.
        /// 
        /// This year, how many houses receive at least one present?
        /// 
        /// For example:
        /// 
        /// ^v delivers presents to 3 houses, because Santa goes north, and then Robo-Santa goes south.
        /// ^>v<now delivers presents to 3 houses, and Santa and Robo-Santa end up back where they started.
        /// ^v^v^v^v^v now delivers presents to 11 houses, with Santa going one direction and Robo-Santa going the other.
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            string data = input[0];
            List<House> h = [];
            int xs = 0;
            int ys = 0;
            int xr = 0;
            int yr = 0;
            h.Add(new House(xs, ys, 0));

            for (int i = 0; i < data.Length; i++)
            {
                if (i % 2 == 0)
                {
                    switch (data[i])
                    {
                        case '^':
                            ys++;
                            break;
                        case '>':
                            xs++;
                            break;
                        case 'v':
                            ys--;
                            break;
                        case '<':
                            xs--;
                            break;
                        default:
                            break;
                    }
                    int f = h.Where(o => o.x == xs && o.y == ys).Count();
                    if (f == 0) h.Add(new House(xs, ys, 0));
                }
                else
                {
                    switch (data[i])
                    {
                        case '^':
                            yr++;
                            break;
                        case '>':
                            xr++;
                            break;
                        case 'v':
                            yr--;
                            break;
                        case '<':
                            xr--;
                            break;
                        default:
                            break;
                    }
                    int f = h.Where(o => o.x == xr && o.y == yr).Count();
                    if (f == 0) h.Add(new House(xr, yr, 0));
                }
            }

            return h.Count;
        }

        private class House(int x, int y, int c)
        {
            public int x = x, y = y, c = c;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _03_PerfectlySphericalHousesInAVacuum(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_03_PerfectlySphericalHousesInAVacuum));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}