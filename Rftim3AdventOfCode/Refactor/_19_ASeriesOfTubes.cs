using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _19_ASeriesOfTubes : I_19_ASeriesOfTubes
    {
        #region Static
        private readonly List<string>? data;

        public _19_ASeriesOfTubes()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_19_ASeriesOfTubes));
        }

        /// <summary>
        /// Somehow, a network packet got lost and ended up here. It's trying to follow a routing diagram (your puzzle input), but it's confused about where to go.
        /// 
        /// Its starting point is just off the top of the diagram.Lines(drawn with |, -, and +) show the path it needs to take, 
        /// starting by going down onto the only line connected to the top of the diagram.
        /// It needs to follow this path until it reaches the end(located somewhere within the diagram) and stop there.
        /// 
        /// Sometimes, the lines cross over each other; in these cases, it needs to continue going the same direction, and only turn left or right when there's no other option. 
        /// In addition, someone has left letters on the line; these also don't change its direction, but it can use them to keep track of where it's been. For example:
        /// 
        ///      |          
        ///      |  +--+    
        ///      A  |  C
        ///  F---|----E|--+ 
        ///      |  |  |  D 
        ///      +B-+  +--+ 
        /// 
        /// Given this diagram, the packet needs to take the following path:
        /// 
        /// Starting at the only line touching the top of the diagram, it must go down, pass through A, and continue onward to the first +.
        /// Travel right, up, and right, passing through B in the process.
        /// Continue down (collecting C), right, and up (collecting D).
        /// Finally, go all the way left through E and stopping at F.
        /// Following the path to the end, the letters it sees on its path are ABCDEF.
        /// The little packet looks up at you, hoping you can help it find the way.
        /// What letters will it see (in the order it would see them) if it follows the path? (The routing diagram is very wide; make sure you view it without line wrapping.)
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            string[] map = [.. input];
            (int y, int x) pos = (y: 0, x: map[0].IndexOf('|'));
            (int, int) dir = (1, 0);
            string word = "";
            int steps = 1;

            while (map[pos.y][pos.x] == '-' || map[pos.y][pos.x] == '|')
            {
                pos = applyMov(pos.y, pos.x);
                steps++;
                if (char.IsLetter(map[pos.y][pos.x]))
                {
                    word += map[pos.y][pos.x];
                    pos = applyMov(pos.y, pos.x);

                    if (map[pos.y][pos.x] == ' ') break;
                    else steps++;
                }
                else if (map[pos.y][pos.x] == '+')
                {
                    pos = makeTurn(pos.y, pos.x);
                    steps++;
                }
            }

            (int y, int x) lastPos;
            ValueTuple<int, int> applyMov(int y, int x)
            {
                lastPos = (y, x);
                return (y + dir.Item1, x + dir.Item2);
            }

            ValueTuple<int, int> makeTurn(int y, int x)
            {
                if (map[y + 1][x] != ' ' && !(y + 1, x).Equals(lastPos))
                {
                    dir = (1, 0);
                    return (y + 1, x);
                }
                else if (map[y - 1][x] != ' ' && !(y - 1, x).Equals(lastPos))
                {
                    dir = (-1, 0);
                    return (y - 1, x);
                }
                else if (map[y][x + 1] != ' ' && !(y, x + 1).Equals(lastPos))
                {
                    dir = (0, 1);
                    return (y, x + 1);
                }
                else if (map[y][x - 1] != ' ' && !(y, x - 1).Equals(lastPos))
                {
                    dir = (0, -1);
                    return (y, x - 1);
                }
                else return (-99, -99);
            }

            return word;
        }

        /// <summary>
        /// The packet is curious how many steps it needs to go.
        /// 
        /// For example, using the same routing diagram from the example above...
        /// 
        ///      |          
        ///      |  +--+    
        ///      A  |  C
        ///  F---|--|-E---+ 
        ///      |  |  |  D 
        ///      +B-+  +--+ 
        /// 
        /// ...the packet would go:
        /// 
        /// 6 steps down(including the first line at the top of the diagram).
        /// 3 steps right.
        /// 4 steps up.
        /// 3 steps right.
        /// 4 steps down.
        /// 3 steps right.
        /// 2 steps up.
        /// 13 steps left (including the F it stops on).
        /// This would result in a total of 38 steps.
        /// 
        /// How many steps does the packet need to go?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            string[] map = [.. input];
            (int y, int x) pos = (y: 0, x: map[0].IndexOf('|'));
            (int, int) dir = (1, 0);
            string word = "";
            int steps = 1;

            while (map[pos.y][pos.x] == '-' || map[pos.y][pos.x] == '|')
            {
                pos = applyMov(pos.y, pos.x);
                steps++;
                if (char.IsLetter(map[pos.y][pos.x]))
                {
                    word += map[pos.y][pos.x];
                    pos = applyMov(pos.y, pos.x);

                    if (map[pos.y][pos.x] == ' ') break;
                    else steps++;
                }
                else if (map[pos.y][pos.x] == '+')
                {
                    pos = makeTurn(pos.y, pos.x);
                    steps++;
                }
            }

            (int y, int x) lastPos;
            ValueTuple<int, int> applyMov(int y, int x)
            {
                lastPos = (y, x);
                return (y + dir.Item1, x + dir.Item2);
            }

            ValueTuple<int, int> makeTurn(int y, int x)
            {
                if (map[y + 1][x] != ' ' && !(y + 1, x).Equals(lastPos))
                {
                    dir = (1, 0);
                    return (y + 1, x);
                }
                else if (map[y - 1][x] != ' ' && !(y - 1, x).Equals(lastPos))
                {
                    dir = (-1, 0);
                    return (y - 1, x);
                }
                else if (map[y][x + 1] != ' ' && !(y, x + 1).Equals(lastPos))
                {
                    dir = (0, 1);
                    return (y, x + 1);
                }
                else if (map[y][x - 1] != ' ' && !(y, x - 1).Equals(lastPos))
                {
                    dir = (0, -1);
                    return (y, x - 1);
                }
                else return (-99, -99);
            }

            return steps;
        }
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _19_ASeriesOfTubes(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_19_ASeriesOfTubes));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}