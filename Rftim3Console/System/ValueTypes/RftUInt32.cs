namespace Rftim3Console.System.ValueTypes
{
    internal class RftUInt32
    {
        public RftUInt32()
        {
            int func = 0;

            switch (func)
            {
                case 0:
                    Properties();
                    break;
                default:
                    break;
            }
        }

        private static void Properties()
        {
            Console.WriteLine($"MinValue: {uint.MinValue}");
            Console.WriteLine($"MaxValue: {uint.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(uint)}");
            Console.WriteLine($"Bits: {sizeof(uint) * 8}");
        }
    }
}
