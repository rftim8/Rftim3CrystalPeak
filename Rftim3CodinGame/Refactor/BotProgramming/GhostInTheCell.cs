using System.Text;

namespace Rftim3CodinGame.Refactor.BotProgramming
{
    public class GhostInTheCell
    {
        public GhostInTheCell()
        {
            List<Factory> factories = [];
            string[] inputs;
            int factoryCount = int.Parse(Console.ReadLine() ?? string.Empty); // the number of factories
            int linkCount = int.Parse(Console.ReadLine() ?? string.Empty); // the number of links between factories
            int bombs = 2;
            int bombed = -1;
            for (int i = 0; i < linkCount; i++)
            {
                inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                int factory1 = int.Parse(inputs[0]);
                int factory2 = int.Parse(inputs[1]);
                int distance = int.Parse(inputs[2]);
                factories.Add(new Factory(factory1, factory2, distance));
            }

            while (true)
            {
                List<MyFactory> my = [];
                List<EnemyFactory> enemy = [];
                List<Troop> troops = [];
                StringBuilder sb = new();

                int entityCount = int.Parse(Console.ReadLine() ?? string.Empty); // the number of entities (e.g. factories and troops)
                for (int i = 0; i < entityCount; i++)
                {
                    inputs = (Console.ReadLine() ?? string.Empty).Split(' ');
                    int entityId = int.Parse(inputs[0]);
                    string entityType = inputs[1];
                    int arg1 = int.Parse(inputs[2]);
                    int arg2 = int.Parse(inputs[3]);
                    int arg3 = int.Parse(inputs[4]);
                    int arg4 = int.Parse(inputs[5]);
                    int arg5 = int.Parse(inputs[6]);

                    if (entityType == "TROOP") troops.Add(new Troop(arg3, arg4));

                    if (entityType == "FACTORY")
                    {
                        switch (arg1)
                        {
                            case 1:
                                my.Add(new MyFactory(entityId, arg2, arg3, 0, factories, new List<EnemyFactory>()));
                                break;
                            case 0:
                                enemy.Add(new EnemyFactory(entityId, 0, arg2, arg3, 0));
                                break;
                            case -1:
                                enemy.Add(new EnemyFactory(entityId, -1, arg2, arg3, 0));
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (my.Count > 0)
                {
                    foreach (MyFactory item in my)
                    {
                        item.x = factories;
                        item.y = enemy;

                        if (troops.Count > 0)
                        {
                            foreach (Troop item1 in troops)
                            {
                                if (item1.target == item.id) item.incoming += item1.ncy;
                            }
                        }

                        if (item.y.Count > 0)
                        {
                            item.y = [.. item.y.Select(o => o).OrderByDescending(o => o.prod).ThenBy(o => o.d)];
                            foreach (EnemyFactory item1 in item.y)
                            {
                                if (item.ncy > item.incoming) sb.Append($"MOVE {item.id} {item1.id} {item1.ncy + 1};");
                            }
                        }
                    }

                    #region Bombs
                    enemy = [.. enemy.Select(o => o).OrderByDescending(o => o.prod)];

                    foreach (EnemyFactory item in enemy)
                    {
                        if (bombs > 0)
                        {
                            if (item.type == -1 && (item.prod == 2 || item.prod == 3) && item.id != bombed)
                            {
                                bombed = item.id;
                                sb.Append($"BOMB {my.Last().id} {item.id};");
                                bombs -= 1;
                            }
                        }
                    }
                    #endregion

                    if (sb.Length > 0) Console.WriteLine(sb.ToString()[..^1]);
                    else Console.WriteLine("WAIT");
                }
                else Console.WriteLine("WAIT");
            }
        }

        class Factory(int fact1, int fact2, int dist)
        {
            public int fact1 = fact1, fact2 = fact2, dist = dist;
        }

        class MyFactory
        {
            public int id, ncy, prod, incoming;
            public List<Factory> x;
            public List<EnemyFactory> y;

            public MyFactory(int id, int ncy, int prod, int incoming, List<Factory> x, List<EnemyFactory> y)
            {
                this.id = id;
                this.ncy = ncy;
                this.prod = prod;
                this.incoming = incoming;
                this.x = x;
                this.y = y;
                GatherInfo();
            }

            private void GatherInfo()
            {
                foreach (Factory item in x)
                {
                    foreach (EnemyFactory item1 in y)
                    {
                        if (item.fact1 == id && item.fact2 == item1.id ||
                        item.fact2 == id && item.fact1 == item1.id)
                        {
                            item1.d = item.dist;
                        }
                    }
                }
            }
        }

        class EnemyFactory(int id, int type, int ncy, int prod, int d)
        {
            public int id = id, type = type, ncy = ncy, prod = prod, d = d;
        }

        class Troop(int target, int ncy)
        {
            public int target = target, ncy = ncy;
        }
    }
}
