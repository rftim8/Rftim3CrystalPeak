using System.Text;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class HungerGames
    {
        public HungerGames()
        {
            List<Player> players = new()
            {
                new Player("Ann", "", new List<string>()),
                new Player("Isaac", "", new List<string>()),
                new Player("Mary", "", new List<string>()),
                new Player("Max", "", new List<string>()),
                new Player("Thomas", "", new List<string>())
            };
            List<string> info = new()
            {
                "Max killed Isaac",
                "Isaac killed Mary",
                "Mary killed Max",
                "Thomas killed Ann"
            };

            Solve(players, info);
        }

        private static void Solve(List<Player> players, List<string> info)
        {
            players.Sort((a, b) => a.name.CompareTo(b.name));

            foreach (string statement in info)
            {
                foreach (Player player in players)
                {
                    if (statement.Split(' ')[0] == player.name)
                    {
                        foreach (Player player1 in players)
                        {
                            if (statement.Split(' ')[0] != player1.name && statement.Contains(player1.name)) player.killed.Add(player1.name);
                        }
                    }
                }
            }

            foreach (Player player3 in players)
            {
                foreach (Player player in players)
                {
                    if (player.killed.Contains(player3.name)) player3.killer = player.name;
                }
            }

            foreach (Player player2 in players)
            {
                Console.WriteLine($"Name: {player2.name}");
                StringBuilder sb = new();
                if (player2.killed.Count == 0) Console.WriteLine($"Killed: None");
                else
                {
                    player2.killed.Sort();
                    foreach (string killed in player2.killed)
                    {
                        sb.Append($"{killed}, ");
                    }
                    Console.WriteLine($"Killed: {sb.ToString()[..^2]}");
                }

                if (player2.killer == "") Console.WriteLine($"Killer: Winner");
                else Console.WriteLine($"Killer: {player2.killer}");
                if (players.IndexOf(player2) != players.Count - 1) Console.WriteLine();
            }
        }

        class Player
        {
            public string name, killer;
            public List<string> killed;

            public Player(string name, string killer, List<string> killed)
            {
                this.name = name;
                this.killer = killer;
                this.killed = killed;
            }
        }
    }
}
