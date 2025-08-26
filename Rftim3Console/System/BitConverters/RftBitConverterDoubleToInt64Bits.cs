namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterDoubleToInt64Bits
    {
        const string formatter = "{0,25:E16}{1,23:X16}";

        public RftBitConverterDoubleToInt64Bits()
        {
            Console.WriteLine("This example of the BitConverter.DoubleToInt64Bits( double ) \nmethod generates the following output.\n");
            Console.WriteLine(formatter, "double argument", "hexadecimal value");
            Console.WriteLine(formatter, "---------------", "-----------------");

            // Convert double values and display the results.
            DoubleToLongBits(1.0);
            DoubleToLongBits(15.0);
            DoubleToLongBits(255.0);
            DoubleToLongBits(4294967295.0);
            DoubleToLongBits(0.00390625);
            DoubleToLongBits(0.00000000023283064365386962890625);
            DoubleToLongBits(1.234567890123E-300);
            DoubleToLongBits(1.23456789012345E-150);
            DoubleToLongBits(1.2345678901234565);
            DoubleToLongBits(1.2345678901234567);
            DoubleToLongBits(1.2345678901234569);
            DoubleToLongBits(1.23456789012345678E+150);
            DoubleToLongBits(1.234567890123456789E+300);
            DoubleToLongBits(double.MinValue);
            DoubleToLongBits(double.MaxValue);
            DoubleToLongBits(double.Epsilon);
            DoubleToLongBits(double.NaN);
            DoubleToLongBits(double.NegativeInfinity);
            DoubleToLongBits(double.PositiveInfinity);
        }

        // Reinterpret the double argument as a long.
        private static void DoubleToLongBits(double argument)
        {
            long longValue;
            longValue = BitConverter.DoubleToInt64Bits(argument);

            // Display the resulting long in hexadecimal.
            Console.WriteLine(formatter, argument, longValue);
        }
    }
}
