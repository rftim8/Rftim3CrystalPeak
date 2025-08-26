namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftNullable
    {
        public RftNullable()
        {
            RftExample();
        }

        private static void RftExample()
        {
            int? optionalInt = default;
            Console.WriteLine($"HasValue: {optionalInt.HasValue}");
            Console.WriteLine($"{optionalInt}");

            optionalInt = 5;
            Console.WriteLine($"{optionalInt}");

            string? optionalText = default;
            Console.WriteLine($"{optionalText}");

            optionalText = "Hello";
            Console.WriteLine($"{optionalText}");
        }
    }
}
