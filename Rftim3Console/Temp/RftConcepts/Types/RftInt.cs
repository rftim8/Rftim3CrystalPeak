namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftInt
    {
        public RftInt()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {int.MinValue}");
            Console.WriteLine($"MaxValue: {int.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(int)}");
            Console.WriteLine($"Bits: {sizeof(int) * 8}");
        }
    }
}
