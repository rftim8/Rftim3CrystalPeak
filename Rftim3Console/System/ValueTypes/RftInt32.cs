namespace Rftim3Console.System.ValueTypes
{
    internal class RftInt32
    {
        public RftInt32()
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
            Console.WriteLine($"MinValue: {int.MinValue}");
            Console.WriteLine($"MaxValue: {int.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(int)}");
            Console.WriteLine($"Bits: {sizeof(int) * 8}");
        }
    }
}
