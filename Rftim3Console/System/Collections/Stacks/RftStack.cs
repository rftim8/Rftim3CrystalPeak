using System.Collections;

namespace Rftim3Console.System.Collections.Stacks
{
    public class RftStack
    {
        private static readonly Stack st0 = new();
        private static readonly Stack<int> sti0 = new();

        public RftStack()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            st0.Push("twqewq");
            st0.Push(1);
            st0.Push('c');

            foreach (object? item in st0)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            sti0.Push(0);
            sti0.Push(1);
            sti0.Push(2);

            foreach (int item in sti0)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
