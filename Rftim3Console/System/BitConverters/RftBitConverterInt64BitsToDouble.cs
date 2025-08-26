namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterInt64BitsToDouble
    {
        private const string formatter = "{0,20}{1,27:E16}";

        public RftBitConverterInt64BitsToDouble()
        {
            Console.WriteLine("This example of the BitConverter.Int64BitsToDouble( long ) \nmethod generates the following output.\n");
            Console.WriteLine(formatter, "long argument", "double value");
            Console.WriteLine(formatter, "-------------", "------------");

            // Convert long values and display the results.
            LongBitsToDouble(0);
            LongBitsToDouble(0x3FF0000000000000);
            LongBitsToDouble(0x402E000000000000);
            LongBitsToDouble(0x406FE00000000000);
            LongBitsToDouble(0x41EFFFFFFFE00000);
            LongBitsToDouble(0x3F70000000000000);
            LongBitsToDouble(0x3DF0000000000000);
            LongBitsToDouble(0x0000000000000001);
            LongBitsToDouble(0x000000000000FFFF);
            LongBitsToDouble(0x0000FFFFFFFFFFFF);
            LongBitsToDouble(unchecked((long)0xFFFFFFFFFFFFFFFF));
            LongBitsToDouble(unchecked((long)0xFFF0000000000000));
            LongBitsToDouble(0x7FF0000000000000);
            LongBitsToDouble(unchecked((long)0xFFEFFFFFFFFFFFFF));
            LongBitsToDouble(0x7FEFFFFFFFFFFFFF);
            LongBitsToDouble(long.MinValue);
            LongBitsToDouble(long.MaxValue);
        }

        // Reinterpret the long argument as a double.
        private static void LongBitsToDouble(long argument)
        {
            double doubleValue;
            doubleValue = BitConverter.Int64BitsToDouble(argument);

            // Display the argument in hexadecimal.
            Console.WriteLine(formatter, string.Format("0x{0:X16}", argument), doubleValue);
        }
    }
}
