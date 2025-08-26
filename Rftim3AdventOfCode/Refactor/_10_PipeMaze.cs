using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Drawing;

namespace Rftim3AdventOfCode.Refactor
{
    public class _10_PipeMaze : I_10_PipeMaze
    {
        #region Static
        private readonly List<string>? data;

        public _10_PipeMaze()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_10_PipeMaze));
        }

        /// <summary>
        /// You use the hang glider to ride the hot air from Desert Island all the way up to the floating metal island. 
        /// This island is surprisingly cold and there definitely aren't any thermals to glide on, so you leave your hang glider behind.
        /// 
        /// You wander around for a while, but you don't find any people or animals. 
        /// However, you do occasionally find signposts labeled "Hot Springs" pointing in a seemingly consistent direction;
        /// maybe you can find someone at the hot springs and ask them where the desert-machine parts are made.
        /// 
        /// The landscape here is alien; even the flowers and trees are made of metal.As you stop to admire some metal grass,
        /// you notice something metallic scurry away in your peripheral vision and jump into a big pipe! It didn't look like any animal you've ever seen; 
        /// if you want a better look, you'll need to get ahead of it.
        /// 
        /// Scanning the area, you discover that the entire field you're standing on is densely packed with pipes; 
        /// it was hard to tell at first because they're the same metallic silver color as the "ground". 
        /// You make a quick sketch of all of the surface pipes you can see(your puzzle input).
        /// 
        /// The pipes are arranged in a two-dimensional grid of tiles:
        /// 
        /// | is a vertical pipe connecting north and south.
        /// - is a horizontal pipe connecting east and west.
        /// L is a 90-degree bend connecting north and east.
        /// J is a 90-degree bend connecting north and west.
        /// 7 is a 90-degree bend connecting south and west.
        /// F is a 90-degree bend connecting south and east.
        /// . is ground; there is no pipe in this tile.
        /// S is the starting position of the animal; there is a pipe on this tile, but your sketch doesn't show what shape the pipe has.
        /// Based on the acoustics of the animal's scurrying, you're confident the pipe that contains the animal is one large, continuous loop.
        /// 
        /// For example, here is a square loop of pipe:
        /// 
        /// .....
        /// .F-7.
        /// .|.|.
        /// .L-J.
        /// .....
        /// If the animal had entered this loop in the northwest corner, the sketch would instead look like this:
        /// 
        /// .....
        /// .S-7.
        /// .|.|.
        /// .L-J.
        /// .....
        /// In the above diagram, the S tile is still a 90-degree F bend: you can tell because of how the adjacent pipes connect to it.
        /// 
        /// Unfortunately, there are also many pipes that aren't connected to the loop! This sketch shows the same loop as above:
        /// 
        /// -L|F7
        /// 7S-7|
        /// L|7||
        /// -L-J|
        /// L|-JF
        /// In the above diagram, you can still figure out which pipes form the main loop: they're the ones connected to S, pipes those pipes connect to, 
        /// pipes those pipes connect to, and so on. 
        /// Every pipe in the main loop connects to its two neighbors (including S, which will have exactly two pipes connecting to it, 
        /// and which is assumed to connect back to those two pipes).
        /// 
        /// Here is a sketch that contains a slightly more complex main loop:
        /// 
        /// ..F7.
        /// .FJ|.
        /// SJ.L7
        /// |F--J
        /// LJ...
        /// Here's the same example sketch with the extra, non-main-loop pipe tiles also shown:
        /// 
        /// 7-F7-
        /// .FJ|7
        /// SJLL7
        /// |F--J
        /// LJ.LJ
        /// If you want to get out ahead of the animal, you should find the tile in the loop that is farthest from the starting position.
        /// Because the animal is in the pipe, it doesn't make sense to measure this by direct distance. 
        /// Instead, you need to find the tile that would take the longest number of steps along the loop to reach from the starting point - regardless 
        /// of which way around the loop the animal went.
        /// 
        /// In the first example with the square loop:
        /// 
        /// .....
        /// .S-7.
        /// .|.|.
        /// .L-J.
        /// .....
        /// You can count the distance each tile in the loop is from the starting point like this:
        /// 
        /// .....
        /// .012.
        /// .1.3.
        /// .234.
        /// .....
        /// In this example, the farthest point from the start is 4 steps away.
        /// 
        /// Here's the more complex loop again:
        /// 
        /// ..F7.
        /// .FJ|.
        /// SJ.L7
        /// |F--J
        /// LJ...
        /// Here are the distances for each tile on that loop:
        /// 
        /// ..45.
        /// .236.
        /// 01.78
        /// 14567
        /// 23...
        /// Find the single giant loop starting at S. How many steps along the loop does it take to get from the starting position to the point farthest from the starting position?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            string[,] grid = new string[input.Count, input[0].Length];

            Point start = new();

            for (int y = 0; y < input.Count; y++)
            {
                string[] line = input[y].ToCharArray().Select(char.ToString).ToArray();

                for (int x = 0; x < line.Length; x++)
                {
                    grid[y, x] = line[x];

                    if (line[x] == "S") start = new Point(x, y);
                }
            }

            Dictionary<string, Pipe> pipeTypes = new()
            {
                ["|"] = new Pipe(0, -1, 0, 1),
                ["-"] = new Pipe(-1, 0, 1, 0),
                ["L"] = new Pipe(0, -1, 1, 0),
                ["J"] = new Pipe(0, -1, -1, 0),
                ["7"] = new Pipe(-1, 0, 0, 1),
                ["F"] = new Pipe(1, 0, 0, 1),
                ["."] = new Pipe(0, 0, 0, 0),
            };

            List<Point> potentials =
            [
                new Point(start.X - 1, start.Y),
                new Point(start.X + 1, start.Y),
                new Point(start.X, start.Y - 1),
                new Point(start.X, start.Y + 1)
             ];

            Point current = new();
            for (int i = 0; i < potentials.Count; i++)
            {
                Point potential = potentials[i];
                if (CanConnect(start.X, start.Y, potential.X, potential.Y, pipeTypes[grid[potential.Y, potential.X]]))
                {
                    current = potential;
                    break;
                }
            }

            Point previous = start;
            long steps = 0;

            int[,] path = new int[grid.GetLength(0), grid.GetLength(1)];
            string[,] pathStr = new string[grid.GetLength(0), grid.GetLength(1)];

            path[start.Y, start.X] = 1;
            pathStr[start.Y, start.X] = "7";

            while (current.X != start.X || current.Y != start.Y)
            {
                Pipe pipe = pipeTypes[grid[current.Y, current.X]];

                path[current.Y, current.X] = 1;
                pathStr[current.Y, current.X] = grid[current.Y, current.X];

                Point next;

                if (current.X + pipe.AX == previous.X && current.Y + pipe.AY == previous.Y) next = new Point(current.X + pipe.BX, current.Y + pipe.BY);
                else next = new Point(current.X + pipe.AX, current.Y + pipe.AY);

                previous = current;
                current = next;
                steps++;
            }

            int resizeFactor = 3;
            int[,] resizedGrid = ScaleUp(pathStr, resizeFactor, pipeTypes);

            DrawMaze(path);

            int totalContained = BFS(resizedGrid) / resizeFactor;
            int[,] scaledDown = ScaleDown(resizedGrid, resizeFactor);

            DrawMaze(scaledDown);

            return (int)Math.Ceiling((float)steps / 2);
        }

        /// <summary>
        /// You quickly reach the farthest point of the loop, but the animal never emerges. Maybe its nest is within the area enclosed by the loop?
        /// 
        /// To determine whether it's even worth taking the time to search for such a nest, you should calculate how many tiles are contained within the loop. For example:
        /// 
        /// ...........
        /// .S-------7.
        /// .|F-----7|.
        /// .||.....||.
        /// .||.....||.
        /// .|L-7.F-J|.
        /// .|..|.|..|.
        /// .L--J.L--J.
        /// ...........
        /// The above loop encloses merely four tiles - the two pairs of. in the southwest and southeast (marked I below). 
        /// The middle.tiles(marked O below) are not in the loop.Here is the same loop again with those regions marked:
        /// 
        /// ...........
        /// .S-------7.
        /// .|F-----7|.
        /// .||OOOOO||.
        /// .||OOOOO||.
        /// .|L-7OF-J|.
        /// .|II|O|II|.
        /// .L--JOL--J.
        /// .....O.....
        /// In fact, there doesn't even need to be a full tile path to the outside for tiles to count as outside the loop - squeezing between pipes is also allowed! 
        /// Here, I is still within the loop and O is still outside the loop:
        /// 
        /// ..........
        /// .S------7.
        /// .|F----7|.
        /// .||OOOO||.
        /// .||OOOO||.
        /// .|L-7F-J|.
        /// .|II||II|.
        /// .L--JL--J.
        /// ..........
        /// In both of the above examples, 4 tiles are enclosed by the loop.
        /// 
        /// Here's a larger example:
        /// 
        /// .F----7F7F7F7F-7....
        /// .|F--7||||||||FJ....
        /// .||.FJ||||||||L7....
        /// FJL7L7LJLJ||LJ.L-7..
        /// L--J.L7...LJS7F-7L7.
        /// ....F-J..F7FJ|L7L7L7
        /// ....L7.F7||L7|.L7L7|
        /// .....|FJLJ|FJ|F7|.LJ
        ///         ....FJL-7.||.||||...
        /// ....L---J.LJ.LJLJ...
        /// The above sketch has many random bits of ground, some of which are in the loop (I) and some of which are outside it (O):
        /// 
        /// OF----7F7F7F7F-7OOOO
        /// O|F--7||||||||FJOOOO
        /// O||OFJ||||||||L7OOOO
        /// FJL7L7LJLJ||LJIL-7OO
        /// L--JOL7IIILJS7F-7L7O
        /// OOOOF-JIIF7FJ|L7L7L7
        /// OOOOL7IF7||L7|IL7L7|
        /// OOOOO|FJLJ|FJ|F7|OLJ
        /// OOOOFJL-7O||O||||OOO
        /// OOOOL---JOLJOLJLJOOO
        /// In this larger example, 8 tiles are enclosed by the loop.
        /// 
        /// Any tile that isn't part of the main loop can count as being enclosed by the loop.
        /// Here's another example with many bits of junk pipe lying around that aren't connected to the main loop at all:
        /// 
        /// FF7FSF7F7F7F7F7F---7
        /// L|LJ||||||||||||F--J
        /// FL-7LJLJ||||||LJL-77
        /// F--JF--7||LJLJ7F7FJ-
        /// L---JF-JLJ.||-FJLJJ7
        /// |F|F-JF---7F7-L7L|7|
        /// |FFJF7L7F-JF7|JL---7
        /// 7-L-JL7||F7|L7F-7F7|
        /// L.L7LFJ|||||FJL7||LJ
        /// L7JLJL-JLJLJL--JLJ.L
        /// Here are just the tiles that are enclosed by the loop marked with I:
        /// 
        /// FF7FSF7F7F7F7F7F---7
        /// L|LJ||||||||||||F--J
        /// FL-7LJLJ||||||LJL-77
        /// F--JF--7||LJLJIF7FJ-
        /// L---JF-JLJIIIIFJLJJ7
        /// |F|F-JF---7IIIL7L|7|
        /// |FFJF7L7F-JF7IIL---7
        /// 7-L-JL7||F7|L7F-7F7|
        /// L.L7LFJ|||||FJL7||LJ
        /// L7JLJL-JLJLJL--JLJ.L
        /// In this last example, 10 tiles are enclosed by the loop.
        /// 
        /// Figure out whether you have time to search for the nest by calculating the area within the loop.
        /// How many tiles are enclosed by the loop?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            string[,] grid = new string[input.Count, input[0].Length];

            Point start = new();

            for (int y = 0; y < input.Count; y++)
            {
                string[] line = input[y].ToCharArray().Select(char.ToString).ToArray();

                for (int x = 0; x < line.Length; x++)
                {
                    grid[y, x] = line[x];

                    if (line[x] == "S") start = new Point(x, y);
                }
            }

            Dictionary<string, Pipe> pipeTypes = new()
            {
                ["|"] = new Pipe(0, -1, 0, 1),
                ["-"] = new Pipe(-1, 0, 1, 0),
                ["L"] = new Pipe(0, -1, 1, 0),
                ["J"] = new Pipe(0, -1, -1, 0),
                ["7"] = new Pipe(-1, 0, 0, 1),
                ["F"] = new Pipe(1, 0, 0, 1),
                ["."] = new Pipe(0, 0, 0, 0),
            };

            List<Point> potentials =
            [
                new Point(start.X - 1, start.Y),
                new Point(start.X + 1, start.Y),
                new Point(start.X, start.Y - 1),
                new Point(start.X, start.Y + 1)
             ];

            Point current = new();
            for (int i = 0; i < potentials.Count; i++)
            {
                Point potential = potentials[i];
                if (CanConnect(start.X, start.Y, potential.X, potential.Y, pipeTypes[grid[potential.Y, potential.X]]))
                {
                    current = potential;
                    break;
                }
            }

            Point previous = start;
            long steps = 0;

            int[,] path = new int[grid.GetLength(0), grid.GetLength(1)];
            string[,] pathStr = new string[grid.GetLength(0), grid.GetLength(1)];

            path[start.Y, start.X] = 1;
            pathStr[start.Y, start.X] = "7";

            while (current.X != start.X || current.Y != start.Y)
            {
                Pipe pipe = pipeTypes[grid[current.Y, current.X]];

                path[current.Y, current.X] = 1;
                pathStr[current.Y, current.X] = grid[current.Y, current.X];

                Point next;

                if (current.X + pipe.AX == previous.X && current.Y + pipe.AY == previous.Y) next = new Point(current.X + pipe.BX, current.Y + pipe.BY);
                else next = new Point(current.X + pipe.AX, current.Y + pipe.AY);

                previous = current;
                current = next;
                steps++;
            }

            int resizeFactor = 3;
            int[,] resizedGrid = ScaleUp(pathStr, resizeFactor, pipeTypes);

            DrawMaze(path);

            int totalContained = BFS(resizedGrid) / resizeFactor;
            int[,] scaledDown = ScaleDown(resizedGrid, resizeFactor);

            DrawMaze(scaledDown);

            int totalUnvisited = 0;

            for (int y = 0; y < scaledDown.GetLength(0); y++)
            {
                for (int x = 0; x < scaledDown.GetLength(1); x++)
                {
                    if (scaledDown[y, x] == 0) totalUnvisited++;
                }
            }

            DrawMaze(scaledDown);

            return totalUnvisited;
        }


        private static int BFS(int[,] grid)
        {
            int height = grid.GetLength(0);
            int width = grid.GetLength(1);

            bool[,] visited = new bool[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    visited[y, x] = grid[y, x] == 1;
                }
            }

            Queue<Point> queue = new();
            queue.Enqueue(new Point(0, 0));
            queue.Enqueue(new Point(0, height - 1));
            queue.Enqueue(new Point(width - 1, 0));
            queue.Enqueue(new Point(width - 1, height - 1));

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();

                if (current.X < 0 || current.X >= width || current.Y < 0 || current.Y >= height || visited[current.Y, current.X]) continue;

                visited[current.Y, current.X] = true;
                queue.Enqueue(new Point(current.X - 1, current.Y));
                queue.Enqueue(new Point(current.X + 1, current.Y));
                queue.Enqueue(new Point(current.X, current.Y - 1));
                queue.Enqueue(new Point(current.X, current.Y + 1));
            }

            int totalUnvisited = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool cellVisited = visited[y, x];

                    if (!cellVisited) totalUnvisited++;

                    grid[y, x] = cellVisited ? 1 : 0;
                }
            }

            return totalUnvisited;
        }

        private static void DrawMaze(int[,] maze)
        {
            for (int y = 0; y < maze.GetLength(0); y++)
            {
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    int pathNode = maze[y, x];

                    if (pathNode == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("I");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(".");
                    }

                    Console.ResetColor();
                }

                Console.Write(Environment.NewLine);
            }
        }

        private static int[,] ScaleUp(string[,] input, int resizeFactor, Dictionary<string, Pipe> pipeTypes)
        {
            int[,] resized = new int[input.GetLength(0) * resizeFactor, input.GetLength(1) * resizeFactor];

            for (int x = 0; x < resized.GetLength(0); x++)
            {
                for (int y = 0; y < resized.GetLength(1); y++)
                {
                    resized[x, y] = 0;
                }
            }

            for (int x = 0; x < input.GetLength(0); x++)
            {
                for (int y = 0; y < input.GetLength(1); y++)
                {
                    if (input[x, y] == null) continue;

                    Pipe pipe = pipeTypes[input[x, y]];

                    for (int i = 0; i < resizeFactor; i++)
                    {
                        resized[x * resizeFactor + pipe.AY * i, y * resizeFactor + pipe.AX * i] = 1;
                    }

                    for (int i = 0; i < resizeFactor; i++)
                    {
                        resized[x * resizeFactor + pipe.BY * i, y * resizeFactor + pipe.BX * i] = 1;
                    }
                }
            }

            return resized;
        }

        private static int[,] ScaleDown(int[,] input, int shrinkFactor)
        {
            int[,] resized = new int[input.GetLength(0) / shrinkFactor, input.GetLength(1) / shrinkFactor];

            for (int x = 0; x < resized.GetLength(0); x++)
            {
                for (int y = 0; y < resized.GetLength(1); y++)
                {
                    resized[x, y] = 0;
                }
            }

            for (int x = 0; x < resized.GetLength(0); x++)
            {
                for (int y = 0; y < resized.GetLength(1); y++)
                {
                    resized[x, y] = input[x * shrinkFactor, y * shrinkFactor];
                }
            }

            return resized;
        }

        private static bool CanConnect(int originX, int originY, int targetX, int targetY, Pipe pipe)
        {
            bool sideACanConnect = targetX + pipe.AX == originX && targetY + pipe.AY == originY;
            bool sideBCanConnect = targetX + pipe.BX == originX && targetY + pipe.BY == originY;

            return sideACanConnect || sideBCanConnect;
        }

        private readonly struct Pipe(int ax, int ay, int bx, int by)
        {
            public readonly int AX = ax;
            public readonly int AY = ay;
            public readonly int BX = bx;
            public readonly int BY = by;
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _10_PipeMaze(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_10_PipeMaze));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}