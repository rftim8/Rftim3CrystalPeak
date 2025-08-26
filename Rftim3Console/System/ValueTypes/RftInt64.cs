namespace Rftim3Console.System.ValueTypes
{
    internal class RftInt64
    {
        public RftInt64()
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
            Console.WriteLine($"MinValue: {long.MinValue}");
            Console.WriteLine($"MaxValue: {long.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(long)}");
            Console.WriteLine($"Bits: {sizeof(long) * 8}");
        }
    }
}
