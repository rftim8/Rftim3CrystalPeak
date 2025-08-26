namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToUint64
    {
        private const string formatter = "{0,5}{1,27}{2,24}";

        public RftBitConverterToUint64()
        {
            byte[] byteArray = [
            255,
                255,
                255,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                1,
                0,
                0,
                0,
                100,
                167,
                179,
                182,
                224,
                13,
                0,
                202,
                154,
                59,
                0,
                0,
                0,
                0,
                170,
                170,
                170,
                170,
                170,
                170,
                0,
                0,
                232,
                137,
                4,
                35,
                199,
                138,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                127];

            Console.WriteLine("This example of the BitConverter.ToUInt64( byte[ ], " +
                "int ) \nmethod generates the following output. It " +
                "converts elements \nof a byte array to ulong values.\n");

            WriteMultiLineByteArray(byteArray);

            Console.WriteLine(formatter, "index", "array elements", "ulong");
            Console.WriteLine(formatter, "-----", "--------------", "------");

            // Convert byte array elements to ulong values.
            BAToUInt64(byteArray, 3);
            BAToUInt64(byteArray, 0);
            BAToUInt64(byteArray, 21);
            BAToUInt64(byteArray, 7);
            BAToUInt64(byteArray, 29);
            BAToUInt64(byteArray, 13);
            BAToUInt64(byteArray, 35);
            BAToUInt64(byteArray, 44);
            BAToUInt64(byteArray, 43);
        }

        // Convert eight byte array elements to a ulong and display it.
        private static void BAToUInt64(byte[] bytes, int index)
        {
            ulong value = BitConverter.ToUInt64(bytes, index);

            Console.WriteLine(formatter, index, BitConverter.ToString(bytes, index, 8), value);
        }

        // Display a byte array, using multiple lines if necessary.
        private static void WriteMultiLineByteArray(byte[] bytes)
        {
            const int rowSize = 20;
            int iter;

            Console.WriteLine("initial byte array");
            Console.WriteLine("------------------");

            for (iter = 0; iter < bytes.Length - rowSize; iter += rowSize)
            {
                Console.Write(BitConverter.ToString(bytes, iter, rowSize));
                Console.WriteLine("-");
            }

            Console.WriteLine(BitConverter.ToString(bytes, iter));
            Console.WriteLine();
        }
    }
}
