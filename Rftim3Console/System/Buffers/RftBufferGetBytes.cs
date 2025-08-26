namespace Rftim3Console.System.Buffers
{
    public class RftBufferGetBytes
    {
        private const string formatter = "{0,10}{1,10}{2,9} {3}";

        public RftBufferGetBytes()
        {
            // These are the arrays to be viewed with GetByte.
            long[] longs = [333333333333333333, 666666666666666666, 999999999999999999];
            int[] ints = [111111111, 222222222, 333333333, 444444444, 555555555];

            Console.WriteLine("This example of the " +
                "Buffer.GetByte( Array, int ) \n" +
                "method generates the following output.\n" +
                "Note: The arrays are displayed from right to left.\n");
            Console.WriteLine("  Values of arrays:\n");

            // Display the values of the arrays.
            DisplayArray(longs, "longs");
            DisplayArray(ints, "ints");
            Console.WriteLine();

            Console.WriteLine(formatter, "Array", "index", "value", "");
            Console.WriteLine(formatter, "-----", "-----", "-----", "----");

            // Display the Length and ByteLength for each array.
            ArrayInfo(ints, "ints", 0);
            ArrayInfo(ints, "ints", 7);
            ArrayInfo(ints, "ints", 10);
            ArrayInfo(ints, "ints", 17);
            ArrayInfo(longs, "longs", 0);
            ArrayInfo(longs, "longs", 6);
            ArrayInfo(longs, "longs", 10);
            ArrayInfo(longs, "longs", 17);
            ArrayInfo(longs, "longs", 21);
        }

        // Display the array contents in hexadecimal.
        private static void DisplayArray(Array arr, string name)
        {
            // Get the array element width; format the formatting string.
            int elemWidth = Buffer.ByteLength(arr) / arr.Length;
            string format = $" {{0:X{2 * elemWidth}}}";

            // Display the array elements from right to left.
            Console.Write($"{name,5}:");
            for (int loopX = arr.Length - 1; loopX >= 0; loopX--)
            {
                Console.Write(format, arr.GetValue(loopX));
            }

            Console.WriteLine();
        }

        private static void ArrayInfo(Array arr, string name, int index)
        {
            byte value = Buffer.GetByte(arr, index);

            // Display the array name, index, and byte to be viewed.
            Console.WriteLine(formatter, name, index, value, $"0x{value:X2}");
        }
    }
}
