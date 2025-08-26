namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterGetBytes
    {
        public RftBitConverterGetBytes()
        {
            // Define Boolean true and false values.
            bool[] values = [true, false];

            // Display the value and its corresponding byte array.
            Console.WriteLine("{0,10}{1,16}\n", "Boolean", "Bytes");
            foreach ((bool value, byte[] bytes) in from bool value in values
                                                   let bytes = BitConverter.GetBytes(value)
                                                   select (value, bytes))
            {
                Console.WriteLine("{0,10}{1,16}", value, BitConverter.ToString(bytes));
            }
        }
    }
}
