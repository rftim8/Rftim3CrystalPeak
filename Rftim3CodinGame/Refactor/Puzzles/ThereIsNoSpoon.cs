namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class ThereIsNoSpoon
    {
        public ThereIsNoSpoon()
        {
            //Solve();
        }

        private static void Solve()
        {
            List<Node> nodes = new();

            int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
            int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
            string[] lines = new string[height];

            for (int i = 0; i < height; i++)
            {
                string line = Console.ReadLine(); // width characters, each either 0 or .
                lines[i] = line;
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int nextX = -1;
                    int nextY = -1;
                    int prevX = -1;
                    int prevY = -1;

                    if (lines[i].Substring(j, 1) == "0")
                    {
                        int x = j;
                        int y = i;

                        int a = 1;
                        int b = 1;

                        bool right = false;
                        bool down = false;

                        while (j + a < width)
                        {
                            if (!right)
                            {
                                if (lines[i].Substring(j + a, 1) == "0")
                                {
                                    nextX = j + a;
                                    nextY = i;
                                    right = true;
                                }
                                else
                                {
                                    nextX = -1;
                                    nextY = -1;
                                }
                            }
                            a++;
                        }

                        while (i + b < height)
                        {

                            if (!down)
                            {
                                if (lines[i + b].Substring(j, 1) == "0")
                                {
                                    prevX = j;
                                    prevY = i + b;
                                    down = true;
                                }
                                else
                                {
                                    prevX = -1;
                                    prevY = -1;
                                }
                            }
                            b++;
                        }


                        nodes.Add(new Node(x, y, nextX, nextY, prevX, prevY));
                    }
                }
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine($"{nodes[i].x} {nodes[i].y} {nodes[i].nextX} {nodes[i].nextY} {nodes[i].prevX} {nodes[i].prevY}");
            }
        }

        private class Node
        {
            public int x, y, nextX, nextY, prevX, prevY;

            public Node(int x, int y, int nextX, int nextY, int prevX, int prevY)
            {
                this.x = x;
                this.y = y;
                this.nextX = nextX;
                this.nextY = nextY;
                this.prevX = prevX;
                this.prevY = prevY;
            }
        }
    }
}
