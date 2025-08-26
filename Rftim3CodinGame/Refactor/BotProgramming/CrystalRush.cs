namespace Rftim3CodinGame.Refactor.BotProgramming
{
    public class CrystalRush
    {
        public CrystalRush()
        {

        }

        private static void Solve()
        {
            {
                string[] inputs;
                inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                int width = int.Parse(inputs[0]);
                int height = int.Parse(inputs[1]); // size of the map

                List<(int, int)> map =
                [
                    (5, 3),
                    (10, 3),
                    (15, 3),
                    (20, 3),
                    (25, 3),
                    (5, 6),
                    (10, 6),
                    (15, 6),
                    (20, 6),
                    (25, 6),
                    (5, 9),
                    (10, 9),
                    (15, 9),
                    (20, 9),
                    (25, 9),
                    (5, 12),
                    (10, 12),
                    (15, 12),
                    (20, 12),
                    (25, 12)
                ];

                int c = 0;
                bool cover = true;

                // game loop
                while (true)
                {
                    List<Ore> ores = [];
                    List<Me> mes = [];
                    List<Enemy> enemies = [];
                    inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                    int myScore = int.Parse(inputs[0]); // Amount of ore delivered
                    int opponentScore = int.Parse(inputs[1]);
                    for (int i = 0; i < height; i++)
                    {
                        inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                        for (int j = 0; j < width; j++)
                        {
                            string ore = inputs[2 * j];// amount of ore or "?" if unknown
                            int hole = int.Parse(inputs[2 * j + 1]);// 1 if cell has a hole
                            if (ore != "?")
                            {
                                int amount = int.Parse(ore);
                                if (amount > 0) ores.Add(new Ore(j, i, amount));
                            }
                        }
                    }
                    inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                    int entityCount = int.Parse(inputs[0]); // number of entities visible to you
                    int radarCooldown = int.Parse(inputs[1]); // turns left until a new radar can be requested
                    int trapCooldown = int.Parse(inputs[2]); // turns left until a new trap can be requested
                    for (int i = 0; i < entityCount; i++)
                    {
                        inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                        int entityId = int.Parse(inputs[0]); // unique id of the entity
                        int entityType = int.Parse(inputs[1]); // 0 for your robot, 1 for other robot, 2 for radar, 3 for trap
                        int x = int.Parse(inputs[2]);
                        int y = int.Parse(inputs[3]); // position of the entity
                        int item = int.Parse(inputs[4]); // if this entity is a robot, the item it is carrying (-1 for NONE, 2 for RADAR, 3 for TRAP, 4 for ORE)

                        switch (entityType)
                        {
                            case 0:
                                mes.Add(new Me(entityId, x, y, item, 0));
                                break;
                            case 1:
                                enemies.Add(new Enemy(entityId, x, y));
                                break;
                            default:
                                break;
                        }
                    }

                    ores = [.. ores.OrderBy(o => Dist(o.x, o.y, 0, o.y))];

                    for (int i = 0; i < mes.Count; i++)
                    {
                        if (i == mes.Count - 1)
                        {
                            if (mes[i].car == -1)
                            {
                                if (mes[i].x != 0) Console.WriteLine($"MOVE {0} {mes[i].y}");
                                else
                                {
                                    if (radarCooldown == 0) Console.WriteLine($"REQUEST RADAR");
                                    else Console.WriteLine($"WAIT");
                                }
                            }
                            else
                            {
                                if (mes[i].x == map[c].Item1 && mes[i].y == map[c].Item2)
                                {
                                    Console.WriteLine($"DIG {map[c].Item1} {map[c].Item2}");
                                    c++;
                                    if (c == map.Count) c = 0;
                                }
                                else Console.WriteLine($"MOVE {map[c].Item1} {map[c].Item2}");
                            }
                        }
                        else
                        {
                            if (mes[i].car == -1)
                            {
                                if (ores.Count != 0)
                                {
                                    if (i < ores.Count)
                                    {
                                        if (mes[i].x != ores[i].x && mes[i].y != ores[i].y) Console.WriteLine($"MOVE {ores[i].x} {ores[i].y}");
                                        else Console.WriteLine($"DIG {ores[i].x} {ores[i].y}");
                                    }
                                    else Console.WriteLine($"WAIT");
                                }
                                else
                                {
                                    if (mes[i].x == 29) cover = false;
                                    if (mes[i].x == 0) cover = true;

                                    if (cover) Console.WriteLine($"MOVE {29} {mes[i].y}");
                                    else Console.WriteLine($"MOVE {0} {mes[i].y}");
                                }
                            }
                            else if (mes[i].car == 4)
                            {
                                if (mes[i].x == 0) Console.WriteLine($"DIG {mes[i].x} {mes[i].y}");
                                else Console.WriteLine($"MOVE {0} {mes[i].y}");
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

        class Ore(int x, int y, int q)
        {
            public int x = x, y = y, q = q;
        }

        class Me(int id, int x, int y, int car, int distToOre)
        {
            public int id = id, x = x, y = y, car = car, distToOre = distToOre;
        }

        class Enemy(int id, int x, int y)
        {
            public int id = id, x = x, y = y;
        }
    }
}
