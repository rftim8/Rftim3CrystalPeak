namespace Rftim3Console.System.ValueTypes
{
    internal class RftInt16
    {
        public RftInt16()
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
            Console.WriteLine($"MinValue: {short.MinValue}");
            Console.WriteLine($"MaxValue: {short.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(short)}");
            Console.WriteLine($"Bits: {sizeof(short) * 8}");
        }
    }
}
