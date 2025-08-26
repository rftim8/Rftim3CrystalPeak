using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _06_GuardGallivant : I_06_GuardGallivant
    {
        #region Static
        private readonly List<string>? data;

        public _06_GuardGallivant()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_06_GuardGallivant));
        }

        /// <summary>
        /// The Historians use their fancy device again, this time to whisk you all away to the North Pole prototype suit manufacturing lab... in the year 1518! 
        /// It turns out that having direct access to history is very convenient for a group of historians.
        /// You still have to be careful of time paradoxes, and so it will be important to avoid anyone from 1518 while The Historians search for the Chief.
        /// Unfortunately, a single guard is patrolling this part of the lab.
        /// Maybe you can work out where the guard will go ahead of time so that The Historians can search safely?
        /// You start by making a map (your puzzle input) of the situation.
        /// For example:
        /// 
        /// ....#.....
        /// .........#
        /// ..........
        /// ..#.......
        /// .......#..
        /// ..........
        /// .#..^.....
        /// ........#.
        /// #.........
        /// ......#...
        /// 
        /// The map shows the current position of the guard with ^ (to indicate the guard is currently facing up from the perspective of the map). 
        /// Any obstructions - crates, desks, alchemical reactors, etc. - are shown as #.
        /// Lab guards in 1518 follow a very strict patrol protocol which involves repeatedly following these steps:
        /// If there is something directly in front of you, turn right 90 degrees.
        /// Otherwise, take a step forward.
        /// Following the above protocol, the guard moves up several times until she reaches an obstacle (in this case, a pile of failed suit prototypes):
        /// 
        /// ....#.....
        /// ....^....#
        /// ..........
        /// ..#.......
        /// .......#..
        /// ..........
        /// .#........
        /// ........#.
        /// #.........
        /// ......#...
        /// Because there is now an obstacle in front of the guard, she turns right before continuing straight in her new facing direction:
        /// 
        /// ....#.....
        /// ........>#
        /// ..........
        /// ..#.......
        /// .......#..
        /// ..........
        /// .#........
        /// ........#.
        /// #.........
        /// ......#...
        /// Reaching another obstacle(a spool of several very long polymers), she turns right again and continues downward:
        /// 
        /// ....#.....
        /// .........#
        /// ..........
        /// ..#.......
        /// .......#..
        /// ..........
        /// .#......v.
        /// ........#.
        /// #.........
        /// ......#...
        /// This process continues for a while, but the guard eventually leaves the mapped area(after walking past a tank of universal solvent):
        /// 
        /// ....#.....
        /// .........#
        /// ..........
        /// ..#.......
        /// .......#..
        /// ..........
        /// .#........
        /// ........#.
        /// #.........
        /// ......#v..
        /// By predicting the guard's route, you can determine which specific positions in the lab will be in the patrol path. 
        /// Including the guard's starting position, the positions visited by the guard before leaving the area are marked with an X:
        /// 
        /// ....#.....
        /// ....XXXXX#
        /// ....X...X.
        /// ..#.X...X.
        /// ..XXXXX#X.
        /// ..X.X.X.X.
        /// .#XXXXXXX.
        /// .XXXXXXX#.
        /// #XXXXXXX..
        /// ......#X..
        /// In this example, the guard will visit 41 distinct positions on your map.
        /// 
        /// Predict the path of the guard. How many distinct positions will the guard visit before leaving the mapped area?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            List<string> l = [.. input];
            int x = 0;
            int y = 0;

            int a = l.Count;
            int b = l[0].Length;

            for (int i = 0; i < a; i++)
            {
                l[i] = $",{l[i]},";
            }

            string s = "";
            for (int i = 0; i < b + 2; i++)
            {
                s += ",";
            }

            l.Insert(0, s);
            l.Add(s);

            for (int i = 0; i < a + 2; i++)
            {
                for (int j = 0; j < b + 2; j++)
                {
                    if (l[i][j] == '^')
                    {
                        x = i;
                        y = j;
                    }
                }
            }


            List<string> l0 = [.. l];
            HashSet<(int, int)> loc = [];

            while (l[x][y] != ',')
            {
                if (l[x][y] == '^')
                {
                    l0[x] = $"{l0[x][..y]}X{l0[x][(y + 1)..]}";
                    loc.Add((x, y));

                    if (l[x - 1][y] == '#')
                        l[x] = $"{l[x][..y]}>{l[x][(y + 1)..]}";
                    else if (l[x - 1][y] == '.')
                    {
                        l[x] = $"{l[x][..y]}.{l[x][(y + 1)..]}";
                        l[x - 1] = $"{l[x - 1][..y]}^{l[x - 1][(y + 1)..]}";
                    }

                    if (l[x - 1][y] != '#')
                        x -= 1;
                }
                else if (l[x][y] == '>')
                {
                    l0[x] = $"{l0[x][..y]}X{l0[x][(y + 1)..]}";
                    loc.Add((x, y));

                    if (l[x][y + 1] == '#')
                        l[x] = $"{l[x][..y]}v{l[x][(y + 1)..]}";
                    else if (l[x][y + 1] == '.')
                    {
                        l[x] = $"{l[x][..y]}.{l[x][(y + 1)..]}";
                        l[x] = $"{l[x][..(y + 1)]}>{l[x][(y + 2)..]}";
                    }

                    if (l[x][y + 1] != '#')
                        y += 1;
                }
                else if (l[x][y] == 'v')
                {
                    l0[x] = $"{l0[x][..y]}X{l0[x][(y + 1)..]}";
                    loc.Add((x, y));

                    if (l[x + 1][y] == '#')
                        l[x] = $"{l[x][..y]}<{l[x][(y + 1)..]}";
                    else if (l[x + 1][y] == '.')
                    {
                        l[x] = $"{l[x][..y]}.{l[x][(y + 1)..]}";
                        l[x + 1] = $"{l[x + 1][..y]}v{l[x + 1][(y + 1)..]}";
                    }

                    if (l[x + 1][y] != '#')
                        x += 1;
                }
                else if (l[x][y] == '<')
                {
                    l0[x] = $"{l0[x][..y]}X{l0[x][(y + 1)..]}";
                    loc.Add((x, y));

                    if (l[x][y - 1] == '#')
                        l[x] = $"{l[x][..y]}^{l[x][(y + 1)..]}";
                    else if (l[x][y - 1] == '.')
                    {
                        l[x] = $"{l[x][..y]}.{l[x][(y + 1)..]}";
                        l[x] = $"{l[x][..(y - 1)]}<{l[x][y..]}";
                    }

                    if (l[x][y - 1] != '#')
                        y -= 1;
                }
            }

            int res = loc.Count;
            return res;
        }

        /// <summary>
        /// While The Historians begin working around the guard's patrol route, you borrow their fancy device and step outside the lab. 
        /// From the safety of a supply closet, you time travel through the last few months and record the nightly status of the lab's guard post on the walls of the closet.
        /// Returning after what seems like only a few seconds to The Historians, they explain that the guard's patrol area is simply too large for them to safely search the lab without getting caught.
        /// Fortunately, they are pretty sure that adding a single new obstruction won't cause a time paradox. 
        /// They'd like to place the new obstruction in such a way that the guard will get stuck in a loop, making the rest of the lab safe to search.
        /// To have the lowest chance of creating a time paradox, The Historians would like to know all of the possible positions for such an obstruction.
        /// The new obstruction can't be placed at the guard's starting position - the guard is there right now and would notice.
        /// In the above example, there are only 6 different positions where a new obstruction would cause the guard to get stuck in a loop.
        /// The diagrams of these six situations use O to mark the new obstruction, | to show a position where the guard moves up/down, - to show a position where the guard moves left/right, 
        /// and + to show a position where the guard moves both up/down and left/right.
        /// Option one, put a printing press next to the guard's starting position:
        /// 
        /// ....#.....
        /// ....+---+#
        /// ....|...|.
        /// ..#.|...|.
        /// ....|..#|.
        /// ....|...|.
        /// .#.O^---+.
        /// ........#.
        /// #.........
        /// ......#...
        /// Option two, put a stack of failed suit prototypes in the bottom right quadrant of the mapped area:
        /// 
        /// 
        /// ....#.....
        /// ....+---+#
        /// ....|...|.
        /// ..#.|...|.
        /// ..+-+-+#|.
        /// ..|.|.|.|.
        /// .#+-^-+-+.
        /// ......O.#.
        /// #.........
        /// ......#...
        /// Option three, put a crate of chimney-squeeze prototype fabric next to the standing desk in the bottom right quadrant:
        /// 
        /// ....#.....
        /// ....+---+#
        /// ....|...|.
        /// ..#.|...|.
        /// ..+-+-+#|.
        /// ..|.|.|.|.
        /// .#+-^-+-+.
        /// .+----+O#.
        /// #+----+...
        /// ......#...
        /// Option four, put an alchemical retroencabulator near the bottom left corner:
        /// 
        /// ....#.....
        /// ....+---+#
        /// ....|...|.
        /// ..#.|...|.
        /// ..+-+-+#|.
        /// ..|.|.|.|.
        /// .#+-^-+-+.
        /// ..|...|.#.
        /// #O+---+...
        /// ......#...
        /// Option five, put the alchemical retroencabulator a bit to the right instead:
        /// 
        /// ....#.....
        /// ....+---+#
        /// ....|...|.
        /// ..#.|...|.
        /// ..+-+-+#|.
        /// ..|.|.|.|.
        /// .#+-^-+-+.
        /// ....|.|.#.
        /// #..O+-+...
        /// ......#...
        /// Option six, put a tank of sovereign glue right next to the tank of universal solvent:
        /// 
        /// ....#.....
        /// ....+---+#
        /// ....|...|.
        /// ..#.|...|.
        /// ..+-+-+#|.
        /// ..|.|.|.|.
        /// .#+-^-+-+.
        /// .+----++#.
        /// #+----++..
        /// ......#O..
        /// It doesn't really matter what you choose to use as an obstacle so long as you and The Historians can put it into position without the guard noticing. 
        /// The important thing is having enough options that you can find one that minimizes time paradoxes, and in this example, there are 6 different positions you could choose.
        /// You need to get the guard stuck in a loop by adding a single new obstruction.How many different positions could you choose for this obstruction?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            List<string> l = [.. input];
            int p2 = 0;
            int p1 = 0;

            int x = l.Count;
            int y = l[0].Length;
            int sr = 0;
            int sc = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (l[i][j] == '^')
                        (sr, sc) = (i, j);
                }
            }

            for (int o_r = 0; o_r < x; o_r++)
            {
                for (int o_c = 0; o_c < y; o_c++)
                {
                    (int r, int c) = (sr, sc);
                    int d = 0;
                    HashSet<(int, int, int)> obs = [];
                    HashSet<(int, int)> steps = [];

                    while (true)
                    {
                        if (obs.Contains((r, c, d)))
                        {
                            p2 += 1;
                            break;
                        }

                        obs.Add((r, c, d));
                        steps.Add((r, c));
                        List<(int, int)> q = [(-1, 0), (0, 1), (1, 0), (0, -1)];
                        (int dr, int dc) = q[d];
                        int rr = r + dr;
                        int cc = c + dc;

                        if (!(0 <= rr && rr < x && 0 <= cc && cc < y))
                        {
                            if (l[o_r][o_c] == '#')
                                p1 = steps.Count;
                            break;
                        }

                        if (l[rr][cc] == '#' || rr == o_r && cc == o_c)
                            d = (d + 1) % 4;
                        else
                        {
                            r = rr;
                            c = cc;
                        }
                    }
                }
            }

            Console.WriteLine($"Part one: {p1}");
            return p2;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _06_GuardGallivant(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_06_GuardGallivant));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}