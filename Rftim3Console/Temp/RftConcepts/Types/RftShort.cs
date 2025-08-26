namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftShort
    {
        public RftShort()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {short.MinValue}");
            Console.WriteLine($"MaxValue: {short.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(short)}");
            Console.WriteLine($"Bits: {sizeof(short) * 8}");
        }
    }
}
