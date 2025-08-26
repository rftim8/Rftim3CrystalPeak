namespace Rftim3Console.System.Arrays
{
    public class RftArray2D
    {
        public static void RftPrintSquare<T>(T[,] a2)
        {
            int e = a2.Length;
            if (e > 0)
            {
                int x = a2.GetLength(0);
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        Console.Write($"{a2[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void RftPrint<T>(T[,] a2)
        {
            int e = a2.Length;
            if (e > 0)
            {
                for (int i = 0; i < a2.GetLength(0); i++)
                {
                    for (int j = 0; j < a2.GetLength(1); j++)
                    {
                        Console.Write($"{a2[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void RftPrintJagged<T>(T[][] j2)
        {
            int y = j2.Length;
            if (y > 0)
            {
                int x = j2[0].Length;
                for (int i = 0; i < y; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        Console.Write($"{j2[i][j]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
