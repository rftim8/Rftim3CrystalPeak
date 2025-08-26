namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToInt64
    {
        private const string formatter = "{0,5}{1,27}{2,24}";

        public RftBitConverterToInt64()
        {
            byte[] byteArray = [
              0,
                54,
                101,
                196,
                255,
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
                128,
                0,
                202,
                154,
                59,
                0,
                0,
                0,
                0,
                1,
                0,
                0,
                0,
                0,
                255,
                255,
                255,
                255,
                1,
                0,
                0,
                255,
                255,
                255,
                255,
                255,
                255,
                255,
                127,
                86,
                85,
                85,
                85,
                85,
                85,
                255,
                255,
                170,
                170,
                170,
                170,
                170,
                170,
                0,
                0,
                100,
                167,
                179,
                182,
                224,
                13,
                0,
                0,
                156,
                88,
                76,
                73,
                31,
                242];

            Console.WriteLine("This example of the BitConverter.ToInt64( byte[ ], " +
                "int ) \nmethod generates the following output. It " +
                "converts elements \nof a byte array to long values.\r\n");

            WriteMultiLineByteArray(byteArray);

            Console.WriteLine(formatter, "index", "array elements", "long");
            Console.WriteLine(formatter, "-----", "--------------", "----");

            // Convert byte array elements to long values.
            BAToInt64(byteArray, 8);
            BAToInt64(byteArray, 5);
            BAToInt64(byteArray, 34);
            BAToInt64(byteArray, 17);
            BAToInt64(byteArray, 0);
            BAToInt64(byteArray, 21);
            BAToInt64(byteArray, 26);
            BAToInt64(byteArray, 53);
            BAToInt64(byteArray, 45);
            BAToInt64(byteArray, 59);
            BAToInt64(byteArray, 67);
            BAToInt64(byteArray, 37);
            BAToInt64(byteArray, 9);
        }

        // Convert eight byte array elements to a long and display it.
        private static void BAToInt64(byte[] bytes, int index)
        {
            long value = BitConverter.ToInt64(bytes, index);

            Console.WriteLine(formatter, index, BitConverter.ToString(bytes, index, 8), value);
        }

        // Display a byte array, using multiple lines if necessary.
        public static void WriteMultiLineByteArray(byte[] bytes)
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
