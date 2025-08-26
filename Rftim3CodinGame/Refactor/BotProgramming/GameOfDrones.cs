namespace Rftim3CodinGame.Refactor.BotProgramming
{
    public class GameOfDrones
    {
        public GameOfDrones()
        {

        }

        private static void Solve()
        {
            List<Zone> zones = [];
            List<Me> mes = [];
            List<Enemy> enemies = [];

            string[] inputs;
            inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
            int P = int.Parse(inputs[0]); // number of players in the game (2 to 4 players)
            int ID = int.Parse(inputs[1]); // ID of your player (0, 1, 2, or 3)
            int D = int.Parse(inputs[2]); // number of drones in each team (3 to 11)
            int Z = int.Parse(inputs[3]); // number of zones on the map (4 to 8)
            for (int i = 0; i < Z; i++)
            {
                inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                int X = int.Parse(inputs[0]); // corresponds to the position of the center of a zone. A zone is a circle with a radius of 100 units.
                int Y = int.Parse(inputs[1]);
                zones.Add(new Zone(i, X, Y, -1, 0));
            }

            // game loop
            while (true)
            {
                for (int i = 0; i < Z; i++)
                {
                    int TID = int.Parse(Console.ReadLine() ?? string.Empty); // ID of the team controlling the zone (0, 1, 2, or 3) or -1 if it is not controlled. The zones are given in the same order as in the initialization.
                    zones[i].idc = TID;
                }
                for (int i = 0; i < P; i++)
                {
                    for (int j = 0; j < D; j++)
                    {
                        inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                        int DX = int.Parse(inputs[0]); // The first D lines contain the coordinates of drones of a player with the ID 0, the following D lines those of the drones of player 1, and thus it continues until the last player.
                        int DY = int.Parse(inputs[1]);
                        if (i == ID) mes.Add(new Me(j, DX, DY));
                        else enemies.Add(new Enemy(j, DX, DY));
                    }
                }

                foreach (Zone item in zones)
                {
                    foreach (Enemy item1 in enemies)
                    {
                        if (item.x == item1.x && item.y == item1.y) item.ne++;
                    }
                }

                //zones = zones.OrderBy(o => o.ne).ToList();

                foreach (Me item in mes)
                {
                    double a = int.MaxValue;
                    int x = -1;
                    int y = -1;
                    foreach (Zone item1 in zones)
                    {
                        double b = Dist(item.x, item.y, item1.x, item1.y);
                        if (b < a)
                        {
                            x = item1.x;
                            y = item1.y;
                            a = b;
                        }
                    }
                    if (x != -1 && y != -1) Console.WriteLine($"{x} {y}");
                    else Console.WriteLine($"{item.x} {item.y}");
                }

                mes.Clear();
            }
        }

        private static double Dist(int x0, int y0, int x1, int y1)
        {
            return Math.Sqrt((x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1));
        }

        private class Zone(int id, int x, int y, int idc, int ne)
        {
            public int id = id, x = x, y = y, idc = idc, ne = ne;
        }

        private class Me(int id, int x, int y)
        {
            public int id = id, x = x, y = y;
        }

        private class Enemy(int id, int x, int y)
        {
            public int id = id, x = x, y = y;
        }
    }
}
