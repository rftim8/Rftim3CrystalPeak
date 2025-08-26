namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftDecimal
    {
        /// <summary>
        /// High-precision decimal floating-point
        /// Operations: either the dividend or divisor must be decimal (.0m)
        /// 28-29 digits of precision
        /// </summary>
        public RftDecimal()
        {
            RftProperties();
            RftFormat();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {decimal.MinValue}");
            Console.WriteLine($"MaxValue: {decimal.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(decimal)}");
            Console.WriteLine($"Bits: {sizeof(decimal) * 8}");
            Console.WriteLine($"Deciaml 1: {decimal.One}");
            Console.WriteLine($"Decimal 0: {decimal.Zero}");
            Console.WriteLine($"Decimal -1: {decimal.MinusOne}");
        }

        private static void RftFormat()
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
