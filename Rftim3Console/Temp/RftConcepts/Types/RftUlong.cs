namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftUlong
    {
        public RftUlong()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {ulong.MinValue}");
            Console.WriteLine($"MaxValue: {ulong.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(ulong)}");
            Console.WriteLine($"Bits: {sizeof(ulong) * 8}");
        }
    }
}
