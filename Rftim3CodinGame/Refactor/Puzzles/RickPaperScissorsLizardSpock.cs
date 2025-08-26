namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class RickPaperScissorsLizardSpock
    {
        public RickPaperScissorsLizardSpock()
        {
            int n = 8;
            int[] numPlayer = [4, 1, 8, 3, 7, 5, 6, 2];
            string[] signPlayer = ["R", "P", "P", "R", "C", "S", "L", "L"];

            Solve(n, numPlayer, signPlayer);
        }

        private static void Solve(int n, int[] numPlayer, string[] signPlayer)
        {
            char rock = 'R';
            char paper = 'P';
            char scissors = 'C';
            char lizard = 'L';
            char spock = 'S';
            int n1 = n;

            List<string> streak = new();

            while (n1 != 1)
            {
                for (int i = 1; i < n1 + 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        string x = $"{signPlayer[i - 2]} {signPlayer[i - 1]}";
                        Console.WriteLine(x);
                        string y = $"{numPlayer[i - 2]},{signPlayer[i - 2]};{numPlayer[i - 1]},{signPlayer[i - 1]}";
                        Console.WriteLine(y);

                        if (x.Contains($"{scissors} {paper}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{paper} {scissors}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{rock} {paper}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{paper} {rock}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{rock} {lizard}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{lizard} {rock}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{spock} {lizard}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{lizard} {spock}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{spock} {scissors}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{scissors} {spock}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{lizard} {scissors}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{scissors} {lizard}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{lizard} {paper}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{paper} {lizard}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{spock} {paper}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{paper} {spock}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{spock} {rock}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{rock} {spock}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{scissors} {rock}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 2] = 0;
                            signPlayer[i - 2] = "x";
                        }
                        else if (x.Contains($"{rock} {scissors}"))
                        {
                            streak.Add(y);
                            numPlayer[i - 1] = 0;
                            signPlayer[i - 1] = "x";
                        }
                        else if (x.Contains($"{rock} {rock}"))
                        {
                            streak.Add(y);
                            if (numPlayer[i - 2] > numPlayer[i - 1])
                            {
                                numPlayer[i - 2] = 0;
                                signPlayer[i - 2] = "x";
                            }
                            else
                            {
                                numPlayer[i - 1] = 0;
                                signPlayer[i - 1] = "x";
                            }
                        }
                        else if (x.Contains($"{paper} {paper}"))
                        {
                            streak.Add(y);
                            if (numPlayer[i - 2] > numPlayer[i - 1])
                            {
                                numPlayer[i - 2] = 0;
                                signPlayer[i - 2] = "x";
                            }
                            else
                            {
                                numPlayer[i - 1] = 0;
                                signPlayer[i - 1] = "x";
                            }
                        }
                        else if (x.Contains($"{scissors} {scissors}"))
                        {
                            streak.Add(y);
                            if (numPlayer[i - 2] > numPlayer[i - 1])
                            {
                                numPlayer[i - 2] = 0;
                                signPlayer[i - 2] = "x";
                            }
                            else
                            {
                                numPlayer[i - 1] = 0;
                                signPlayer[i - 1] = "x";
                            }
                        }
                        else if (x.Contains($"{lizard} {lizard}"))
                        {
                            streak.Add(y);
                            if (numPlayer[i - 2] > numPlayer[i - 1])
                            {
                                numPlayer[i - 2] = 0;
                                signPlayer[i - 2] = "x";
                            }
                            else
                            {
                                numPlayer[i - 1] = 0;
                                signPlayer[i - 1] = "x";
                            }
                        }
                        else if (x.Contains($"{spock} {spock}"))
                        {
                            streak.Add(y);
                            if (numPlayer[i - 2] > numPlayer[i - 1])
                            {
                                numPlayer[i - 2] = 0;
                                signPlayer[i - 2] = "x";
                            }
                            else
                            {
                                numPlayer[i - 1] = 0;
                                signPlayer[i - 1] = "x";
                            }
                        }
                    }
                }

                List<int> x1 = new();
                List<string> y1 = new();

                for (int i = 0; i < n1; i++)
                {
                    if (numPlayer[i] != 0)
                    {
                        x1.Add(numPlayer[i]);
                        y1.Add(signPlayer[i]);
                    }
                }

                numPlayer = new int[x1.Count];
                signPlayer = new string[y1.Count];

                for (int i = 0; i < x1.Count; i++)
                {
                    numPlayer[i] = x1[i];
                    signPlayer[i] = y1[i];
                }
                n1 = x1.Count;
            }

            if (n1 == 1)
            {
                Console.WriteLine(numPlayer[0]);
                for (int i = 0; i < streak.Count; i++)
                {
                    if (i < streak.Count - 1)
                    {
                        if (streak[i].Contains($"{numPlayer[0]},{signPlayer[0]}"))
                        {
                            if ($"{streak[i].Split(';')[0]}" == $"{numPlayer[0]},{signPlayer[0]}") Console.Write($"{streak[i].Split(';')[1].Split(',')[0]} ");
                            else if ($"{streak[i].Split(';')[1]}" == $"{numPlayer[0]},{signPlayer[0]}") Console.Write($"{streak[i].Split(';')[0].Split(',')[0]} ");
                        }
                    }
                    else
                    {
                        if (streak[i].Contains($"{numPlayer[0]},{signPlayer[0]}"))
                        {
                            if ($"{streak[i].Split(';')[0]}" == $"{numPlayer[0]},{signPlayer[0]}") Console.Write($"{streak[i].Split(';')[1].Split(',')[0]}");
                            else if ($"{streak[i].Split(';')[1]}" == $"{numPlayer[0]},{signPlayer[0]}") Console.Write($"{streak[i].Split(';')[0].Split(',')[0]}");
                        }
                    }
                }
            }
        }
    }
}
