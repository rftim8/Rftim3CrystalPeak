namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftUshort
    {
        public RftUshort()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {ushort.MinValue}");
            Console.WriteLine($"MaxValue: {ushort.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(ushort)}");
            Console.WriteLine($"Bits: {sizeof(ushort) * 8}");
        }
    }
}
