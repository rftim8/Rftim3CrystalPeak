namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class AddemUp
    {
        public AddemUp()
        {
            List<int> cards = [1, 4, 3, 4];

            Solve(cards);
        }

        private static void Solve(List<int> cards)
        {
            int sum = 0;

            while (cards.Count > 1)
            {
                cards.Sort();

                int combo = cards[0] + cards[1];
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                cards.Add(combo);
                sum += combo;
            }

            Console.WriteLine($"{sum}");
        }
    }
}
