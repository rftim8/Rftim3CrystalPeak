namespace Rftim3Console.System.Buffers
{
    public class RftBufferBlockCopy
    {
        public RftBufferBlockCopy()
        {
            // These are the source and destination arrays for BlockCopy.
            short[] src = { 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270 };
            long[] dest = { 17, 18, 19, 20 };

            // Display the initial value of the arrays in memory.
            Console.WriteLine("Initial values of arrays:");
            Console.WriteLine("   Array values as Bytes:");
            DisplayArray(src, "src");
            DisplayArray(dest, "dest");
            Console.WriteLine("   Array values:");
            DisplayArrayValues(src, "src");
            DisplayArrayValues(dest, "dest");
            Console.WriteLine();

            // Copy bytes 5-10 from source to index 7 in destination and display the result.
            Buffer.BlockCopy(src, 5, dest, 7, 6);
            Console.WriteLine("Buffer.BlockCopy(src, 5, dest, 7, 6 )");
            Console.WriteLine("   Array values as Bytes:");
            DisplayArray(src, "src");
            DisplayArray(dest, "dest");
            Console.WriteLine("   Array values:");
            DisplayArrayValues(src, "src");
            DisplayArrayValues(dest, "dest");
            Console.WriteLine();

            // Copy bytes 16-20 from source to index 22 in destination and display the result.
            Buffer.BlockCopy(src, 16, dest, 22, 5);
            Console.WriteLine("Buffer.BlockCopy(src, 16, dest, 22, 5)");
            Console.WriteLine("   Array values as Bytes:");
            DisplayArray(src, "src");
            DisplayArray(dest, "dest");
            Console.WriteLine("   Array values:");
            DisplayArrayValues(src, "src");
            DisplayArrayValues(dest, "dest");
            Console.WriteLine();

            // Copy overlapping range of bytes 4-10 to index 5 in source.
            Buffer.BlockCopy(src, 4, src, 5, 7);
            Console.WriteLine("Buffer.BlockCopy( src, 4, src, 5, 7)");
            Console.WriteLine("   Array values as Bytes:");
            DisplayArray(src, "src");
            DisplayArray(dest, "dest");
            Console.WriteLine("   Array values:");
            DisplayArrayValues(src, "src");
            DisplayArrayValues(dest, "dest");
            Console.WriteLine();

            // Copy overlapping range of bytes 16-22 to index 15 in source.
            Buffer.BlockCopy(src, 16, src, 15, 7);
            Console.WriteLine("Buffer.BlockCopy( src, 16, src, 15, 7)");
            Console.WriteLine("   Array values as Bytes:");
            DisplayArray(src, "src");
            DisplayArray(dest, "dest");
            Console.WriteLine("   Array values:");
            DisplayArrayValues(src, "src");
            DisplayArrayValues(dest, "dest");
        }

        // Display the individual bytes in the array in hexadecimal.
        private static void DisplayArray(Array arr, string name)
        {
            if (OperatingSystem.IsWindows())
                Console.WindowWidth = 120;

            Console.Write("{0,11}:", name);

            for (int ctr = 0; ctr < arr.Length; ctr++)
            {
                byte[] bytes;
                if (arr is long[]) bytes = BitConverter.GetBytes((long)(arr.GetValue(ctr) ?? 0));
                else bytes = BitConverter.GetBytes((short)(arr.GetValue(ctr) ?? 0));

                foreach (byte byteValue in bytes)
                {
                    Console.Write($" {byteValue:X2}");
                }
            }
            Console.WriteLine();
        }

        // Display the individual array element values in hexadecimal.
        private static void DisplayArrayValues(Array arr, string name)
        {
            // Get the length of one element in the array.
            int elementLength = Buffer.ByteLength(arr) / arr.Length;
            string formatString = $" {{0:X{2 * elementLength}}}";
            Console.Write($"{name,11}:");
            for (int ctr = 0; ctr < arr.Length; ctr++)
            {
                Console.Write(formatString, arr.GetValue(ctr));
            }

            Console.WriteLine();
        }
    }
}
