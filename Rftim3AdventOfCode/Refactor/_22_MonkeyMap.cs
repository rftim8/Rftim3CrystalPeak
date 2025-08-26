using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _22_MonkeyMap : I_22_MonkeyMap
    {
        #region Static
        private readonly List<string>? data;

        public _22_MonkeyMap()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_22_MonkeyMap));
        }

        /// <summary>
        /// The monkeys take you on a surprisingly easy trail through the jungle. 
        /// They're even going in roughly the right direction according to your handheld device's Grove Positioning System.
        /// 
        /// As you walk, the monkeys explain that the grove is protected by a force field.
        /// To pass through the force field, you have to enter a password; doing so involves tracing a specific path on a strangely-shaped board.
        /// 
        /// At least, you're pretty sure that's what you have to do; the elephants aren't exactly fluent in monkey.
        /// 
        /// The monkeys give you notes that they took when they last saw the password entered(your puzzle input).
        /// 
        /// For example:
        /// 
        ///         ...#
        ///         .#..
        ///         #...
        ///         ....
        /// ...#.......#
        /// ........#...
        /// ..#....#....
        /// ..........#.
        ///         ...#....
        ///         .....#..
        ///         .#......
        ///         ......#.
        /// 
        /// 10R5L5R10L4R5L5
        /// The first half of the monkeys' notes is a map of the board. It is comprised of a set of open tiles (on which you can move, drawn .) 
        /// and solid walls (tiles which you cannot enter, drawn #).
        /// 
        /// The second half is a description of the path you must follow.It consists of alternating numbers and letters:
        /// 
        /// A number indicates the number of tiles to move in the direction you are facing.If you run into a wall, you stop moving forward and continue with the next instruction.
        /// A letter indicates whether to turn 90 degrees clockwise (R) or counterclockwise (L). Turning happens in-place; it does not change your current tile.
        /// So, a path like 10R5 means "go forward 10 tiles, then turn clockwise 90 degrees, then go forward 5 tiles".
        /// 
        /// You begin the path in the leftmost open tile of the top row of tiles.Initially, you are facing to the right (from the perspective of how the map is drawn).
        /// 
        /// If a movement instruction would take you off of the map, you wrap around to the other side of the board.
        /// In other words, if your next tile is off of the board, you should instead look in the direction opposite of your current facing 
        /// as far as you can until you find the opposite edge of the board, then reappear there.
        /// 
        /// For example, if you are at A and facing to the right, the tile in front of you is marked B; if you are at C and facing down, the tile in front of you is marked D:
        /// 
        ///         ...#
        ///         .#..
        ///         #...
        ///         ....
        /// ...#.D.....#
        /// ........#...
        /// B.#....#...A
        /// .....C....#.
        ///         ...#....
        ///         .....#..
        ///         .#......
        ///         ......#.
        /// It is possible for the next tile(after wrapping around) to be a wall; this still counts as there being a wall in front of you,
        /// and so movement stops before you actually wrap to the other side of the board.
        /// 
        /// By drawing the last facing you had with an arrow on each tile you visit, the full path taken by the above example looks like this:
        /// 
        ///         >>v#    
        ///         .#v.    
        ///         #.v.    
        ///         ..v.
        /// ...#...v..v#    
        /// >>>v...>#.>>    
        /// ..#v...#....    
        /// ...>>>>v..#.    
        ///         ...#....
        ///         .....#..
        ///         .#......
        ///         ......#.
        /// To finish providing the password to this strange input device, you need to determine numbers for your final row, column,
        /// and facing as your final position appears from the perspective of the original map.Rows start from 1 at the top and count downward; 
        /// columns start from 1 at the left and count rightward. (In the above example, row 1, column 1 refers to the empty space with no tile on it in the top-left corner.) 
        /// Facing is 0 for right(>), 1 for down(v), 2 for left(<), and 3 for up(^). The final password is the sum of 1000 times the row, 4 times the column, and the facing.
        /// 
        /// In the above example, the final row is 6, the final column is 8, and the final facing is 0. So, the final password is 1000 * 6 + 4 * 8 + 0: 6032.
        /// 
        /// Follow the path given in the monkeys' notes. What is the final password?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            (List<(char DirectionToTurn, int Distance)> instructions, List<List<Tile>> map, int x, int y, Direction direction) = FormatInput(input);

            foreach ((char DirectionToTurn, int Distance) in instructions)
            {
                List<Tile> row = map[y];
                switch (direction)
                {
                    case Direction.Right:
                        for (int i = 0; i < Distance; ++i)
                        {
                            if (x + 1 >= row.Count)
                            {
                                int firstRealTile = row.FindIndex(t => t != Tile.None);
                                if (row[firstRealTile] == Tile.Path) x = firstRealTile;
                                else break;
                            }
                            else if (row[x + 1] == Tile.Path) ++x;
                            else if (row[x + 1] == Tile.Wall) break;
                            else
                            {
                                int firstRealTile = row.FindIndex(t => t != Tile.None);
                                if (row[firstRealTile] == Tile.Path) x = firstRealTile;
                                else break;
                            }
                        }
                        break;

                    case Direction.Left:
                        for (int i = 0; i < Distance; ++i)
                        {
                            if (x - 1 < 0)
                            {
                                int firstRealTile = row.FindLastIndex(t => t != Tile.None);
                                if (row[firstRealTile] == Tile.Path) x = firstRealTile;
                                else break;
                            }
                            else if (row[x - 1] == Tile.Path) --x;
                            else if (row[x - 1] == Tile.Wall) break;
                            else
                            {
                                int firstRealTile = row.FindLastIndex(t => t != Tile.None);
                                if (row[firstRealTile] == Tile.Path) x = firstRealTile;
                                else break;
                            }
                        }
                        break;

                    case Direction.Down:
                        for (int i = 0; i < Distance; ++i)
                        {
                            if (y + 1 >= map.Count)
                            {
                                int temp = 0;
                                while (true)
                                {
                                    if (map[temp][x] != Tile.None) break;

                                    ++temp;
                                }
                                if (map[temp][x] == Tile.Path) y = temp;
                                else break;
                            }
                            else if (map[y + 1][x] == Tile.Path) ++y;
                            else if (map[y + 1][x] == Tile.Wall) break;
                            else
                            {
                                int temp = 0;
                                while (true)
                                {
                                    if (map[temp][x] != Tile.None) break;

                                    ++temp;
                                }
                                if (map[temp][x] == Tile.Path) y = temp;
                                else break;
                            }
                        }
                        break;

                    case Direction.Up:
                        for (int i = 0; i < Distance; ++i)
                        {
                            if (y - 1 < 0)
                            {
                                int temp = map.Count - 1;
                                while (true)
                                {
                                    if (map[temp][x] != Tile.None) break;

                                    --temp;
                                }
                                if (map[temp][x] == Tile.Path) y = temp;
                                else break;
                            }
                            else if (map[y - 1][x] == Tile.Path) --y;
                            else if (map[y - 1][x] == Tile.Wall) break;
                            else
                            {
                                int temp = map.Count - 1;
                                while (true)
                                {
                                    if (map[temp][x] != Tile.None) break;

                                    --temp;
                                }
                                if (map[temp][x] == Tile.Path) y = temp;
                                else break;
                            }
                        }
                        break;
                }

                direction = GetNewDirection(direction, DirectionToTurn);
            }

            return CalculateScore(x, y, direction);
        }

        /// <summary>
        /// As you reach the force field, you think you hear some Elves in the distance. Perhaps they've already arrived?
        /// 
        /// You approach the strange input device, but it isn't quite what the monkeys drew in their notes. 
        /// Instead, you are met with a large cube; each of its six faces is a square of 50x50 tiles.
        /// 
        /// To be fair, the monkeys' map does have six 50x50 regions on it. If you were to carefully fold the map, you should be able to shape it into a cube!
        /// 
        /// In the example above, the six(smaller, 4x4) faces of the cube are:
        /// 
        ///         1111
        ///         1111
        ///         1111
        ///         1111
        /// 222233334444
        /// 222233334444
        /// 222233334444
        /// 222233334444
        ///         55556666
        ///         55556666
        ///         55556666
        ///         55556666
        /// You still start in the same position and with the same facing as before, but the wrapping rules are different.
        /// Now, if you would walk off the board, you instead proceed around the cube. 
        /// From the perspective of the map, this can look a little strange.
        /// In the above example, if you are at A and move to the right, you would arrive at B facing down;
        /// if you are at C and move down, you would arrive at D facing up:
        /// 
        ///         ...#
        ///         .#..
        ///         #...
        ///         ....
        /// ...#.......#
        /// ........#..A
        /// ..#....#....
        /// .D........#.
        ///         ...#..B.
        ///         .....#..
        ///         .#......
        ///         ..C...#.
        /// Walls still block your path, even if they are on a different face of the cube.
        /// If you are at E facing up, your movement is blocked by the wall marked by the arrow:
        /// 
        ///         ...#
        ///         .#..
        ///      -->#...
        ///         ....
        /// ...#..E....#
        /// ........#...
        /// ..#....#....
        /// ..........#.
        ///         ...#....
        ///         .....#..
        ///         .#......
        ///         ......#.
        /// Using the same method of drawing the last facing you had with an arrow on each tile you visit, the full path taken by the above example now looks like this:
        /// 
        ///         >>v#    
        ///         .#v.    
        ///         #.v.    
        ///         ..v.
        /// ...#..^...v#    
        /// .>>>>>^.#.>>    
        /// .^#....#....    
        /// .^........#.    
        ///         ...#..v.
        ///         .....#v.
        ///         .#v<<<<.
        ///         ..v...#.
        /// The final password is still calculated from your final position and facing from the perspective of the map. 
        /// In this example, the final row is 5, the final column is 7, and the final facing is 3, so the final password is 1000 * 5 + 4 * 7 + 3 = 5031.
        /// 
        /// Fold the map into a cube, then follow the path given in the monkeys' notes. What is the final password?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            (List<(char DirectionToTurn, int Distance)> instructions, List<List<Tile>> map, int x, int y, Direction direction) = FormatInput(input);

            foreach ((char DirectionToTurn, int Distance) in instructions)
            {
                for (int i = 0; i < Distance; ++i)
                {
                    List<Tile> row = map[y];
                    switch (direction)
                    {
                        case Direction.Right:
                            if (x + 1 >= row.Count)
                            {
                                Tile tile = map[149 - y][99];
                                if (tile == Tile.Path)
                                {
                                    x = 99;
                                    y = 149 - y;
                                    direction = Direction.Left;
                                }
                                else i = Distance;
                            }
                            else if (row[x + 1] == Tile.Path) ++x;
                            else if (row[x + 1] == Tile.Wall) i = Distance;
                            else
                            {
                                if (y < 100)
                                {
                                    Tile tile = map[49][y + 50];
                                    if (tile == Tile.Path)
                                    {
                                        x = y + 50;
                                        y = 49;
                                        direction = Direction.Up;
                                    }
                                    else if (tile == Tile.None) throw new Exception("");
                                    else i = Distance;
                                }
                                else if (y < 150)
                                {
                                    Tile tile = map[149 - y][149];
                                    if (tile == Tile.Path)
                                    {
                                        x = 149;
                                        y = 149 - y;
                                        direction = Direction.Left;
                                    }
                                    else i = Distance;
                                }
                                else
                                {
                                    Tile tile = map[149][y - 100];
                                    if (tile == Tile.Path)
                                    {
                                        x = y - 100;
                                        y = 149;
                                        direction = Direction.Up;
                                    }
                                    else i = Distance;
                                }
                            }
                            break;

                        case Direction.Left:
                            if (x - 1 < 0)
                            {
                                if (y < 150)
                                {
                                    Tile tile = map[149 - y][50];
                                    if (tile == Tile.Path)
                                    {
                                        x = 50;
                                        y = 149 - y;
                                        direction = Direction.Right;
                                    }
                                    else i = Distance;
                                }
                                else
                                {
                                    Tile tile = map[0][y - 100];
                                    if (tile == Tile.Path)
                                    {
                                        x = y - 100;
                                        y = 0;
                                        direction = Direction.Down;
                                    }
                                    else i = Distance;
                                }
                            }
                            else if (row[x - 1] == Tile.Path) --x;
                            else if (row[x - 1] == Tile.Wall) i = Distance;
                            else
                            {
                                if (y < 50)
                                {
                                    Tile tile = map[149 - y][0];
                                    if (tile == Tile.Path)
                                    {
                                        x = 0;
                                        y = 149 - y;
                                        direction = Direction.Right;
                                    }
                                    else i = Distance;
                                }
                                else
                                {
                                    Tile tile = map[100][y - 50];
                                    if (tile == Tile.Path)
                                    {
                                        x = y - 50;
                                        y = 100;
                                        direction = Direction.Down;
                                    }
                                    else i = Distance;
                                }
                            }
                            break;

                        case Direction.Down:
                            if (y + 1 >= map.Count)
                            {
                                Tile tile = map[0][x + 100];
                                if (tile == Tile.Path)
                                {
                                    x += 100;
                                    y = 0;
                                }
                                else i = Distance;
                            }
                            else if (map[y + 1][x] == Tile.Path) ++y;
                            else if (map[y + 1][x] == Tile.Wall) i = Distance;
                            else
                            {
                                if (x < 100)
                                {
                                    Tile tile = map[x + 100][49];
                                    if (tile == Tile.Path)
                                    {
                                        y = x + 100;
                                        x = 49;
                                        direction = Direction.Left;
                                    }
                                    else i = Distance;
                                }
                                else
                                {
                                    Tile tile = map[x - 50][99];
                                    if (tile == Tile.Path)
                                    {
                                        y = x - 50;
                                        x = 99;
                                        direction = Direction.Left;
                                    }
                                    else i = Distance;
                                }
                            }
                            break;

                        case Direction.Up:
                            if (y - 1 < 0)
                            {
                                if (x < 100)
                                {
                                    Tile tile = map[x + 100][0];
                                    if (tile == Tile.Path)
                                    {
                                        y = x + 100;
                                        x = 0;
                                        direction = Direction.Right;
                                    }
                                    else i = Distance;
                                }
                                else
                                {
                                    Tile tile = map[199][x - 100];
                                    if (tile == Tile.Path)
                                    {
                                        x -= 100;
                                        y = 199;
                                    }
                                    else i = Distance;
                                }
                            }
                            else if (map[y - 1][x] == Tile.Path) --y;
                            else if (map[y - 1][x] == Tile.Wall) i = Distance;
                            else
                            {
                                Tile tile = map[x + 50][50];
                                if (tile == Tile.Path)
                                {
                                    y = x + 50;
                                    x = 50;
                                    direction = Direction.Right;
                                }
                                else i = Distance;
                            }
                            break;
                    }
                }

                direction = GetNewDirection(direction, DirectionToTurn);
            }

            return CalculateScore(x, y, direction);
        }

        private static (List<(char DirectionToTurn, int Distance)>, List<List<Tile>>, int, int, Direction) FormatInput(List<string> input)
        {
            int rowLength = input.TakeWhile(i => !string.IsNullOrEmpty(i)).Max(i => i.Length);
            List<List<Tile>> map = input.TakeWhile(i => !string.IsNullOrEmpty(i))
                .Select(i => i.PadRight(rowLength).Select(j => j == ' ' ? Tile.None : j == '.' ? Tile.Path : Tile.Wall).ToList())
                .ToList();

            List<(char, int s)> instructions = input[^1].Split('R').SelectMany(i =>
            {
                List<int> split = i.Split('L').Select(s => int.Parse(s)).ToList();
                List<(char, int s)> line = split.Take(split.Count - 1).Select(s => ('L', s)).ToList();
                line.Add(('R', split.Last()));
                return line;
            }).ToList();
            int last = instructions.Last().s;
            instructions.RemoveAt(instructions.Count - 1);
            instructions.Add(('S', last));

            Direction direction = Direction.Right;
            int x = map[0].FindIndex(t => t == Tile.Path);
            int y = 0;

            return (instructions, map, x, y, direction);
        }

        private static Direction GetNewDirection(Direction direction, char directionToTurn)
        {
            switch (directionToTurn)
            {
                case 'R':
                    switch (direction)
                    {
                        case Direction.Right:
                            return Direction.Down;
                        case Direction.Down:
                            return Direction.Left;
                        case Direction.Left:
                            return Direction.Up;
                        case Direction.Up:
                            return Direction.Right;
                        default:
                            break;
                    }
                    break;

                case 'L':
                    switch (direction)
                    {
                        case Direction.Right:
                            return Direction.Up;
                        case Direction.Up:
                            return Direction.Left;
                        case Direction.Left:
                            return Direction.Down;
                        case Direction.Down:
                            return Direction.Right;
                        default:
                            break;
                    }
                    break;
            }

            return direction;
        }

        private static int CalculateScore(int x, int y, Direction direction)
        {
            int directionScore = 0;
            switch (direction)
            {
                case Direction.Down:
                    directionScore = 1;
                    break;
                case Direction.Left:
                    directionScore = 2;
                    break;
                case Direction.Up:
                    directionScore = 3;
                    break;
                case Direction.Right:
                    break;
                default:
                    break;
            }

            return directionScore + 4 * (x + 1) + 1000 * (y + 1);
        }

        private enum Tile
        {
            None,
            Path,
            Wall
        }

        private enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _22_MonkeyMap(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_22_MonkeyMap));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}