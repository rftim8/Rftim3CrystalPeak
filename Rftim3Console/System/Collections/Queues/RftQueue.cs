using System.Collections;

namespace Rftim3Console.System.Collections.Queues
{
    public class RftQueue
    {
        private static readonly Queue q0 = new();
        private static readonly Queue<int> qi0 = new();

        public RftQueue()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            q0.Enqueue("werwer");
            q0.Enqueue(1);
            q0.Enqueue('d');

            foreach (object? item in q0)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            qi0.Enqueue(0);
            qi0.Enqueue(1);
            qi0.Enqueue(2);

            foreach (int item in qi0)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
