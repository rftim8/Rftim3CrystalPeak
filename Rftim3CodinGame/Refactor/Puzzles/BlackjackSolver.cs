namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class BlackjackSolver
    {
        public BlackjackSolver()
        {
            string bankCards = "8 2 2";
            string playerCards = "7 6";

            Solve(bankCards, playerCards);
        }

        private static void Solve(string bank, string player)
        {
            bank = bank.Replace("J", "10").Replace("Q", "10").Replace("K", "10").Replace("A", "1");
            int bankT = bank.Split(' ').Select(int.Parse).ToList().Sum();
            int bankAces = bank.Split(' ').Select(int.Parse).Where(o => o == 1).Count();

            for (int i = 0; i < bankAces; i++) if (bankT + 10 <= 21) bankT += 10;

            player = player.Replace("J", "10").Replace("Q", "10").Replace("K", "10").Replace("A", "1");
            int playerT = player.Split(' ').Select(int.Parse).ToList().Sum();
            int playerAces = player.Split(' ').Select(int.Parse).Where(o => o == 1).Count();

            for (int i = 0; i < playerAces; i++) if (playerT + 10 <= 21) playerT += 10;

            Console.WriteLine($"{bankT} : {bankAces}");
            Console.WriteLine($"{playerT} : {playerAces}");

            if ((player == "1 10" || player == "10 1") && bank != "1 10" && bank != "10 1") Console.WriteLine("Blackjack!");
            else if ((bank == "1 10" || bank == "10 1") && player != "1 10" && player != "10 1") Console.WriteLine("Bank");
            else if ((bank == "1 10" || bank == "10 1") && (player == "1 10" || player == "10 1")) Console.WriteLine("Draw");
            else
                if (bankT <= 21 && playerT > 21) Console.WriteLine("Bank");
            else if (bankT > 21 && playerT <= 21) Console.WriteLine("Player");
            else if (bankT > 21 && playerT > 21) Console.WriteLine("Bank");
            else
                if (bankT > playerT) Console.WriteLine("Bank");
            else if (bankT < playerT) Console.WriteLine("Player");
            else if (bankT == playerT) Console.WriteLine("Draw");
        }
    }
}
