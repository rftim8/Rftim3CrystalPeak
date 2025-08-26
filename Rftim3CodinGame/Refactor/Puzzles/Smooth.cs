namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Smooth
    {
        public Smooth()
        {
            //List<long> f = new()
            //{
            //    1,
            //    2,
            //    3,
            //    4,
            //    5,
            //    6,
            //    7,
            //    8,
            //    9,
            //    10
            //};

            List<long> f = new()
            {
                630,
                650,
                732,
                760,
                806,
                872,
                966,
                1001,
                1092,
                1160,
                1216,
                1290,
                1400,
                1460,
                1539
            };

            Solve(f);
        }

        private static void Solve(List<long> f)
        {
            List<int> bundles = new()
            {
                5,
                3,
                2
            };

            foreach (long item in f)
            {
                long temp = item;

                while (temp != 1)
                {
                    int counter = 0;

                    foreach (int bundle in bundles)
                    {
                        if (temp == 1) break;

                        if (temp % bundle == 0)
                        {
                            temp /= bundle;
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        Console.WriteLine($"DEFEAT");
                        break;
                    }
                }
                if (temp == 1) Console.WriteLine($"VICTORY");
            }
        }
    }
}
