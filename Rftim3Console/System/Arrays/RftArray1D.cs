namespace Rftim3Console.System.Arrays
{
    public class RftArray1D
    {
        public static void RftPrint<T>(T[] a)
        {
            foreach (T item in a)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
