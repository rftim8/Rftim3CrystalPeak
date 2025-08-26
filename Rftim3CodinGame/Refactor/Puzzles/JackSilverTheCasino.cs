namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class JackSilverTheCasino
    {
        public JackSilverTheCasino()
        {
            int cash = 70545;
            List<string> plays = new()
            {
                "31 PLAIN 30",
                "18 PLAIN 35",
                "14 PLAIN 32",
                "25 ODD",
                "13 PLAIN 9",
                "14 PLAIN 34",
                "32 ODD",
                "26 PLAIN 9",
                "29 EVEN",
                "7 PLAIN 21",
                "32 PLAIN 29",
                "0 PLAIN 7",
                "7 PLAIN 34",
                "13 PLAIN 14",
                "22 PLAIN 8",
                "25 PLAIN 28",
                "11 PLAIN 20",
                "14 ODD",
                "23 ODD",
                "13 PLAIN 22",
                "2 ODD",
                "23 EVEN",
                "17 ODD",
                "30 EVEN",
                "28 PLAIN 28",
                "5 PLAIN 36",
                "13 EVEN",
                "22 PLAIN 11",
                "5 EVEN",
                "32 PLAIN 25",
                "13 ODD",
                "10 EVEN",
                "28 ODD",
                "15 PLAIN 2",
                "33 EVEN",
                "29 ODD",
                "1 EVEN",
                "19 PLAIN 12",
                "0 PLAIN 34",
                "24 EVEN",
                "16 PLAIN 36",
                "4 EVEN",
                "35 PLAIN 13",
                "14 PLAIN 34",
                "30 ODD",
                "13 EVEN",
                "29 ODD",
                "7 EVEN",
                "18 PLAIN 20",
                "33 ODD",
                "24 PLAIN 28",
                "34 PLAIN 34",
                "33 EVEN",
                "32 EVEN",
                "10 EVEN",
                "13 ODD",
                "35 PLAIN 26"
            };

            Solve(cash, plays);
        }

        private static void Solve(int cash, List<string> plays)
        {
            foreach (string play in plays)
            {
                int bet = (int)Math.Ceiling((decimal)cash / 4);
                int ball = int.Parse(play.Split(' ')[0]);
                string call = play.Split(' ')[1];
                int number = 0;

                if (play.Split(' ').Length == 3) number = int.Parse(play.Split(' ')[2]);

                switch (call)
                {
                    case "EVEN":
                        if (ball % 2 != 0 || ball == 0) cash -= bet;
                        else cash += bet;
                        break;
                    case "ODD":
                        if (ball % 2 == 0) cash -= bet;
                        else cash += bet;
                        break;
                    case "PLAIN":
                        if (ball == number) cash += 35 * bet;
                        else cash -= bet;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"{cash}");
        }
    }
}
