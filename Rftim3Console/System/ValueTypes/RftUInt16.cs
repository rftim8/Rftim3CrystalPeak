namespace Rftim3Console.System.ValueTypes
{
    internal class RftUInt16
    {
        public RftUInt16()
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
            Console.WriteLine($"MinValue: {ushort.MinValue}");
            Console.WriteLine($"MaxValue: {ushort.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(ushort)}");
            Console.WriteLine($"Bits: {sizeof(ushort) * 8}");
        }
    }
}
