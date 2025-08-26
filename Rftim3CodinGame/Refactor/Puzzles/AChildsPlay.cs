namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class AChildsPlay
    {
        public AChildsPlay()
        {
            int n = 987, w = 12, h = 6;
            string[] map =
            [
                "...#........",
                "...........#",
                "............",
                "............",
                "..#O........",
                "..........#."
            ];

            #region Initial position
            int x = 0, y = 0;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (map[i][j] == 'O')
                    {
                        x = j;
                        y = i;
                    }
                }
            }
            #endregion

            Solve(map, n, x, y);
        }

        private static void Solve(string[] map, long n, int x, int y)
        {
            int dir = 0; // 0 - up, 1 - right, 2 - down, 3 - left

            Point init = new(0, 0);
            List<Point> points = [];

            bool searchOrigPattern = true;
            bool measurePattern = true;

            int patternLength = 0;
            int recurrence = 0;
            int recurrenceOrig = 0;

            for (long i = 0; i < n; i++)
            {
                points.Add(new Point(x, y));
                bool path = false;

                #region No loop detection
                while (!path)
                {
                    switch (dir)
                    {
                        case 0:
                            if (map[y - 1][x] == '.')
                            {
                                map[y] = map[y].Replace('O', '.');
                                map[y - 1] = $"{map[y - 1][..x]}O{map[y - 1][(x + 1)..]}";
                                path = true;
                                y--;
                            }
                            else dir = 1;
                            break;
                        case 1:
                            if (map[y][x + 1] == '.')
                            {
                                map[y] = map[y].Replace('O', '.');
                                map[y] = $"{map[y][..(x + 1)]}O{map[y][(x + 2)..]}";
                                path = true;
                                x++;
                            }
                            else dir = 2;
                            break;
                        case 2:
                            if (map[y + 1][x] == '.')
                            {
                                map[y] = map[y].Replace('O', '.');
                                map[y + 1] = $"{map[y + 1][..x]}O{map[y + 1][(x + 1)..]}";
                                path = true;
                                y++;
                            }
                            else dir = 3;
                            break;
                        case 3:
                            if (map[y][x - 1] == '.')
                            {
                                map[y] = map[y].Replace('O', '.');
                                map[y] = $"{map[y][..(x - 1)]}O{map[y][x..]}";
                                path = true;
                                x--;
                            }
                            else dir = 0;
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                #region Loop detection
                if (!searchOrigPattern && measurePattern)
                {
                    if (x == init.x && y == init.y) recurrenceOrig++;
                    if (recurrenceOrig == 2) patternLength++;
                    if (recurrenceOrig == 3)
                    {
                        measurePattern = false;
                        i = n - (n - i) % patternLength;
                    }
                }

                if (searchOrigPattern)
                {
                    for (int j = 0; j < points.Count; j++)
                    {
                        if (points[j].x == x && points[j].y == y)
                        {
                            if (recurrence == 1)
                            {
                                init.x = points[j].x;
                                init.y = points[j].y;
                            }

                            if (recurrence < 3) recurrence++;
                            else searchOrigPattern = false;
                        }
                    }
                }
                #endregion
            }

            Console.WriteLine($"{x} {y}");
        }

        class Point(int x, int y)
        {
            public int x = x, y = y;
        }
    }

}
