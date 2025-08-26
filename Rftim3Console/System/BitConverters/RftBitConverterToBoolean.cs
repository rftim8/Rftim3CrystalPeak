namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToBoolean
    {
        public RftBitConverterToBoolean()
        {
            // Define an array of byte values.
            byte[] bytes = [0, 1, 2, 4, 8, 16, 32, 64, 128, 255];

            Console.WriteLine("{0,5}{1,16}{2,10}\n", "index", "array element", "bool");
            // Convert each array element to a Boolean value.
            for (int index = 0; index < bytes.Length; index++)
            {
                Console.WriteLine("{0,5}{1,16:X2}{2,10}", index, bytes[index], BitConverter.ToBoolean(bytes, index));
            }
        }
    }
}
