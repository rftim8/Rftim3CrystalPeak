namespace Rftim3CodinGame.Refactor.BotProgramming
{
    public class CodersOfTheCaribbean
    {
        /// <summary>
        /// Wood League 1
        /// </summary>
        public CodersOfTheCaribbean()
        {

        }

        private static void Solve()
        {
            while (true)
            {
                List<Barrel> barrels = [];
                List<Me> mes = [];
                List<Enemy> enemies = [];
                int myShipCount = int.Parse(Console.ReadLine() ?? string.Empty); // the number of remaining ships
                int entityCount = int.Parse(Console.ReadLine() ?? string.Empty); // the number of entities (e.g. ships, mines or cannonballs)
                for (int i = 0; i < entityCount; i++)
                {
                    string[] inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                    int entityId = int.Parse(inputs[0]);
                    string entityType = inputs[1];
                    int x = int.Parse(inputs[2]);
                    int y = int.Parse(inputs[3]);
                    int oa = int.Parse(inputs[4]);
                    int speed = int.Parse(inputs[5]);
                    int rum = int.Parse(inputs[6]);
                    int owner = int.Parse(inputs[7]);

                    if (entityType == "BARREL") barrels.Add(new Barrel(entityId, x, y, oa));

                    if (entityType == "SHIP")
                    {
                        if (owner == 1) mes.Add(new Me(entityId, x, y, oa, speed, rum, 0, 0, 0, 0));
                        else enemies.Add(new Enemy(entityId, x, y, oa, speed, rum));
                    }
                }

                for (int i = 0; i < mes.Count; i++)
                {
                    int dist = int.MaxValue;
                    int xb = -1;
                    int yb = -1;
                    if (barrels.Count != 0)
                    {
                        foreach (Barrel item in barrels)
                        {
                            double x = Dist(mes[i].x, mes[i].y, item.x, item.y);
                            if (x < dist)
                            {
                                dist = (int)x;
                                xb = item.x;
                                yb = item.y;
                            }
                        }
                        Console.WriteLine($"MOVE {xb} {yb}");
                    }
                    else
                    {
                        if (enemies.Count != 0)
                        {
                            foreach (Enemy item in enemies)
                            {
                                double x = Dist(mes[i].x, mes[i].y, item.x, item.y);
                                if (x < dist)
                                {
                                    dist = (int)x;
                                    xb = item.x;
                                    yb = item.y;
                                }
                            }

                            if (Dist(mes[i].x, mes[i].y, xb, yb) <= 10) Console.WriteLine($"FIRE {xb} {yb}");
                            else Console.WriteLine($"MOVE {xb} {yb}");
                        }
                        else Console.WriteLine("WAIT");
                    }
                }
            }
        }

        private static double Dist(int x0, int y0, int x1, int y1)
        {
            return Math.Sqrt((x0 - x1) * (x0 - x1) + (y0 - y1) * (y0 - y1));
        }

        private class Barrel(int id, int x, int y, int a)
        {
            public int id = id, x = x, y = y, a = a;
        }

        private class Me(int id, int x, int y, int o, int s, int r, int ex, int ey, int bx, int by)
        {
            public int id = id, x = x, y = y, o = o, s = s, r = r, ex = ex, ey = ey, bx = bx, by = by;
        }

        private class Enemy(int id, int x, int y, int o, int s, int r)
        {
            public int id = id, x = x, y = y, o = o, s = s, r = r;
        }
    }
}
