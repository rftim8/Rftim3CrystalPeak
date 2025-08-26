namespace Rftim3Console.System.Arrays
{
    public class RftArray3D
    {
        public static void RftPrintCube<T>(T[,,] a3)
        {
            int e = a3.Length;
            if (e > 0)
            {
                int x = a3.GetLength(0);
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < x; j++)
                    {
                        for (int k = 0; k < x; k++)
                        {
                            Console.Write($"{a3[i, j, k]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void RftPrint<T>(T[,,] a3)
        {
            int e = a3.Length;
            if (e > 0)
            {
                for (int i = 0; i < a3.GetLength(0); i++)
                {
                    for (int j = 0; j < a3.GetLength(1); j++)
                    {
                        for (int k = 0; k < a3.GetLength(2); k++)
                        {
                            Console.Write($"{a3[i, j, k]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void RftPrintJagged<T>(T[][][] j3)
        {
            int z = j3.Length;
            if (z > 0)
            {
                int y = j3[0].Length;
                if (y > 0)
                {
                    int x = j3[0][0].Length;

                    for (int i = 0; i < z; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            for (int k = 0; k < x; k++)
                            {
                                Console.Write($"{j3[i][j][k]} ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
