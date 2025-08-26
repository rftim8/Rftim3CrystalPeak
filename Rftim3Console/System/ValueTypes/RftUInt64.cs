namespace Rftim3Console.System.ValueTypes
{
    internal class RftUInt64
    {
        public RftUInt64()
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
            Console.WriteLine($"MinValue: {ulong.MinValue}");
            Console.WriteLine($"MaxValue: {ulong.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(ulong)}");
            Console.WriteLine($"Bits: {sizeof(ulong) * 8}");
        }
    }
}
