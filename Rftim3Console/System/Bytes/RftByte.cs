using System.Globalization;

namespace Rftim3Console.System.Bytes
{
    public class RftByte
    {
        private struct ByteString
        {
            public string Value;
            public int Sign;
        }

        private static readonly byte b0 = 201;
        private static readonly byte b1 = 0x00c9;
        private static readonly byte b2 = 0b1100_1001;
        private static readonly byte b3 = 0b_1100_1001;

        public RftByte()
        {
            RftProperties();

            RftByteAsString();
            RftByteBase();
            RftByteMask();
            RftByteMaskUnsigned();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {byte.MinValue}");
            Console.WriteLine($"MaxValue: {byte.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(byte)}");
            Console.WriteLine($"Bits: {sizeof(byte) * 8}");
            Console.WriteLine($"Byte: {b0}");
            Console.WriteLine($"Hexbyte to dec: {b1}");
            Console.WriteLine($"Bits to dec: {b2}");
            Console.WriteLine($"Bits to dec: {b3}");
        }

        private static void RftByteAsString()
        {
            byte[] numbers = [0, 16, 104, 213];
            foreach (byte number in numbers)
            {
                // Display value using default formatting.
                Console.Write($"{number,-3}  -->   ");
                // Display value with 3 digits and leading zeros.
                Console.Write(number.ToString("D3") + "   ");
                // Display value with hexadecimal.
                Console.Write(number.ToString("X2") + "   ");
                // Display value with four hexadecimal digits.
                Console.WriteLine(number.ToString("X4"));
            }
        }

        private static void RftByteBase()
        {
            byte[] numbers = [0, 16, 104, 213];
            Console.WriteLine($"{"Value"}   {"Binary",8}   {"Octal",5}   {"Hex",5}");
            foreach (byte number in numbers)
            {
                Console.WriteLine($"{number,5}   {Convert.ToString(number, 2),8}   {Convert.ToString(number, 8),5}   {Convert.ToString(number, 16),5}");
            }
        }

        private static void RftByteMask()
        {
            string[] values = [Convert.ToString(12, 16),
                Convert.ToString(123, 16),
                Convert.ToString(245, 16)];

            byte mask = 0xFE;
            foreach (string value in values)
            {
                byte byteValue = byte.Parse(value, NumberStyles.AllowHexSpecifier);
                Console.WriteLine($"{byteValue} And {mask} = {byteValue & mask}");
            }
        }

        private static void RftByteMaskUnsigned()
        {
            ByteString[] values = CreateArray(-15, 123, 245);

            byte mask = 0x14;        // Mask all bits but 2 and 4.

            foreach (ByteString strValue in values)
            {
                byte byteValue = byte.Parse(strValue.Value, NumberStyles.AllowHexSpecifier);
                Console.WriteLine("{0} ({1}) And {2} ({3}) = {4} ({5})",
                                  strValue.Sign * byteValue,
                                  Convert.ToString(byteValue, 2),
                                  mask, Convert.ToString(mask, 2),
                                  (strValue.Sign & Math.Sign(mask)) * (byteValue & mask),
                                  Convert.ToString(byteValue & mask, 2));
            }
        }

        private static ByteString[] CreateArray(params int[] values)
        {
            List<ByteString> byteStrings = [];

            foreach (object value in values)
            {
                ByteString temp = new();
                int sign = Math.Sign((int)value);
                temp.Sign = sign;

                // Change two's complement to magnitude-only representation.
                temp.Value = Convert.ToString((int)value * sign, 16);

                byteStrings.Add(temp);
            }

            return [.. byteStrings];
        }
    }
}
