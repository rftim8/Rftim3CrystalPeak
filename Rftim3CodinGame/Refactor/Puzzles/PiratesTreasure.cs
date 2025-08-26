namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class PiratesTreasure
    {
        public PiratesTreasure()
        {
            //int w = 2;
            //int h = 2;

            int w = 4;
            int h = 4;

            //int[,] map = new int[,] {
            //    { 0, 1 },
            //    { 1, 1 }
            //};

            int[,] map = new int[,] {
                { 1, 1, 1, 0 },
                { 1, 0, 1, 0 },
                { 1, 1, 1, 1 },
                { 0, 0, 1, 1 }
            };

            Solve(w, h, map);
        }

        private static void Solve(int w, int h, int[,] map)
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (map[i, j] == 0)
                    {
                        bool N = i - 1 >= 0 && map[i - 1, j] == 1;
                        bool Nwall = i - 1 < 0;
                        bool NE = i - 1 >= 0 && j + 1 < w && map[i - 1, j + 1] == 1;
                        bool NEwall = i - 1 < 0 || j + 1 >= w;
                        bool E = j + 1 < w && map[i, j + 1] == 1;
                        bool Ewall = j + 1 >= w;
                        bool SE = i + 1 < h && j + 1 < w && map[i + 1, j + 1] == 1;
                        bool SEwall = i + 1 >= h || j + 1 >= w;
                        bool S = i + 1 < h && map[i + 1, j] == 1;
                        bool Swall = i + 1 >= h;
                        bool SW = i + 1 < h && j - 1 >= 0 && map[i + 1, j - 1] == 1;
                        bool SWwall = i + 1 >= h || j - 1 < 0;
                        bool W = j - 1 >= 0 && map[i, j - 1] == 1;
                        bool Wwall = j - 1 < 0;
                        bool NW = i - 1 >= 0 && j - 1 >= 0 && map[i - 1, j - 1] == 1;
                        bool NWwall = i - 1 < 0 || j - 1 < 0;

                        if ((N || Nwall) &&
                            (NE || NEwall) &&
                            (E || Ewall) &&
                            (SE || SEwall) &&
                            (S || Swall) &&
                            (SW || SWwall) &&
                            (W || Wwall) &&
                            (NW || NWwall)
                            )
                        {
                            Console.Write($"{j} {i}");
                        }
                    }
                }
            }
        }
    }
}
