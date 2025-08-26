namespace Rftim3Console.System.Buffers
{
    public class RftBufferSetByte
    {
        public RftBufferSetByte()
        {
            // These are the arrays to be modified with SetByte.
            short[] shorts = new short[10];
            long[] longs = new long[3];

            Console.WriteLine("This example of the " +
                "Buffer.SetByte( Array, int, byte ) \n" +
                "method generates the following output.\n" +
                "Note: The arrays are displayed from right to left.\n");
            Console.WriteLine("  Initial values of arrays:\n");

            // Display the initial values of the arrays.
            DisplayArray(shorts, "shorts");
            DisplayArray(longs, "longs");

            // Copy two regions of source array to destination array,
            // and two overlapped copies from source to source.
            Console.WriteLine("\n" +
                "  Array values after setting byte 3 = 25, \n" +
                "  byte 6 = 64, byte 12 = 121, and byte 17 = 196:\n");

            Buffer.SetByte(shorts, 3, 25);
            Buffer.SetByte(shorts, 6, 64);
            Buffer.SetByte(shorts, 12, 121);
            Buffer.SetByte(shorts, 17, 196);
            Buffer.SetByte(longs, 3, 25);
            Buffer.SetByte(longs, 6, 64);
            Buffer.SetByte(longs, 12, 121);
            Buffer.SetByte(longs, 17, 196);

            // Display the arrays again.
            DisplayArray(shorts, "shorts");
            DisplayArray(longs, "longs");
        }

        // Display the array contents in hexadecimal.
        public static void DisplayArray(Array arr, string name)
        {
            // Get the array element width; format the formatting string.
            int elemWidth = Buffer.ByteLength(arr) / arr.Length;
            string format = $" {{0:X{2 * elemWidth}}}";

            // Display the array elements from right to left.
            Console.Write($"{name,7}:");
            for (int loopX = arr.Length - 1; loopX >= 0; loopX--)
            {
                Console.Write(format, arr.GetValue(loopX));
            }

            Console.WriteLine();
        }
    }
}
