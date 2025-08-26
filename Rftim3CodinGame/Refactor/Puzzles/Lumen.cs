namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class Lumen
    {
        public Lumen()
        {
            const int n = 5;
            int l = 3;
            string[,] cell = new string[n, n] {
                { "X", "X", "X", "X", "X" },
                { "X", "C", "X", "X", "X" },
                { "X", "X", "X", "X", "X" },
                { "X", "X", "X", "X", "X" },
                { "X", "X", "X", "X", "X" }
            };
            //string[,] cell = new string[n, n] {
            //    { "C", "X", "X", "X", "C" },
            //    { "X", "X", "X", "X", "X" },
            //    { "X", "X", "X", "X", "X" },
            //    { "X", "X", "X", "X", "X" },
            //    { "C", "X", "X", "X", "C" }
            //};

            Solve(n, l, cell);
        }

        private static void Solve(int n, int l, string[,] cell)
        {
            int cCount = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cell[i, j] == "C") cCount++;
                }
            }

            int[] cX = new int[cCount];
            int[] cY = new int[cCount];

            int ccount = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cell[i, j] == "C")
                    {
                        cX[ccount] = i;
                        cY[ccount] = j;
                        ccount++;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < cCount; k++)
                    {
                        if (Math.Abs(i - cX[k]) < l && Math.Abs(j - cY[k]) < l && cell[i, j] != "C") cell[i, j] = "A";
                        else
                        {
                            if (cell[i, j] != "C" && cell[i, j] != "A") cell[i, j] = "0";
                        }
                    }
                }
            }

            int dark = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cell[i, j] == "0") dark++;
                    Console.Write(cell[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine(cCount == 0 ? n * n : dark);
        }
    }
}
