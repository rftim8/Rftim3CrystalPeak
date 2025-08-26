namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class BrickInTheWall
    {
        public BrickInTheWall()
        {
            int x = 2;
            int n = 3;
            List<int> bricks = new()
            {
                100,
                10,
                150
            };

            //int X = 7;
            //int N = 42;
            //List<int> bricks = new()
            //{
            //    21,
            //    15,
            //    5,
            //    9,
            //    5,
            //    7,
            //    9,
            //    11,
            //    11,
            //    11,
            //    20,
            //    3,
            //    8,
            //    21,
            //    8,
            //    10,
            //    19,
            //    15,
            //    6,
            //    5,
            //    18,
            //    6,
            //    8,
            //    17,
            //    18,
            //    12,
            //    1,
            //    10,
            //    19,
            //    5,
            //    14,
            //    16,
            //    9,
            //    15,
            //    3,
            //    5,
            //    4,
            //    5,
            //    3,
            //    6,
            //    19,
            //    1
            //};

            Solve(x, n, bricks);
        }

        private static void Solve(int x, int n, List<int> bricks)
        {
            int sets = 1;
            int setsLevel = x;
            bricks.Sort((a, b) => b.CompareTo(a));
            int level = 1;
            decimal totalWork = 0.0M;

            foreach (int brick in bricks) Console.WriteLine($"{brick}");

            while (sets <= n)
            {
                int brickskMass = 0;

                for (int i = sets - 1; i < setsLevel; i++)
                {
                    if (bricks.Count - i > 0) brickskMass += bricks[i];
                }

                totalWork += (level - 1) * (decimal)(6.5 / 100) * 10 * brickskMass;

                Console.WriteLine($"Level {level}: {brickskMass}");

                sets += x;
                setsLevel += x;
                level++;
            }

            Console.WriteLine($"{totalWork}");
        }
    }
}
