namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class MayTheTriforceBeWithYou
    {
        public MayTheTriforceBeWithYou()
        {
            int n = 5;

            Solve(n);
        }

        private static void Solve(int n)
        {
            int h = n * 2;
            int markPos = h - 1;
            int upperCount = 1;
            int lowerCount = 1;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < h * 2 - 1; j++)
                {
                    if (i < n)
                    {
                        if (i == 0 && j == 0) Console.Write(".");
                        else if (j > markPos - upperCount && j < markPos + upperCount) Console.Write("*");
                        else if (j < markPos + upperCount) Console.Write(" ");
                    }
                    else
                    {
                        if (j > n - 1 - lowerCount && j < n - 1 + lowerCount || j > n - 1 + h - lowerCount && j < n - 1 + h + lowerCount) Console.Write("*");
                        else if (j < n || j < n + h) Console.Write(" ");
                    }
                }
                if (i < n) upperCount++;
                else lowerCount++;
                Console.WriteLine();
            }
        }
    }
}
