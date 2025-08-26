using System.Collections;

namespace Rftim3Console.System.Collections.ArrayLists
{
    public class RftArrayList
    {
        private static readonly ArrayList al0 = ["test", 1, 'w', "qwe"];
        private static readonly ArrayList al1 = ["qqq", 22, "ddd", 'e'];

        public RftArrayList()
        {
            RftBasic();
        }

        private static void RftBasic()
        {
            foreach (object? item in al0)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine($"ArrayList capacity: {al0.Capacity}");

            al0.AddRange(al1);
            al0.Capacity = 10;

            foreach (object? item in al0)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine($"ArrayList size: {al0.Capacity}");
        }
    }
}
