namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftLong
    {
        public RftLong()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {long.MinValue}");
            Console.WriteLine($"MaxValue: {long.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(long)}");
            Console.WriteLine($"Bits: {sizeof(long) * 8}");
        }
    }
}
