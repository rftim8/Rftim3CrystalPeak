using System.Collections;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class VoxCodeiEpisode1
    {
        public VoxCodeiEpisode1()
        {
            //int b = 3;
            //string[] mapRow = new string[7]
            //{
            //    "...@...",
            //    "...#...",
            //    ".......",
            //    ".....@@",
            //    ".......",
            //    ".......",
            //    "......."
            //};

            //int b = 2;
            //string[] mapRow = new string[6]
            //{
            //    "........",
            //    "......@.",
            //    "@@@.@@@@",
            //    "......@.",
            //    "........",
            //    "........"
            //};

            int b = 6;
            string[] mapRow = new string[9]
            {
                "............",
                ".#@@@.#@@@..",
                ".@....@.....",
                ".@....@.....",
                ".@....@..@#.",
                ".@....@...@.",
                "..@@@..@@@#.",
                "............",
                "............"
            };

            Solve(mapRow, b);
        }

        private static void Solve(string[] mapRow, int b)
        {
            int n = mapRow.Length;
            int m = mapRow[0].Length;

            HashSet<Node> nodes = new();

            int id = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mapRow[i][j] == '@')
                    {
                        nodes.Add(new Node(id, i, j));
                        id++;
                    }
                }
            }

            List<Bomb> bombs = new();

            id = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mapRow[i][j] == '.')
                    {
                        bombs.Add(new Bomb(id, i, j, new HashSet<Node>()));
                        id++;
                    }
                }
            }

            //foreach (Node item in nodes)
            //{
            //    Console.WriteLine($"Node {item.id}: {item.y} {item.x}");
            //}

            foreach (Bomb item in bombs)
            {
                Console.WriteLine($"Bomb {item.id}: {item.y} {item.x}");

                int range = 3;
                int vert = item.y;
                // north
                while (vert - 1 > 0 && range > 0 && mapRow[vert - 1][item.x] != '#')
                {
                    vert--;
                    if (mapRow[vert][item.x] == '@')
                    {
                        foreach (Node item2 in nodes)
                        {
                            if (item2.y == vert && item2.x == item.x) item.nodes.Add(item2);
                        }
                    }
                    range--;
                }

                range = 3;
                vert = item.y;
                // south
                while (vert + 1 < n && range > 0 && mapRow[vert + 1][item.x] != '#')
                {
                    vert++;
                    if (mapRow[vert][item.x] == '@')
                    {
                        foreach (Node item2 in nodes)
                        {
                            if (item2.y == vert && item2.x == item.x) item.nodes.Add(item2);
                        }
                    }
                    range--;
                }

                range = 3;
                int horiz = item.x;
                // west
                while (horiz - 1 > 0 && range > 0 && mapRow[item.y][horiz - 1] != '#')
                {
                    horiz--;
                    if (mapRow[item.y][horiz] == '@')
                    {
                        foreach (Node item2 in nodes)
                        {
                            if (item2.y == item.y && item2.x == horiz) item.nodes.Add(item2);
                        }
                    }
                    range--;
                }

                range = 3;
                horiz = item.x;
                // east
                while (horiz + 1 < m && range > 0 && mapRow[item.y][horiz + 1] != '#')
                {
                    horiz++;
                    if (mapRow[item.y][horiz] == '@')
                    {
                        foreach (Node item2 in nodes)
                        {
                            if (item2.y == item.y && item2.x == horiz) item.nodes.Add(item2);
                        }
                    }
                    range--;
                }


                foreach (Node item1 in item.nodes)
                {
                    Console.WriteLine($"Node {item1.id}: {item1.y} {item1.x}");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < bombs.Count; i++)
            {
                if (bombs[i].nodes.Count == 0)
                {
                    bombs.Remove(bombs[i]);
                    i--;
                }
            }

            //foreach (Bomb item in bombs)
            //{
            //    Console.WriteLine($"Bomb {item.id}: {item.y} {item.x}");
            //}

            bombs = bombs.OrderByDescending(o => o.nodes.Count).ToList();

            for (int i = 0; i <= b; i++)
            {
                IEnumerable x = Combinations(bombs, i);

                foreach (IEnumerable<Bomb> item in x)
                {
                    HashSet<Node> attack = new();

                    foreach (Bomb item1 in item)
                    {
                        foreach (Node item2 in item1.nodes)
                        {
                            if (!attack.Contains(item2))
                            {
                                attack.Add(item2);
                            }
                        }
                    }

                    int z = 0;
                    foreach (Node item1 in attack)
                    {
                        if (nodes.Contains(item1))
                        {
                            z++;
                        }
                    }
                    if (z == nodes.Count)
                    {
                        foreach (Bomb item1 in item)
                        {
                            Console.WriteLine($"Bomb {item1.id}: {item1.y} {item1.x} ");
                        }
                        return;
                    }

                    Console.WriteLine();
                }
            }

        }

        private static bool NextCombination(IList<int> num, int n, int k)
        {
            bool finished;
            bool changed = finished = false;

            if (k <= 0) return false;

            for (int i = k - 1; !finished && !changed; i--)
            {
                if (num[i] < n - 1 - (k - 1) + i)
                {
                    num[i]++;

                    if (i < k - 1)
                    {
                        for (int j = i + 1; j < k; j++)
                        {
                            num[j] = num[j - 1] + 1;
                        }
                    }
                    changed = true;
                }
                finished = i == 0;
            }

            return changed;
        }

        private static IEnumerable Combinations<T>(IEnumerable<T> elements, int k)
        {
            T[] elem = elements.ToArray();
            int size = elem.Length;

            if (k > size) yield break;

            int[] numbers = new int[k];

            for (int i = 0; i < k; i++)
                numbers[i] = i;

            do
            {
                yield return numbers.Select(n => elem[n]);
            } while (NextCombination(numbers, size, k));
        }

        private static void DamageMap(string[] mapRow)
        {
            int n = mapRow.Length;
            int m = mapRow[0].Length;
            char[,] map = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    map[i, j] = mapRow[i][j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (map[i, j] == '@')
                    {
                        int range = 3;
                        int vert = i;
                        // north
                        while (vert > 0 && map[vert - 1, j] != '#' && range > 0)
                        {
                            vert--;
                            if (map[vert, j] != '@')
                            {
                                if (map[vert, j] == '.') map[vert, j] = '1';
                                else map[vert, j] = char.Parse((int.Parse(map[vert, j].ToString()) + 1).ToString());
                            }
                            range--;
                        }

                        range = 3;
                        vert = i;
                        // south
                        while (vert < n - 1 && map[vert + 1, j] != '#' && range > 0)
                        {
                            vert++;
                            if (map[vert, j] != '@')
                            {
                                if (map[vert, j] == '.') map[vert, j] = '1';
                                else map[vert, j] = char.Parse((int.Parse(map[vert, j].ToString()) + 1).ToString());
                            }
                            range--;
                        }

                        range = 3;
                        int horiz = j;
                        // west
                        while (horiz > 0 && map[i, horiz - 1] != '#' && range > 0)
                        {
                            horiz--;
                            if (map[i, horiz] != '@')
                            {
                                if (map[i, horiz] == '.') map[i, horiz] = '1';
                                else map[i, horiz] = char.Parse((int.Parse(map[i, horiz].ToString()) + 1).ToString());
                            }
                            range--;
                        }

                        range = 3;
                        horiz = j;
                        // east
                        while (horiz < m - 1 && map[i, horiz + 1] != '#' && range > 0)
                        {
                            horiz++;
                            if (map[i, horiz] != '@')
                            {
                                if (map[i, horiz] == '.') map[i, horiz] = '1';
                                else map[i, horiz] = char.Parse((int.Parse(map[i, horiz].ToString()) + 1).ToString());
                            }
                            range--;
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        private class Bomb
        {
            public int id, y, x;
            public HashSet<Node>? nodes;

            public Bomb(int id, int y, int x, HashSet<Node>? nodes)
            {
                this.id = id;
                this.y = y;
                this.x = x;
                this.nodes = nodes;
            }
        }

        private class Node
        {
            public int id, y, x;

            public Node(int id, int y, int x)
            {
                this.id = id;
                this.y = y;
                this.x = x;
            }
        }
    }
}
