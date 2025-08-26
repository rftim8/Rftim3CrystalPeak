namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class GhostLegs
    {
        public GhostLegs()
        {
            int w = 13;
            int h = 8;
            string[] line = new string[]
            {
                "A  B  C  D  E",
                "|  |  |  |  |",
                "|  |--|  |  |",
                "|--|  |  |  |",
                "|  |  |--|  |",
                "|  |--|  |--|",
                "|  |  |  |  |",
                "1  2  3  4  5"
            };

            Solve(w, h, line);
        }

        private static void Solve(int w, int h, string[] line)
        {
            for (int i = 0; i < w; i++)
            {
                string player = line[0][i].ToString();

                if (player != " ")
                {
                    int posCol = line[0].IndexOf(player);

                    for (int j = 1; j < h - 1; j++)
                    {
                        bool executed = false;
                        for (int k = 0; k < w; k++)
                        {
                            if (k == posCol)
                            {
                                if (!executed)
                                {
                                    string left;
                                    string right;
                                    if (posCol == 0)
                                    {
                                        left = line[j][k].ToString();
                                        right = line[j][k + 1].ToString();
                                    }
                                    else if (posCol == w - 1)
                                    {
                                        left = line[j][k - 1].ToString();
                                        right = line[j][k].ToString();
                                    }
                                    else
                                    {
                                        left = line[j][k - 1].ToString();
                                        right = line[j][k + 1].ToString();
                                    }

                                    if (left == "-")
                                    {
                                        posCol -= 3;
                                        executed = true;
                                    }
                                    else if (right == "-")
                                    {
                                        posCol += 3;
                                        executed = true;
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine($"{player}{line[h - 1][posCol]}");
                }
            }
        }
    }
}
