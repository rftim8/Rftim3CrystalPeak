namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TheDart101
    {
        public TheDart101()
        {
            //List<Player1> players = new()
            //{
            //    new Player1("Hugo", 0, 0),
            //    new Player1("Guillaume", 0, 0)
            //};
            //List<string> shots = new()
            //{
            //    "10 5 3*18 15 5 4 8",
            //    "5 5 10 2*19 5 6 2*5 1 20 1"
            //};

            //List<Player1> players = new()
            //{
            //    new Player1("Candice", 0, 0),
            //    new Player1("Elise", 0, 0)
            //};
            //List<string> shots = new()
            //{
            //    "10 5 3*18 20 X 2*14 4",
            //    "5 5 10 2*19 5 6 2*5 1 20 1"
            //};

            //List<Player1> players = new()
            //{
            //    new Player1("Fred", 0, 0),
            //    new Player1("Charles", 0, 0)
            //};
            //List<string> shots = new()
            //{
            //    "10 6 3*18 X 19 X 2*25 2",
            //    "5 5 10 2*19 5 6 2*5 1 20 1"
            //};

            //List<Player1> players = new()
            //{
            //    new Player1("Henry", 0, 0),
            //    new Player1("Herve", 0, 0)
            //};
            //List<string> shots = new()
            //{
            //    "2*5 5 5 2*19 5 6 10 1 20 1",
            //    "3*17 5 12 X X 15 3*16 20"
            //};

            List<Player> players = new()
            {
                new Player("Eric", 0, 0),
                new Player("Cecile", 0, 0)
            };
            List<string> shots = new()
            {
                "2*5 5 5 2*19 5 6 10 1 20 1",
                "3*17 5 12 X X X 2*25 3*17"
            };

            Solve(players, shots);
        }

        private static void Solve(List<Player> players, List<string> shots)
        {
            for (int i = 0; i < players.Count; i++)
            {
                int nrShots = shots[i].Split(' ').Length;
                int total = 0;
                int counterShots = 0;
                int counterMissed = 0;
                int nrRounds = 0;
                string lastShot = "";

                for (int j = 0; j < nrShots; j++)
                {
                    counterShots++;
                    string shot = shots[i].Split(' ')[j];

                    if (shot != "X" && !shot.Contains('*'))
                    {
                        if (total + int.Parse(shot) <= 101) total += int.Parse(shot);
                        else
                        {
                            nrRounds++;
                            counterShots = 0;
                            counterMissed = 0;
                        }
                    }
                    else if (shot.Contains('*'))
                    {
                        if (total + int.Parse(shot.Split('*')[0]) * int.Parse(shot.Split('*')[1]) <= 101) total += int.Parse(shot.Split('*')[0]) * int.Parse(shot.Split('*')[1]);
                        else
                        {
                            nrRounds++;
                            counterShots = 0;
                            counterMissed = 0;
                        }
                    }
                    else if (shot == "X")
                    {
                        counterMissed++;
                        if (counterMissed == 1 && (counterShots == 1 || counterShots == 2 || counterShots == 3)) total -= 20;

                        if (counterMissed == 2 && counterShots == 3 && lastShot != "X")
                        {
                            total -= 20;
                            nrRounds++;
                            counterShots = 0;
                            counterMissed = 0;
                        }
                        else if (counterMissed == 2 && counterShots == 2) total -= 30;
                        else if (counterMissed == 2 && counterShots == 3 && lastShot == "X")
                        {
                            total -= 30;
                            nrRounds++;
                            counterShots = 0;
                            counterMissed = 0;
                        }

                        if (counterMissed == 3 && counterShots == 3)
                        {
                            total = 0;
                            nrRounds++;
                            counterShots = 0;
                            counterMissed = 0;
                        }
                    }
                    if (counterShots % 3 == 0 && counterShots != 0)
                    {
                        nrRounds++;
                        counterShots = 0;
                        counterMissed = 0;
                    }
                    lastShot = shot;
                }

                players[i].score = total;
                players[i].rounds = nrRounds;
            }
            List<Player> finalists = players.Where(o => o.score <= 101).ToList();
            finalists = finalists.OrderByDescending(o => o.score).ThenBy(o => o.rounds).ToList();

            foreach (Player player in finalists)
            {
                Console.WriteLine($"{player.name}: {player.score} in {player.rounds}");
            }

            Console.WriteLine($"{finalists[0].name}");
        }

        class Player
        {
            public string name;
            public int score, rounds;

            public Player(string name, int score, int rounds)
            {
                this.name = name;
                this.score = score;
                this.rounds = rounds;
            }
        }
    }
}
