namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftSbyte
    {
        public RftSbyte()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {sbyte.MinValue}");
            Console.WriteLine($"MaxValue: {sbyte.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(sbyte)}");
            Console.WriteLine($"Bits: {sizeof(sbyte) * 8}");
        }
    }
}
