namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverterToInt32
    {
        public RftBitConverterToInt32()
        {
            // Create an Integer from a 4-byte array.
            byte[] bytes1 = [0xEC, 0x00, 0x00, 0x00];
            Console.WriteLine("{0}--> 0x{1:X4} ({1:N0})", FormatBytes(bytes1), BitConverter.ToInt32(bytes1, 0));
            // Create an Integer from the upper four bytes of a byte array.
            byte[] bytes2 = BitConverter.GetBytes(long.MaxValue / 2);
            Console.WriteLine("{0}--> 0x{1:X4} ({1:N0})", FormatBytes(bytes2), BitConverter.ToInt32(bytes2, 4));

            // Round-trip an integer value.
            int original = (int)Math.Pow(16, 3);
            byte[] bytes3 = BitConverter.GetBytes(original);
            int restored = BitConverter.ToInt32(bytes3, 0);
            Console.WriteLine("0x{0:X4} ({0:N0}) --> {1} --> 0x{2:X4} ({2:N0})", original, FormatBytes(bytes3), restored);
        }

        private static string FormatBytes(byte[] bytes)
        {
            string value = "";
            foreach (byte byt in bytes)
            {
                value += string.Format("{0:X2} ", byt);
            }

            return value;
        }
    }
}
