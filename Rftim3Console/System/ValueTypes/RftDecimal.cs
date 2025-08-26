namespace Rftim3Console.System.ValueTypes
{
    internal class RftDecimal
    {
        public RftDecimal()
        {
            int func = 0;

            switch (func)
            {
                case 0:
                    Properties();
                    break;
                case 1:
                    Format();
                    break;
                default:
                    break;
            }
        }

        private static void Properties()
        {
            Console.WriteLine($"MinValue: {decimal.MinValue}");
            Console.WriteLine($"MaxValue: {decimal.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(decimal)}");
            Console.WriteLine($"Bits: {sizeof(decimal) * 8}");
            Console.WriteLine($"Deciaml 1: {decimal.One}");
            Console.WriteLine($"Decimal 0: {decimal.Zero}");
            Console.WriteLine($"Decimal -1: {decimal.MinusOne}");
        }

        private static void Format()
        {
            string x = "23.23423423";

            double a = 1.0;
            double b = 3.0;
            Console.WriteLine($"{a / b}");

            decimal c = 1.0m;
            decimal d = 3.0m;
            Console.WriteLine($"{c / d}");

            Console.WriteLine($"1 floating point: {string.Format("{0:f1}", decimal.Parse(x))}");
            Console.WriteLine($"2 floating points: {string.Format("{0:f2}", decimal.Parse(x))}");
            Console.WriteLine($"3 floating points: {string.Format("{0:f3}", decimal.Parse(x))}");
        }
    }
}
