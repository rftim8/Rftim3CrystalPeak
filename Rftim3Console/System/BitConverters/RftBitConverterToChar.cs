namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToChar
    {
        private const string formatter = "{0,5}{1,17}{2,8}";

        public RftBitConverterToChar()
        {
            byte[] byteArray = [32, 0, 0, 42, 0, 65, 0, 125, 0, 197, 0, 168, 3, 41, 4, 172, 32];

            Console.WriteLine("This example of the BitConverter.ToChar( byte[ ], int ) \nmethod generates the following output. It converts \nelements of a byte array to char values.\n");
            Console.WriteLine("initial byte array");
            Console.WriteLine("------------------");
            Console.WriteLine(BitConverter.ToString(byteArray));
            Console.WriteLine();
            Console.WriteLine(formatter, "index", "array elements", "char");
            Console.WriteLine(formatter, "-----", "--------------", "----");

            // Convert byte array elements to char values.
            BAToChar(byteArray, 0);
            BAToChar(byteArray, 1);
            BAToChar(byteArray, 3);
            BAToChar(byteArray, 5);
            BAToChar(byteArray, 7);
            BAToChar(byteArray, 9);
            BAToChar(byteArray, 11);
            BAToChar(byteArray, 13);
            BAToChar(byteArray, 15);
        }

        // Convert two byte array elements to a char and display it.
        private static void BAToChar(byte[] bytes, int index)
        {
            char value = BitConverter.ToChar(bytes, index);

            Console.WriteLine(formatter, index, BitConverter.ToString(bytes, index, 2), value);
        }
    }
}
