namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class HorseRacingDuals
    {
        public HorseRacingDuals()
        {
            List<int> strenghts = new()
            {
                3,5,9,8
            };

            Solve(strenghts);
        }

        private static void Solve(List<int> strenghts)
        {
            strenghts.Sort();

            int result = 0;
            for (int i = 0; i < strenghts.Count; i++)
            {
                if (i == 0) result = strenghts.Last();
                else
                {
                    int x = strenghts[i] - strenghts[i - 1];
                    if (x < result) result = x;
                }
            }
            Console.WriteLine(result);
        }
    }
}
