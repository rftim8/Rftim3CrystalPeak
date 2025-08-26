namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftAnonymous
    {
        public RftAnonymous()
        {
            RftExample();
        }

        private static void RftExample()
        {
            (int Amount, string Message) = (5, "Hello");
            Console.WriteLine($"{Amount}");
            Console.WriteLine($"{Message}");
        }
    }
}
