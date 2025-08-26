namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Onboarding
    {
        public Onboarding()
        {
            //Solve();
        }

        private static void Solve()
        {
            // game loop
            while (true)
            {
                string enemy1 = Console.ReadLine(); // name of enemy 1
                int dist1 = int.Parse(Console.ReadLine()); // distance to enemy 1
                string enemy2 = Console.ReadLine(); // name of enemy 2
                int dist2 = int.Parse(Console.ReadLine()); // distance to enemy 2

                Console.WriteLine(dist1 < dist2 ? enemy1 : enemy2);
            }
        }
    }
}
