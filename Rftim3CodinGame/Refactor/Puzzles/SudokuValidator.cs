namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class SudokuValidator
    {
        public SudokuValidator()
        {
            const int n = 9;
            int[,] sudoku = new int[n, n] {
                { 1,2,3,4,5,6,7,8,9 },
                { 4,1,6,7,8,9,1,2,3 },
                { 7,8,9,1,2,3,4,5,6 },
                { 9,1,2,3,4,5,6,7,8 },
                { 3,4,5,6,7,8,9,1,2 },
                { 6,7,8,9,1,2,3,4,5 },
                { 8,9,1,2,3,4,5,6,7 },
                { 2,3,4,5,6,7,8,9,1 },
                { 5,6,7,8,9,1,2,3,4 }
            };

            Solve(n, sudoku);
        }

        private static void Solve(int n, int[,] sudoku)
        {
            bool result = true;
            bool rowColError = true;
            bool boxError = true;
            int nr = 1;

            while (nr < 10)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (sudoku[i, j] == nr)
                        {
                            for (int k = 0; k < n; k++)
                            {
                                for (int l = 0; l < n; l++)
                                {
                                    if ((sudoku[k, j] == nr || sudoku[i, l] == nr) && i != k && j != l) rowColError = false;
                                }
                            }
                        }
                        Console.Write(sudoku[i, j]);
                    }
                    Console.WriteLine();
                }

                int count = 0;
                int boxSize = 3;
                int start = 0;

                while (boxSize < 10)
                {
                    if (count < 2)
                    {
                        count = 0;
                        for (int i = start; i < boxSize; i++)
                        {
                            for (int j = start; j < boxSize; j++)
                            {
                                if (sudoku[i, j] == nr) count++;
                            }
                        }
                        boxSize += 3;
                        start += 3;
                    }
                    else
                    {
                        boxSize = 10;
                        boxError = false;
                    }
                }

                nr++;
            }

            if (!rowColError || !boxError) result = false;

            Console.WriteLine(result.ToString().ToLower());
        }
    }
}
