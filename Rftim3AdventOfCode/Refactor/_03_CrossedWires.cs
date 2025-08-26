using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _03_CrossedWires : I_03_CrossedWires
    {
        #region Static
        private readonly List<string>? data;

        public _03_CrossedWires()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_03_CrossedWires));
        }

        /// <summary>
        /// The gravity assist was successful, and you're well on your way to the Venus refuelling station. 
        /// During the rush back on Earth, the fuel management system wasn't completely installed, so that's next on the priority list.
        /// 
        /// Opening the front panel reveals a jumble of wires.Specifically, two wires are connected to a central port and extend outward on a grid.
        /// You trace the path each wire takes as it leaves the central port, one wire per line of text (your puzzle input).
        /// 
        /// The wires twist and turn, but the two wires occasionally cross paths.To fix the circuit, you need to find the intersection point closest to the central port.
        /// Because the wires are on a grid, use the Manhattan distance for this measurement.
        /// While the wires do technically cross right at the central port where they both start, this point does not count, nor does a wire count as crossing with itself.
        /// 
        /// For example, if the first wire's path is R8,U5,L5,D3, then starting from the central port (o), it goes right 8, up 5, left 5, and finally down 3:
        /// 
        /// ...........
        /// ...........
        /// ...........
        /// ....+----+.
        /// ....|....|.
        /// ....|....|.
        /// ....|....|.
        /// .........|.
        /// .o-------+.
        /// ...........
        /// Then, if the second wire's path is U7,R6,D4,L4, it goes up 7, right 6, down 4, and left 4:
        /// 
        /// ...........
        /// .+-----+...
        /// .|.....|...
        /// .|..+--X-+.
        /// .|..|..|.|.
        /// .|.-X--+.|.
        /// .|..|....|.
        /// .|.......|.
        /// .o-------+.
        /// ...........
        /// These wires cross at two locations(marked X), but the lower-left one is closer to the central port: its distance is 3 + 3 = 6.
        /// 
        /// Here are a few more examples:
        /// 
        /// R75,D30,R83,U83,L12,D49,R71,U7,L72
        /// U62, R66, U55, R34, D71, R55, D58, R83 = distance 159
        /// R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51
        /// U98, R91, D20, R16, D67, R40, U7, R15, U6, R7 = distance 135
        /// What is the Manhattan distance from the central port to the closest intersection?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            int r = int.MaxValue;

            int x = 0, y = 0;
            int x0 = 0, y0 = 0;

            List<string> dir = [.. input[0].Split(',')];
            List<string> dir0 = [.. input[1].Split(',')];

            List<(int, int)> a = [(0, 0)];
            List<(int, int)> a0 = [(0, 0)];
            HashSet<(int, int)> b = [];
            foreach (string item in dir)
            {
                char d = item[0];
                int z = int.Parse(item[1..]);

                switch (d)
                {
                    case 'U':
                        for (int i = 0; i < z; i++)
                        {
                            x--;
                            a.Add((x, y));
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < z; i++)
                        {
                            x++;
                            a.Add((x, y));
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < z; i++)
                        {
                            y--;
                            a.Add((x, y));
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < z; i++)
                        {
                            y++;
                            a.Add((x, y));
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (string item in dir0)
            {
                char d = item[0];
                int z = int.Parse(item[1..]);

                switch (d)
                {
                    case 'U':
                        for (int i = 0; i < z; i++)
                        {
                            x0--;
                            a0.Add((x0, y0));
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < z; i++)
                        {
                            x0++;
                            a0.Add((x0, y0));
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < z; i++)
                        {
                            y0--;
                            a0.Add((x0, y0));
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < z; i++)
                        {
                            y0++;
                            a0.Add((x0, y0));
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach ((int, int) item in a)
            {
                if (a0.Contains(item)) b.Add(item);
            }
            b.Remove((0, 0));

            foreach ((int, int) item in b)
            {
                r = Math.Min(r, Dist(0, 0, item.Item1, item.Item2));
                Console.WriteLine($"{item.Item1} {item.Item2}");
            }

            return r;
        }

        /// <summary>
        /// It turns out that this circuit is very timing-sensitive; you actually need to minimize the signal delay.
        /// 
        /// To do this, calculate the number of steps each wire takes to reach each intersection; choose the intersection where the sum of both wires' steps is lowest. 
        /// If a wire visits a position on the grid multiple times, use the steps value from the first time it visits that position when calculating the total value 
        /// of a specific intersection.
        /// 
        /// The number of steps a wire takes is the total number of grid squares the wire has entered to get to that location, including the intersection being considered.
        /// Again consider the example from above:
        /// 
        /// ...........
        /// .+-----+...
        /// .|.....|...
        /// .|..+--X-+.
        /// .|..|..|.|.
        /// .|.-X--+.|.
        /// .|..|....|.
        /// .|.......|.
        /// .o-------+.
        /// ...........
        /// In the above example, the intersection closest to the central port is reached after 8+5+5+2 = 20 steps by the first wire and 7+6+4+3 = 20 steps 
        /// by the second wire for a total of 20+20 = 40 steps.
        /// 
        /// However, the top-right intersection is better: the first wire takes only 8+5+2 = 15 and the second wire takes only 7+6+2 = 15, a total of 15+15 = 30 steps.
        /// 
        /// Here are the best steps for the extra examples from above:
        /// 
        /// R75,D30,R83,U83,L12,D49,R71,U7,L72
        /// U62, R66, U55, R34, D71, R55, D58, R83 = 610 steps
        /// R98, U47, R26, D63, R33, U87, L62, D20, R33, U53, R51
        /// U98,R91,D20,R16,D67,R40,U7,R15,U6,R7 = 410 steps
        /// What is the fewest combined steps the wires must take to reach an intersection?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            int r = int.MaxValue;

            int x = 0, y = 0;
            int x0 = 0, y0 = 0;

            List<string> dir = [.. input[0].Split(',')];
            List<string> dir0 = [.. input[1].Split(',')];

            List<((int, int), int)> a = [((0, 0), 0)];
            List<((int, int), int)> a0 = [((0, 0), 0)];
            HashSet<((int, int), int)> b = [];
            int c = 0;
            foreach (string item in dir)
            {
                char d = item[0];
                int z = int.Parse(item[1..]);

                switch (d)
                {
                    case 'U':
                        for (int i = 0; i < z; i++)
                        {
                            c++;
                            x--;
                            a.Add(((x, y), c));
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < z; i++)
                        {
                            c++;
                            x++;
                            a.Add(((x, y), c));
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < z; i++)
                        {
                            c++;
                            y--;
                            a.Add(((x, y), c));
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < z; i++)
                        {
                            c++;
                            y++;
                            a.Add(((x, y), c));
                        }
                        break;
                    default:
                        break;
                }
            }

            int c0 = 0;
            foreach (string item in dir0)
            {
                char d = item[0];
                int z = int.Parse(item[1..]);

                switch (d)
                {
                    case 'U':
                        for (int i = 0; i < z; i++)
                        {
                            c0++;
                            x0--;
                            a0.Add(((x0, y0), c0));
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < z; i++)
                        {
                            c0++;
                            x0++;
                            a0.Add(((x0, y0), c0));
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < z; i++)
                        {
                            c0++;
                            y0--;
                            a0.Add(((x0, y0), c0));
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < z; i++)
                        {
                            c0++;
                            y0++;
                            a0.Add(((x0, y0), c0));
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (((int, int), int) item in a)
            {
                foreach (((int, int), int) item1 in a0)
                {
                    if (item.Item1.Item1 == item1.Item1.Item1 && item.Item1.Item2 == item1.Item1.Item2) b.Add(((item.Item1.Item1, item.Item1.Item2), item.Item2 + item1.Item2));
                }
            }
            b.Remove(((0, 0), 0));

            foreach (((int, int), int) item in b)
            {
                r = Math.Min(r, item.Item2);
                Console.WriteLine($"{item.Item1} {item.Item2}");
            }

            return r;
        }

        private static int Dist(int x0, int y0, int x1, int y1)
        {
            return Math.Abs(x0 - x1) + Math.Abs(y0 - y1);
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _03_CrossedWires(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_03_CrossedWires));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}