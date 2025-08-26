namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToDouble
    {
        private const string formatter = "{0,5}{1,27}{2,27:E16}";

        public RftBitConverterToDouble()
        {
            byte[] byteArray = [
              0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                240,
                63,
                0,
                0,
                0,
                0,
                0,
                224,
                111,
                64,
                0,
                0,
                224,
                255,
                255,
                255,
                239,
                65,
                0,
                0,
                0,
                0,
                0,
                0,
                112,
                63,
                0,
                0,
                0,
                0,
                0,
                0,
                240,
                61,
                223,
                136,
                30,
                28,
                254,
                116,
                170,
                1,
                250,
                89,
                140,
                66,
                202,
                192,
                243,
                63,
                251,
                89,
                140,
                66,
                202,
                192,
                243,
                63,
                252,
                89,
                140,
                66,
                202,
                192,
                243,
                63,
                82,
                211,
                187,
                188,
                232,
                126,
                61,
                126,
                255,
                255,
                255,
                255,
                255,
                255,
                239,
                255,
                255,
                255,
                255,
                255,
                255,
                239,
                127,
                1,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                248,
                255,
                0,
                0,
                0,
                0,
                0,
                0,
                240,
                255,
                0,
                0,
                0,
                0,
                0,
                0,
                240,
                127];

            Console.WriteLine("This example of the BitConverter.ToDouble( byte[ ], " +
                "int ) \nmethod generates the following output. It " +
                "converts elements \nof a byte array to double values.\n");

            WriteMultiLineByteArray(byteArray);

            Console.WriteLine(formatter, "index", "array elements", "double");
            Console.WriteLine(formatter, "-----", "--------------", "------");

            // Convert byte array elements to double values.
            BAToDouble(byteArray, 0);
            BAToDouble(byteArray, 2);
            BAToDouble(byteArray, 10);
            BAToDouble(byteArray, 18);
            BAToDouble(byteArray, 26);
            BAToDouble(byteArray, 34);
            BAToDouble(byteArray, 42);
            BAToDouble(byteArray, 50);
            BAToDouble(byteArray, 58);
            BAToDouble(byteArray, 66);
            BAToDouble(byteArray, 74);
            BAToDouble(byteArray, 82);
            BAToDouble(byteArray, 89);
            BAToDouble(byteArray, 97);
            BAToDouble(byteArray, 99);
            BAToDouble(byteArray, 107);
            BAToDouble(byteArray, 115);
        }

        // Convert eight byte array elements to a double and display it.
        private static void BAToDouble(byte[] bytes, int index)
        {
            double value = BitConverter.ToDouble(bytes, index);

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
