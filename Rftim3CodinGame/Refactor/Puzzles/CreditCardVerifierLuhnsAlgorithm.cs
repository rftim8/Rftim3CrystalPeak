namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class CreditCardVerifierLuhnsAlgorithm
    {
        public CreditCardVerifierLuhnsAlgorithm()
        {
            string card = "4556 7375 8689 9855";

            Solve(card.Replace(" ", ""));
        }

        private static void Solve(string card)
        {
            int nr1 = 0;
            int nr2 = 0;

            for (int i = card.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    int x = 0;
                    int temp = int.Parse(card[i].ToString()) * 2;
                    for (int j = 0; j < temp.ToString().Length; j++) x += int.Parse(temp.ToString()[j].ToString());
                    nr1 += x;
                }
                else nr2 += int.Parse(card[i].ToString());
            }

            Console.WriteLine(nr1);
            Console.WriteLine(nr2);

            Console.WriteLine((nr1 + nr2) % 10 != 0 ? "NO" : "YES");
        }
    }
}
