namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class DeathFirstSearch
    {
        public DeathFirstSearch()
        {
            //Solve();
        }

        private static void Solve()
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
            int l = int.Parse(inputs[1]); // the number of links
            int e = int.Parse(inputs[2]); // the number of exit gateways
            List<Point> points = new();
            List<int> gateways = new();
            for (int i = 0; i < l; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int n1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
                int n2 = int.Parse(inputs[1]);
                points.Add(new Point(n1, n2));
            }
            for (int i = 0; i < e; i++)
            {
                int ei = int.Parse(Console.ReadLine()); // the index of a gateway node
                gateways.Add(ei);
            }

            // game loop
            while (true)
            {
                int si = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn
                int counter = 0;

                for (int i = 0; i < points.Count; i++)
                {
                    foreach (int gateway in gateways)
                    {
                        if (points[i].x == si && points[i].y == gateway || points[i].y == si && points[i].x == gateway)
                        {
                            Console.WriteLine($"{points[i].x} {points[i].y}");
                            points.RemoveAt(i);
                            counter++;
                            break;
                        }
                    }
                }

                if (counter == 0)
                {
                    Console.WriteLine($"{points[0].x} {points[0].y}");
                    points.RemoveAt(0);
                }
            }
        }

        class Point
        {
            public int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
