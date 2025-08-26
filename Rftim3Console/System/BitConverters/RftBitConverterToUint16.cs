namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToUint16
    {
        private const string formatter = "{0,5}{1,17}{2,10}";

        public RftBitConverterToUint16()
        {
            byte[] byteArray = [15, 0, 0, 255, 3, 16, 39, 255, 255, 127];

            Console.WriteLine("This example of the BitConverter.ToUInt16( byte[ ], " +
                "int ) \nmethod generates the following output. It " +
                "converts elements \nof a byte array to ushort values.\n");
            Console.WriteLine("initial byte array");
            Console.WriteLine("------------------");
            Console.WriteLine(BitConverter.ToString(byteArray));
            Console.WriteLine();
            Console.WriteLine(formatter, "index", "array elements", "ushort");
            Console.WriteLine(formatter, "-----", "--------------", "------");

            // Convert byte array elements to ushort values.
            BAToUInt16(byteArray, 1);
            BAToUInt16(byteArray, 0);
            BAToUInt16(byteArray, 3);
            BAToUInt16(byteArray, 5);
            BAToUInt16(byteArray, 8);
            BAToUInt16(byteArray, 7);
        }

        // Convert two byte array elements to a ushort and display it.
        private static void BAToUInt16(byte[] bytes, int index)
        {
            ushort value = BitConverter.ToUInt16(bytes, index);

            Console.WriteLine(formatter, index, BitConverter.ToString(bytes, index, 2), value);
        }
    }
}
