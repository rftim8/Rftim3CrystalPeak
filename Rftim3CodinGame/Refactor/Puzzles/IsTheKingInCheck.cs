namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class IsTheKingInCheck
    {
        public IsTheKingInCheck()
        {
            const int n = 8;
            string[] chessRow = new string[n] {
                "________",
                "________",
                "________",
                "________",
                "________",
                "________",
                "_____N__",
                "_______K"
            };

            Solve(chessRow, n);
        }

        private static void Solve(string[] chessRow, int n)
        {
            bool check = false;

            int kingX = 0;
            int kingY = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(chessRow[i][j].ToString());
                    if (chessRow[i][j].ToString() == "K")
                    {
                        kingX = i;
                        kingY = j;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"king's position: {kingX} {kingY}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (chessRow[i][j].ToString() == "B")
                    {
                        if (Math.Abs(kingX - i) == Math.Abs(kingY - j)) check = true;
                    }
                    if (chessRow[i][j].ToString() == "R")
                    {
                        if (kingX == i || kingY == j) check = true;
                    }
                    if (chessRow[i][j].ToString() == "Q")
                    {
                        if (kingX == i || kingY == j || Math.Abs(kingX - i) == Math.Abs(kingY - j)) check = true;
                    }
                    if (chessRow[i][j].ToString() == "N")
                    {
                        if (kingX == i - 1 && kingY == j + 2 ||
                            kingX == i - 2 && kingY == j + 1 ||
                            kingX == i - 2 && kingY == j - 1 ||
                            kingX == i - 1 && kingY == j - 2 ||
                            kingX == i + 1 && kingY == j - 2 ||
                            kingX == i + 2 && kingY == j - 1 ||
                            kingX == i + 2 && kingY == j + 1 ||
                            kingX == i + 1 && kingY == j + 2)
                        {
                            check = true;
                        }
                    }
                }
            }
            Console.WriteLine(check ? "Check" : "No Check");
        }
    }
}
