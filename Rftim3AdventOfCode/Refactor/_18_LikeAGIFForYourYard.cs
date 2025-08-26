using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _18_LikeAGIFForYourYard : I_18_LikeAGIFForYourYard
    {
        #region Static
        private readonly List<string>? data;

        public _18_LikeAGIFForYourYard()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_18_LikeAGIFForYourYard));
        }

        /// <summary>
        /// After the million lights incident, the fire code has gotten stricter: now, at most ten thousand lights are allowed. You arrange them in a 100x100 grid.
        /// Never one to let you down, Santa again mails you instructions on the ideal lighting configuration.With so few lights, he says, you'll have to resort to animation.
        /// Start by setting your lights to the included initial configuration(your puzzle input). A # means "on", and a . means "off".
        /// Then, animate your grid in steps, where each step decides the next configuration based on the current one.
        /// Each light's next state (either on or off) depends on its current state and the current states of the eight lights adjacent to it (including diagonals). 
        /// Lights on the edge of the grid might have fewer than eight neighbors; the missing ones always count as "off".
        /// 
        /// For example, in a simplified 6x6 grid, the light marked A has the neighbors numbered 1 through 8, and the light marked B, 
        /// which is on an edge, only has the neighbors marked 1 through 5:
        /// 
        /// 1B5...
        /// 234...
        /// ......
        /// ..123.
        /// ..8A4.
        /// ..765.
        /// 
        /// The state a light should have next is based on its current state(on or off) plus the number of neighbors that are on:
        /// 
        /// A light which is on stays on when 2 or 3 neighbors are on, and turns off otherwise.
        /// A light which is off turns on if exactly 3 neighbors are on, and stays off otherwise.
        /// All of the lights update simultaneously; they all consider the same current state before moving to the next.
        /// 
        /// Here's a few steps from an example configuration of another 6x6 grid:
        /// 
        /// Initial state:
        /// .#.#.#
        /// ...##.
        /// #....#
        /// ..#...
        /// #.#..#
        /// ####..
        /// 
        /// After 1 step:
        /// ..##..
        /// ..##.#
        /// ...##.
        /// ......
        /// #.....
        /// #.##..
        /// 
        /// After 2 steps:
        /// ..###.
        /// ......
        /// ..###.
        /// ......
        /// .#....
        /// .#....
        /// 
        /// After 3 steps:
        /// ...#..
        /// ......
        /// ...#..
        /// ..##..
        /// ......
        /// ......
        /// 
        /// After 4 steps:
        /// ......
        /// ......
        /// ..##..
        /// ..##..
        /// ......
        /// ......
        /// After 4 steps, this example has four lights on.
        /// 
        /// In your grid of 100x100 lights, given your initial configuration, how many lights are on after 100 steps?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<string> r = [];

            for (int i = 0; i < input.Count; i++)
            {
                if (i == 0)
                {
                    string x = string.Empty;
                    for (int j = 0; j < input[i].Length + 2; j++)
                    {
                        x += '-';
                    }
                    r.Add(x);
                    r.Add($"-{input[i]}-");
                }
                else if (i == input.Count - 1)
                {
                    r.Add($"-{input[i]}-");
                    string x = string.Empty;
                    for (int j = 0; j < input[i].Length + 2; j++)
                    {
                        x += '-';
                    }
                    r.Add(x);
                }
                else r.Add($"-{input[i]}-");
            }

            List<string> s = [.. r];

            for (int k = 0; k < 100; k++)
            {
                for (int i = 1; i <= 100; i++)
                {
                    for (int j = 1; j <= 100; j++)
                    {
                        int c = 0;

                        if (r[i][j] == '#')
                        {
                            if (r[i][j + 1] == '#') c++;
                            if (r[i][j - 1] == '#') c++;
                            if (r[i + 1][j] == '#') c++;
                            if (r[i - 1][j] == '#') c++;
                            if (r[i + 1][j + 1] == '#') c++;
                            if (r[i - 1][j + 1] == '#') c++;
                            if (r[i + 1][j - 1] == '#') c++;
                            if (r[i - 1][j - 1] == '#') c++;
                            if (c != 2 && c != 3) s[i] = $"{s[i][..j]}.{s[i][(j + 1)..]}";
                        }
                        else
                        {
                            if (r[i][j + 1] == '#') c++;
                            if (r[i][j - 1] == '#') c++;
                            if (r[i + 1][j] == '#') c++;
                            if (r[i - 1][j] == '#') c++;
                            if (r[i + 1][j + 1] == '#') c++;
                            if (r[i - 1][j + 1] == '#') c++;
                            if (r[i + 1][j - 1] == '#') c++;
                            if (r[i - 1][j - 1] == '#') c++;
                            if (c == 3) s[i] = $"{s[i][..j]}#{s[i][(j + 1)..]}";
                        }
                    }
                }

                r.Clear();
                r.AddRange(s);
            }

            int q = 0;

            foreach (string item in r)
            {
                q += item.Split("#").Length - 1;
            }

            return q;
        }

        /// <summary>
        /// You flip the instructions over; Santa goes on to point out that this is all just an implementation of Conway's Game of Life. 
        /// At least, it was, until you notice that something's wrong with the grid of lights you bought: four lights, one in each corner, 
        /// are stuck on and can't be turned off. The example above will actually run like this:
        /// 
        /// Initial state:
        /// ##.#.#
        /// ...##.
        /// #....#
        /// ..#...
        /// #.#..#
        /// ####.#
        /// 
        /// After 1 step:
        /// #.##.#
        /// ####.#
        /// ...##.
        /// ......
        /// #...#.
        /// #.####
        /// 
        /// After 2 steps:
        /// #..#.#
        /// #....#
        /// .#.##.
        /// ...##.
        /// .#..##
        /// ##.###
        /// 
        /// After 3 steps:
        /// #...##
        /// ####.#
        /// ..##.#
        /// ......
        /// ##....
        /// ####.#
        /// 
        /// After 4 steps:
        /// #.####
        /// #....#
        /// ...#..
        /// .##...
        /// #.....
        /// #.#..#
        /// 
        /// After 5 steps:
        /// ##.###
        /// .##..#
        /// .##...
        /// .##...
        /// #.#...
        /// ##...#
        /// After 5 steps, this example now has 17 lights on.
        /// 
        /// In your grid of 100x100 lights, given your initial configuration, but with the four corners always in the on state, how many lights are on after 100 steps?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<string> r = [];

            for (int i = 0; i < input.Count; i++)
            {
                if (i == 0)
                {
                    string x = string.Empty;
                    for (int j = 0; j < input[i].Length + 2; j++)
                    {
                        x += '-';
                    }
                    r.Add(x);
                    r.Add($"-#{input[i][1..^1]}#-");
                }
                else if (i == input.Count - 1)
                {
                    r.Add($"-#{input[i][1..^1]}#-");
                    string x = "";
                    for (int j = 0; j < input[i].Length + 2; j++)
                    {
                        x += '-';
                    }
                    r.Add(x);
                }
                else r.Add($"-{input[i]}-");
            }

            List<string> s = [.. r];

            for (int k = 0; k < 100; k++)
            {
                for (int i = 1; i <= 100; i++)
                {
                    for (int j = 1; j <= 100; j++)
                    {
                        int c = 0;

                        switch (i)
                        {
                            case 1 when j == 1:
                            case 1 when j == 100:
                            case 100 when j == 100:
                            case 100 when j == 1:
                                break;
                            default:
                                if (r[i][j] == '#')
                                {
                                    if (r[i][j + 1] == '#') c++;
                                    if (r[i][j - 1] == '#') c++;
                                    if (r[i + 1][j] == '#') c++;
                                    if (r[i - 1][j] == '#') c++;
                                    if (r[i + 1][j + 1] == '#') c++;
                                    if (r[i - 1][j + 1] == '#') c++;
                                    if (r[i + 1][j - 1] == '#') c++;
                                    if (r[i - 1][j - 1] == '#') c++;
                                    if (c != 2 && c != 3) s[i] = $"{s[i][..j]}.{s[i][(j + 1)..]}";
                                }
                                else
                                {
                                    if (r[i][j + 1] == '#') c++;
                                    if (r[i][j - 1] == '#') c++;
                                    if (r[i + 1][j] == '#') c++;
                                    if (r[i - 1][j] == '#') c++;
                                    if (r[i + 1][j + 1] == '#') c++;
                                    if (r[i - 1][j + 1] == '#') c++;
                                    if (r[i + 1][j - 1] == '#') c++;
                                    if (r[i - 1][j - 1] == '#') c++;
                                    if (c == 3) s[i] = $"{s[i][..j]}#{s[i][(j + 1)..]}";
                                }
                                break;
                        }
                    }
                }

                r.Clear();
                r.AddRange(s);
                //Console.Clear();
                //foreach (string item in s)
                //{
                //    Console.WriteLine(item);
                //}
                //Thread.Sleep(1000);
            }

            int q = 0;

            foreach (string item in s)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == '#') q++;
                }
            }

            return q;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _18_LikeAGIFForYourYard(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_18_LikeAGIFForYourYard));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}