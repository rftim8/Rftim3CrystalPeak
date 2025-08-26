namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class HorseRacingHyperduals
    {
        public HorseRacingHyperduals()
        {
            int N = 10;

            List<Horse> horses = new()
            {
                new Horse(0, 6850207, 0),
                new Horse(1, 8707138, 0),
                new Horse(2, 8028585, 0),
                new Horse(3, 3635318, 0),
                new Horse(4, 8612162, 0),
                new Horse(5, 6854699, 0),
                new Horse(6, 7106093, 0),
                new Horse(7, 3721952, 0),
                new Horse(8, 2670046, 0),
                new Horse(9, 1746583, 0)
            };

            Solve(N, horses);
        }

        private static void Solve(int n, List<Horse> horses)
        {
            int dist = 10000000;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (horses[i].id != horses[j].id)
                    {
                        int distCalc = Math.Abs(horses[i].v - horses[j].v) + Math.Abs(horses[i].e - horses[j].e);

                        if (distCalc < dist) dist = distCalc;
                    }
                }
            }

            Console.WriteLine(dist);
        }

        public class Horse
        {
            public int id, v, e;

            public Horse(int id, int v, int e)
            {
                this.id = id;
                this.v = v;
                this.e = e;
            }
        }
    }
}
