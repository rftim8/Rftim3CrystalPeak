namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftRandom
    {
        public RftRandom()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Random random = new();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Random value between 1 and 10: {random.Next(1, 10)}");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Random double: {random.NextDouble()}");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{random.NextSingle()}");
            }
        }
    }
}
