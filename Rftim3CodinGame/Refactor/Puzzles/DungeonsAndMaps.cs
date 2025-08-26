namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class DungeonsAndMaps
    {
        public DungeonsAndMaps()
        {
            //int w = 4;
            //int w = 6;
            int w = 19;
            //int h = 4;
            //int h = 7;
            int h = 19;
            //int startRow = 1;
            //int startRow = 2;
            int startRow = 0;
            //int startCol = 1;
            //int startCol = 2;
            int startCol = 9;
            int n = 6;
            //string mapRow = ".>>v.^#v..#v...T.....v#..v#..>>T....v<#.v.#...>T";
            //string mapRow = "..............>>T..........................>>>>v.^...v.^<.T<........................";
            string mapRow = "#########v###########...............###........#........##....##..#..##....##....##..#..##....#...####..#..####......####..#..####...#........#........##.#............#..##.#..###.#.###.#..##.#............#..##.......###.......#.......#####.........#...#######...#..#..#...#####...#..###..#...###...#..#####..#...#...#..#######.....T.....################################v###########.......>>v.....###........#.v......##....##..#.v##....##....##..#.v##....#...####..#v<####......####..#>v####...#........#.>>>>>>v##.#............#.v##.#..###.#.###.#.v##.#............#.v##.......###......v#.......#####..v<<<...#...#######v<.#..#..#...#####v<.#..###..#...###v<.#..#####..#...#v<.#..#######.....T<....################################v###########......v>>>>>>>v###.......v#......>v##....##.v#..##...v##....##.v#..##...v#...####.v#..####.>>...####.v#..####...#...v<<<v#........##.#.>^..v......#..##.#..###v#.###.#..##.#....v<......#..##.....v<###.......#.....v<#####.........#..v#######...#..#..#.>v#####...#..###..#.>v###...#..#####..#.>v#...#..#######....>T.....################################v###########......v<>>>>>>v###.......v#......>v##....##.v#..##...v##....##.v#..##...v#...####.v#..####.>>...####.v#..####...#...v<<<v#........##.#.>^..v......#..##.#..###v#.###.#..##.#....v<......#..##.....v<###.......#.....v<#####.........#..v#######...#..#..#.>v#####...#..###..#.>v###...#..#####..#.>v#...#..#######....>T.....################################v###########.......>>>>>>>v###........#......>v##....##..#..##...v##....##..#..##...v#...####..#..####.>v...####..#..####.v<#........#.......v##.#............#.v##.#..###v#.###.#.v##.#............#.v##.......###......v#.......#####.....>v..#...#######...#v<#..#...#####...#v<###..#...###...#v<#####..#...#...#v<#######.....T<<<<<################################v###########.......>>>>>>>v###........#......>v##....##..#..##...v##....##..#..##...v#...####..#..####.>v...####..#..####.v<#........#.......v##.#............#.v##.#..###v#.###.#.v##.#....v<<<<...#.v##.....v<###^<....v#.....v<#####^<...>v..#..v#######^..#v<#..#.>v#####>^.#v<###..#.>v###>^.#v<#####..#.>v#>^.#v<#######....>T^<<<<#######################";
            string[][,] x = new string[n][,];

            int count = 0;
            for (int k = 0; k < n; k++)
            {
                x[k] = new string[h, w];
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        x[k][i, j] = mapRow[count].ToString();
                        count++;
                    }
                }
            }

            Solve(w, h, startRow, startCol, n, x);
        }

        public static void Solve(int w, int h, int startRow, int startCol, int n, string[][,] x)
        {
            int[] xResults = new int[n];
            string[] xStatus = new string[n];
            const string up = "^";
            const string right = ">";
            const string down = "v";
            const string left = "<";
            const string empty = ".";
            const string wall = "#";
            const string treasure = "T";
            const string trap = "TRAP";

            for (int k = 0; k < n; k++)
            {
                string status = "";
                int startX = startRow;
                int startY = startCol;
                int continous = 0;

                Console.WriteLine($"Map number: {k}");
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        Console.Write(x[k][i, j]);
                    }
                    Console.WriteLine();
                }

                while (status != trap && status != treasure)
                {
                    if (continous > 0 && startX == startRow && startY == startCol)
                    {
                        status = trap;
                        xStatus[k] = trap;
                    }
                    continous++;
                    switch (x[k][startX, startY])
                    {
                        case up:
                            if (startX > 0)
                            {
                                if (x[k][startX - 1, startY] == empty || x[k][startX - 1, startY] == wall)
                                {
                                    status = trap;
                                    xStatus[k] = trap;
                                }
                                else if (x[k][startX - 1, startY] == treasure)
                                {
                                    status = treasure;
                                    xStatus[k] = treasure;
                                }
                            }
                            else
                            {
                                status = trap;
                                xStatus[k] = trap;
                            }
                            startX--;
                            xResults[k]++;
                            break;
                        case right:
                            if (startY < h - 1)
                            {
                                if (x[k][startX, startY + 1] == empty || x[k][startX, startY + 1] == wall)
                                {
                                    status = trap;
                                    xStatus[k] = trap;
                                }
                                else if (x[k][startX, startY + 1] == treasure)
                                {
                                    status = treasure;
                                    xStatus[k] = treasure;
                                }
                            }
                            else
                            {
                                status = trap;
                                xStatus[k] = trap;
                            }
                            startY++;
                            xResults[k]++;
                            break;
                        case down:
                            if (startX < w - 1)
                            {
                                if (x[k][startX + 1, startY] == empty || x[k][startX + 1, startY] == wall)
                                {
                                    status = trap;
                                    xStatus[k] = trap;
                                }
                                else if (x[k][startX + 1, startY] == treasure)
                                {
                                    status = treasure;
                                    xStatus[k] = treasure;
                                }
                            }
                            else
                            {
                                status = trap;
                                xStatus[k] = trap;
                            }
                            startX++;
                            xResults[k]++;
                            break;
                        case left:
                            if (startY > 0)
                            {
                                if (x[k][startX, startY - 1] == empty || x[k][startX, startY - 1] == wall)
                                {
                                    status = trap;
                                    xStatus[k] = trap;
                                }
                                else if (x[k][startX, startY - 1] == treasure)
                                {
                                    status = treasure;
                                    xStatus[k] = treasure;
                                }
                            }
                            else
                            {
                                status = trap;
                                xStatus[k] = trap;
                            }
                            startY--;
                            xResults[k]++;
                            break;
                        default:
                            break;
                    }
                }
            }

            int final = xResults.Max();
            int finalPos = 0;

            for (int i = 0; i < n; i++)
            {
                if (xStatus[i] != trap)
                {
                    if (final > xResults[i])
                    {
                        final = xResults[i];
                        finalPos = i;
                    }
                }
            }

            Console.Write(xStatus.Contains(treasure) ? finalPos : trap);
        }
    }
}
