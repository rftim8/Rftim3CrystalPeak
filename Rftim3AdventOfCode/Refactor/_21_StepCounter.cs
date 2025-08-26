using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace Rftim3AdventOfCode.Refactor
{
    public class _21_StepCounter : I_21_StepCounter
    {
        #region Static
        private readonly List<string>? data;

        public _21_StepCounter()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_21_StepCounter));
        }

        /// <summary>
        /// You manage to catch the airship right as it's dropping someone else off on their all-expenses-paid trip to Desert Island! 
        /// It even helpfully drops you off near the gardener and his massive farm.
        /// 
        /// "You got the sand flowing again! Great work! 
        /// Now we just need to wait until we have enough sand to filter the water for Snow Island and we'll have snow again in no time."
        /// 
        /// While you wait, one of the Elves that works with the gardener heard how good you are at solving problems and would like your help.
        /// He needs to get his steps in for the day, and so he'd like to know which garden plots he can reach with exactly his remaining 64 steps.
        /// 
        /// He gives you an up-to-date map (your puzzle input) of his starting position(S), garden plots(.), and rocks(#). For example:
        /// 
        /// ...........
        /// .....###.#.
        /// .###.##..#.
        /// ..#.#...#..
        /// ....#.#....
        /// .##..S####.
        /// .##..#...#.
        /// .......##..
        /// .##.#.####.
        /// .##..##.##.
        /// ...........
        /// The Elf starts at the starting position (S) which also counts as a garden plot.
        /// Then, he can take one step north, south, east, or west, but only onto tiles that are garden plots.
        /// This would allow him to reach any of the tiles marked O:
        /// 
        /// ...........
        /// .....###.#.
        /// .###.##..#.
        /// ..#.#...#..
        /// ....#O#....
        /// .##.OS####.
        /// .##..#...#.
        /// .......##..
        /// .##.#.####.
        /// .##..##.##.
        /// ...........
        /// Then, he takes a second step.
        /// Since at this point he could be at either tile marked O, his second step would allow him to reach any garden plot that is one step north, south, east, or west 
        /// of any tile that he could have reached after the first step:
        /// 
        /// ...........
        /// .....###.#.
        /// .###.##..#.
        /// ..#.#O..#..
        /// ....#.#....
        /// .##O.O####.
        /// .##.O#...#.
        /// .......##..
        /// .##.#.####.
        /// .##..##.##.
        /// ...........
        /// After two steps, he could be at any of the tiles marked O above, including the starting position (either by going north-then-south or by going west-then-east).
        /// 
        /// A single third step leads to even more possibilities:
        /// 
        /// ...........
        /// .....###.#.
        /// .###.##..#.
        /// ..#.#.O.#..
        /// ...O#O#....
        /// .##.OS####.
        /// .##O.#...#.
        /// ....O..##..
        /// .##.#.####.
        /// .##..##.##.
        /// ...........
        /// He will continue like this until his steps for the day have been exhausted.After a total of 6 steps, he could reach any of the garden plots marked O:
        /// 
        /// ...........
        /// .....###.#.
        /// .###.##.O#.
        /// .O#O#O.O#..
        /// O.O.#.#.O..
        /// .##O.O####.
        /// .##.O#O..#.
        /// .O.O.O.##..
        /// .##.#.####.
        /// .##O.##.##.
        /// ...........
        /// In this example, if the Elf's goal was to get exactly 6 more steps today, he could use them to reach any of 16 garden plots.
        /// 
        /// However, the Elf actually needs to get 64 steps today, and the map he's handed you is much larger than the example map.
        /// 
        /// Starting from the garden plot marked S on your map, how many garden plots could the Elf reach in exactly 64 steps?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input0)
        {
            List<string> input = [.. input0];
            int n = input.Count;
            int m = input[0].Length;
            int r = 0;

            Point orig = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (input[i][j] == 'S')
                    {
                        orig = new(i, j);
                        StringBuilder sb = new(input[i]);
                        sb[j] = 'O';
                        input[i] = sb.ToString();
                        i = n;
                        break;
                    }
                }
            }

            string border = string.Concat(Enumerable.Repeat('X', n + 2));
            for (int i = 0; i < n; i++)
            {
                input[i] = $"X{input[i]}X";
            }
            input.Insert(0, border);
            input.Add(border);

            n += 2;
            m += 2;

            for (int i = 0; i < 64; i++)
            {
                input = [.. Spread(input, n, m, orig)];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (input[i][j] == 'O') r++;
                }
            }

            return r;
        }

        /// <summary>
        /// The Elf seems confused by your answer until he realizes his mistake: he was reading from a list of his favorite numbers that are both perfect squares and perfect cubes,
        /// not his step counter.
        /// 
        /// The actual number of steps he needs to get today is exactly 26501365.
        /// 
        /// He also points out that the garden plots and rocks are set up so that the map repeats infinitely in every direction.
        /// 
        /// So, if you were to look one additional map-width or map-height out from the edge of the example map above, you would find that it keeps repeating:
        /// 
        /// .................................
        /// .....###.#......###.#......###.#.
        /// .###.##..#..###.##..#..###.##..#.
        /// ..#.#...#....#.#...#....#.#...#..
        /// ....#.#........#.#........#.#....
        /// .##...####..##...####..##...####.
        /// .##..#...#..##..#...#..##..#...#.
        /// .......##.........##.........##..
        /// .##.#.####..##.#.####..##.#.####.
        /// .##..##.##..##..##.##..##..##.##.
        /// .................................
        /// .................................
        /// .....###.#......###.#......###.#.
        /// .###.##..#..###.##..#..###.##..#.
        /// ..#.#...#....#.#...#....#.#...#..
        /// ....#.#........#.#........#.#....
        /// .##...####..##..S####..##...####.
        /// .##..#...#..##..#...#..##..#...#.
        /// .......##.........##.........##..
        /// .##.#.####..##.#.####..##.#.####.
        /// .##..##.##..##..##.##..##..##.##.
        /// .................................
        /// .................................
        /// .....###.#......###.#......###.#.
        /// .###.##..#..###.##..#..###.##..#.
        /// ..#.#...#....#.#...#....#.#...#..
        /// ....#.#........#.#........#.#....
        /// .##...####..##...####..##...####.
        /// .##..#...#..##..#...#..##..#...#.
        /// .......##.........##.........##..
        /// .##.#.####..##.#.####..##.#.####.
        /// .##..##.##..##..##.##..##..##.##.
        /// .................................
        /// This is just a tiny three-map-by-three-map slice of the inexplicably-infinite farm layout; garden plots and rocks repeat as far as you can see.
        /// The Elf still starts on the one middle tile marked S, though - every other repeated S is replaced with a normal garden plot(.).
        /// 
        /// Here are the number of reachable garden plots in this new infinite version of the example map for different numbers of steps:
        /// 
        /// In exactly 6 steps, he can still reach 16 garden plots.
        /// In exactly 10 steps, he can reach any of 50 garden plots.
        /// In exactly 50 steps, he can reach 1594 garden plots.
        /// In exactly 100 steps, he can reach 6536 garden plots.
        /// In exactly 500 steps, he can reach 167004 garden plots.
        /// In exactly 1000 steps, he can reach 668697 garden plots.
        /// In exactly 5000 steps, he can reach 16733044 garden plots.
        /// However, the step count the Elf needs is much larger! Starting from the garden plot marked S on your infinite map, how many garden plots could the Elf reach in exactly 26501365 steps?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            int steps = 26501365;
            Dictionary<Complex, char> map = ParseMap(input);
            Complex s = map.Keys.Single(k => map[k] == 'S');
            Complex br = map.Keys.MaxBy(pos => pos.Real + pos.Imaginary);
            int loop = 260;

            Complex center = new(65, 65);

            Complex[] corners = [
                new Complex(0, 0),
                new Complex(0, 130),
                new Complex(130, 130),
                new Complex(130, 0),
            ];

            Complex[] middles = [
                new Complex(65, 0),
                new Complex(65, 130),
                new Complex(0, 65),
                new Complex(130, 65),
            ];
            Dictionary<Complex, long[]> cohorts = new()
            {
                [center] = new long[loop + 1]
            };

            foreach (Complex corner in corners)
            {
                cohorts[corner] = new long[loop + 1];
            }

            foreach (Complex middle in middles)
            {
                cohorts[middle] = new long[loop + 1];
            }

            int m = 0;
            cohorts[center][m] = 1;
            int phaseLength = loop + 1;

            for (int i = 1; i <= steps; i++)
            {

                int nextM = (m + phaseLength - 1) % phaseLength;
                foreach (Complex item in cohorts.Keys)
                {
                    long[] phase = cohorts[item];
                    long a = phase[(m + phase.Length - 1) % phase.Length];
                    long b = phase[(m + phase.Length - 2) % phase.Length];
                    long c = phase[(m + phase.Length - 3) % phase.Length];

                    phase[nextM] = 0;
                    phase[(nextM + phase.Length - 1) % phase.Length] = b;
                    phase[(nextM + phase.Length - 2) % phase.Length] = a + c;
                }
                m = nextM;

                if (i >= 132 && (i - 132) % 131 == 0)
                {
                    int newItems = i / 131;
                    foreach (Complex corner in corners)
                    {
                        cohorts[corner][m] += newItems;
                    }
                }
                else if (i >= 66 && (i - 66) % 131 == 0)
                {
                    foreach (Complex middle in middles)
                    {
                        cohorts[middle][m]++;
                    }
                }
            }

            long res = 0L;

            foreach (Complex item in cohorts.Keys)
            {
                long[] phase = cohorts[item];
                HashSet<Complex> pos = [item];
                for (int i = 0; i < phase.Length; i++)
                {
                    long count = phase[(m + i) % phase.Length];
                    res += pos.Count * count;
                    pos = Step(map, pos);
                }
            }

            return res;
        }

        private static List<string> Spread(List<string> input, int n, int m, Point orig)
        {
            List<Point> points = [];
            List<Point> dest = [];

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < m - 1; j++)
                {
                    if (input[i][j] == 'O')
                    {
                        points.Add(new(i, j));
                    }
                }
            }

            foreach (Point item in points)
            {
                bool f = false;
                if (input[item.X - 1][item.Y] == '.')
                {
                    dest.Add(new(item.X - 1, item.Y));
                    f = true;
                }
                if (input[item.X + 1][item.Y] == '.')
                {
                    dest.Add(new(item.X + 1, item.Y));
                    f = true;
                }
                if (input[item.X][item.Y - 1] == '.')
                {
                    dest.Add(new(item.X, item.Y - 1));
                    f = true;
                }
                if (input[item.X][item.Y + 1] == '.')
                {
                    dest.Add(new(item.X, item.Y + 1));
                    f = true;
                }

                if (f)
                {
                    StringBuilder sb = new(input[item.X]);
                    sb[item.Y] = '.';
                    input[item.X] = sb.ToString();
                }
            }

            foreach (Point item in dest)
            {
                StringBuilder sb = new(input[item.X]);
                sb[item.Y] = 'O';
                input[item.X] = sb.ToString();
            }

            return input;
        }

        private static HashSet<Complex> Step(Dictionary<Complex, char> map, HashSet<Complex> pos)
        {
            HashSet<Complex> res = [];
            foreach (Complex p in pos)
            {
                foreach (Complex dir in new Complex[] { 1, -1, Complex.ImaginaryOne, -Complex.ImaginaryOne })
                {
                    Complex pT = p + dir;
                    if (map.TryGetValue(pT, out char value) && value != '#') res.Add(pT);
                }
            }

            return res;
        }

        private static Dictionary<Complex, char> ParseMap(List<string> lines)
        {
            return (
                from irow in Enumerable.Range(0, lines.Count)
                from icol in Enumerable.Range(0, lines[0].Length)
                select new KeyValuePair<Complex, char>(
                    new Complex(icol, irow), lines[irow][icol]
                )
            ).ToDictionary();
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _21_StepCounter(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_21_StepCounter));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}