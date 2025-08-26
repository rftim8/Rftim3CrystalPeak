namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToUint32
    {
        private const string formatter = "{0,5}{1,17}{2,15}";

        public RftBitConverterToUint32()
        {
            byte[] byteArray = [15, 0, 0, 0, 0, 16, 0, 255, 3, 0, 0, 202, 154, 59, 255, 255, 255, 255, 127];

            Console.WriteLine("This example of the BitConverter.ToUInt32( byte[ ], " +
                "int ) \nmethod generates the following output. It " +
                "converts elements \nof a byte array to uint values.\n");
            Console.WriteLine("initial byte array");
            Console.WriteLine("------------------");
            Console.WriteLine(BitConverter.ToString(byteArray));
            Console.WriteLine();
            Console.WriteLine(formatter, "index", "array elements", "uint");
            Console.WriteLine(formatter, "-----", "--------------", "----");

            // Convert byte array elements to uint values.
            BAToUInt32(byteArray, 1);
            BAToUInt32(byteArray, 0);
            BAToUInt32(byteArray, 7);
            BAToUInt32(byteArray, 3);
            BAToUInt32(byteArray, 10);
            BAToUInt32(byteArray, 15);
            BAToUInt32(byteArray, 14);
        }

        // Convert four byte array elements to a uint and display it.
        private static void BAToUInt32(byte[] bytes, int index)
        {
            uint value = BitConverter.ToUInt32(bytes, index);

            Console.WriteLine(formatter, index, BitConverter.ToString(bytes, index, 4), value);
        }
    }
}
