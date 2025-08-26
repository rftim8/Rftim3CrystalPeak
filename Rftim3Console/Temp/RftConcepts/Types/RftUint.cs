namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftUint
    {
        public RftUint()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {uint.MinValue}");
            Console.WriteLine($"MaxValue: {uint.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(uint)}");
            Console.WriteLine($"Bits: {sizeof(uint) * 8}");
        }
    }
}
