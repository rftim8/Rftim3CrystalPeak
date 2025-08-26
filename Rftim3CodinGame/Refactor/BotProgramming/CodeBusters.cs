namespace Rftim3CodinGame.Refactor.BotProgramming
{
    public class CodeBusters
    {
        public CodeBusters()
        {

        }

        private static void Solve()
        {
            int bustersPerPlayer = int.Parse(Console.ReadLine() ?? string.Empty); // the amount of busters you control
            int ghostCount = int.Parse(Console.ReadLine() ?? string.Empty); // the amount of ghosts on the map
            int myTeamId = int.Parse(Console.ReadLine() ?? string.Empty); // if this is 0, your base is on the top left of the map, if it is one, on the bottom right
            int coreX = myTeamId == 0 ? 0 : 16000;
            int coreY = myTeamId == 0 ? 0 : 9000;

            List<(int, int)> path =
            [
                (4000, 1000),
                (7000, 1000),
                (10000, 1000),
                (13000, 1000),
                (15000, 1000),
                (15000, 4000),
                (15000, 7000),
                (15000, 8000),

                (2000, 2000),
                (4000, 3000),
                (6000, 4000),
                (800, 5000),
                (10000, 6000),
                (12000, 7000),
                (14000, 8000),

                (1000, 4000),
                (1000, 7000),
                (1000, 8000),
                (4000, 8000),
                (7000, 8000),
                (10000, 8000),
                (13000, 8000)
            ];

            if (myTeamId == 1) path.Reverse();

            List<(int, int)> map = [];

            bool c = true;
            while (true)
            {
                List<Ghost> ghosts = [];
                List<Me> mes = [];
                List<Enemy> enemies = [];

                int entities = int.Parse(Console.ReadLine() ?? string.Empty); // the number of busters and ghosts visible to you
                for (int i = 0; i < entities; i++)
                {
                    string[] inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                    int entityId = int.Parse(inputs[0]); // buster id or ghost id
                    int x = int.Parse(inputs[1]);
                    int y = int.Parse(inputs[2]); // position of this buster / ghost
                    int entityType = int.Parse(inputs[3]); // the team id if it is a buster, -1 if it is a ghost.
                    int state = int.Parse(inputs[4]); // For busters: 0=idle, 1=carrying a ghost.
                    int value = int.Parse(inputs[5]); // For busters: Ghost id being carried. For ghosts: number of busters attempting to trap this ghost.

                    if (entityType == myTeamId)
                    {
                        mes.Add(new Me(entityId, x, y, state));
                        if (c)
                        {
                            switch (i % 3)
                            {
                                case 0:
                                    map.Add((entityId, 0));
                                    break;
                                case 1:
                                    map.Add((entityId, 8));
                                    break;
                                case 2:
                                    map.Add((entityId, 15));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else if (entityType == -1) ghosts.Add(new Ghost(entityId, x, y, value));
                    else enemies.Add(new Enemy(entityId, x, y, state));
                }
                c = false;

                for (int i = 0; i < mes.Count; i++)
                {
                    if (mes[i].state == 1)
                    {
                        if (enemies.Count != 0)
                        {
                            bool stun = true;
                            foreach (Enemy item in enemies)
                            {
                                if (stun && item.state != 2)
                                {
                                    if (Dist(mes[i].x, mes[i].y, item.x, item.y) < 1750)
                                    {
                                        Console.WriteLine($"STUN {item.id}");
                                        stun = false;
                                        break;
                                    }
                                }
                            }
                            if (stun)
                            {
                                if (mes[i].x == coreX && mes[i].y == coreY) Console.WriteLine($"RELEASE");
                                else Console.WriteLine($"MOVE {coreX} {coreY}");
                            }
                        }
                        else
                        {
                            if (mes[i].x == coreX && mes[i].y == coreY) Console.WriteLine($"RELEASE");
                            else Console.WriteLine($"MOVE {coreX} {coreY}");
                        }
                    }
                    else
                    {
                        if (enemies.Count != 0)
                        {
                            bool stun = true;
                            foreach (Enemy item in enemies)
                            {
                                if (stun && item.state != 2)
                                {
                                    if (Dist(mes[i].x, mes[i].y, item.x, item.y) < 1750)
                                    {
                                        Console.WriteLine($"STUN {item.id}");
                                        stun = false;
                                        break;
                                    }
                                }
                            }
                            if (stun)
                            {
                                if (ghosts.Count != 0)
                                {
                                    double a = int.MaxValue;
                                    int x = -1;
                                    int y = -1;
                                    int id = -1;
                                    foreach (Ghost item1 in ghosts)
                                    {
                                        double b = Dist(mes[i].x, mes[i].y, item1.x, item1.y);
                                        if (b < a)
                                        {
                                            x = item1.x;
                                            y = item1.y;
                                            id = item1.id;
                                            a = b;
                                        }
                                    }
                                    if (x != -1 && y != -1)
                                    {
                                        if (a < 1750) Console.WriteLine($"BUST {id}");
                                        else Console.WriteLine($"MOVE {x} {y}");
                                    }
                                }
                                else
                                {
                                    if (mes[i].x == path[map[i].Item2].Item1 && mes[i].y == path[map[i].Item2].Item2)
                                    {
                                        int index = map[i].Item2;
                                        index++;
                                        if (index == path.Count - 1) index = 0;
                                        map[i] = (map[i].Item1, index);
                                    }
                                    Console.WriteLine($"MOVE {path[map[i].Item2].Item1} {path[map[i].Item2].Item2}");
                                }
                            }
                        }
                        else
                        {
                            if (ghosts.Count != 0)
                            {
                                double a = int.MaxValue;
                                int x = -1;
                                int y = -1;
                                int id = -1;
                                foreach (Ghost item1 in ghosts)
                                {
                                    double b = Dist(mes[i].x, mes[i].y, item1.x, item1.y);
                                    if (b < a)
                                    {
                                        x = item1.x;
                                        y = item1.y;
                                        id = item1.id;
                                        a = b;
                                    }
                                }
                                if (x != -1 && y != -1)
                                {
                                    if (a < 1750) Console.WriteLine($"BUST {id}");
                                    else Console.WriteLine($"MOVE {x} {y}");
                                }
                            }
                            else
                            {
                                if (mes[i].x == path[map[i].Item2].Item1 && mes[i].y == path[map[i].Item2].Item2)
                                {
                                    int index = map[i].Item2;
                                    index++;
                                    if (index == path.Count - 1) index = 0;
                                    map[i] = (map[i].Item1, index);
                                }
                                Console.WriteLine($"MOVE {path[map[i].Item2].Item1} {path[map[i].Item2].Item2}");
                            }
                        }
                    }
                }
            }
        }

        private static double Dist(int x0, int y0, int x1, int y1)
        {
            return Math.Sqrt((x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1));
        }

        private class Ghost(int id, int x, int y, int nb)
        {
            public int id = id, x = x, y = y, nb = nb;
        }

        private class Me(int id, int x, int y, int state)
        {
            public int id = id, x = x, y = y, state = state;
        }

        private class Enemy(int id, int x, int y, int state)
        {
            public int id = id, x = x, y = y, state = state;
        }
    }
}
