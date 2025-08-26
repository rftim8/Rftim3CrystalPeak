namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToString
    {
        public RftBitConverterToString()
        {
            byte[] arrayOne = [0, 1, 2, 4, 8, 16, 32, 64, 128, 255];

            byte[] arrayTwo = [32, 0, 0, 42, 0, 65, 0, 125, 0, 197, 0, 168, 3, 41, 4, 172, 32];

            byte[] arrayThree = [15, 0, 0, 128, 16, 39, 240, 216, 241, 255, 127];

            byte[] arrayFour = [15, 0, 0, 0, 0, 16, 0, 255, 3, 0, 0, 202, 154, 59, 255, 255, 255, 255, 127];

            Console.WriteLine("This example of the BitConverter.ToString( byte[ ] ) \n method generates the following output.\n");

            WriteByteArray(arrayOne, "arrayOne");
            WriteByteArray(arrayTwo, "arrayTwo");
            WriteByteArray(arrayThree, "arrayThree");
            WriteByteArray(arrayFour, "arrayFour");
        }

        // Display a byte array with a name.
        private static void WriteByteArray(byte[] bytes, string name)
        {
            const string underLine = "--------------------------------";

            Console.WriteLine(name);
            Console.WriteLine(underLine[..Math.Min(name.Length, underLine.Length)]);
            Console.WriteLine(BitConverter.ToString(bytes));
            Console.WriteLine();
        }
    }
}
