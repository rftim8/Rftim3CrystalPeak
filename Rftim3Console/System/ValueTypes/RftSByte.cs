namespace Rftim3Console.System.ValueTypes
{
    internal class RftSByte
    {
        public RftSByte()
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
            Console.WriteLine($"MinValue: {sbyte.MinValue}");
            Console.WriteLine($"MaxValue: {sbyte.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(sbyte)}");
            Console.WriteLine($"Bits: {sizeof(sbyte) * 8}");
        }
    }
}
