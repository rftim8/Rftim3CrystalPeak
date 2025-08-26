namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToSingle
    {
        private const string formatter = "{0,5}{1,17}{2,18:E7}";

        public RftBitConverterToSingle()
        {
            byte[] byteArray = [
              0,
                0,
                0,
                0,
                128,
                63,
                0,
                0,
                112,
                65,
                0,
                255,
                127,
                71,
                0,
                0,
                128,
                59,
                0,
                0,
                128,
                47,
                73,
                70,
                131,
                5,
                75,
                6,
                158,
                63,
                77,
                6,
                158,
                63,
                80,
                6,
                158,
                63,
                30,
                55,
                190,
                121,
                255,
                255,
                127,
                255,
                255,
                127,
                127,
                1,
                0,
                0,
                0,
                192,
                255,
                0,
                0,
                128,
                255,
                0,
                0,
                128,
                127];

            Console.WriteLine("This example of the BitConverter.ToSingle( byte( ), " +
                "int ) \nmethod generates the following output. It " +
                "converts elements \nof a byte array to float values.\n");

            WriteMultiLineByteArray(byteArray);

            Console.WriteLine(formatter, "index", "array elements", "float");
            Console.WriteLine(formatter, "-----", "--------------", "-----");

            // Convert byte array elements to float values.
            BAToSingle(byteArray, 0);
            BAToSingle(byteArray, 2);
            BAToSingle(byteArray, 6);
            BAToSingle(byteArray, 10);
            BAToSingle(byteArray, 14);
            BAToSingle(byteArray, 18);
            BAToSingle(byteArray, 22);
            BAToSingle(byteArray, 26);
            BAToSingle(byteArray, 30);
            BAToSingle(byteArray, 34);
            BAToSingle(byteArray, 38);
            BAToSingle(byteArray, 42);
            BAToSingle(byteArray, 45);
            BAToSingle(byteArray, 49);
            BAToSingle(byteArray, 51);
            BAToSingle(byteArray, 55);
            BAToSingle(byteArray, 59);
        }

        // Convert four byte array elements to a float and display it.
        private static void BAToSingle(byte[] bytes, int index)
        {
            float value = BitConverter.ToSingle(bytes, index);

            Console.WriteLine(formatter, index, BitConverter.ToString(bytes, index, 4), value);
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
