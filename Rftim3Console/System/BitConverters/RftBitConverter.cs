namespace Rftim3Console.System.BitConverters
{
    public class RftBitConverter
    {
        private readonly byte[] bytes = [0, 0, 0, 25];
        private readonly byte[] bytes1 = BitConverter.GetBytes(2013123125);

        public RftBitConverter()
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);

            int i = BitConverter.ToInt32(bytes, 0);
            Console.WriteLine($"int: {i}");

            Console.WriteLine($"byte array: {BitConverter.ToString(bytes1)}");

            const string formatter = "{0,25}{1,50}";

            double aDoubl = 0.1111111111111111111;
            float aSingl = 0.1111111111111111111F;
            long aLong = 1111111111111111111;
            int anInt = 1111111111;
            short aShort = 11111;
            char aChar = '*';
            bool aBool = true;

            Console.WriteLine("This example of methods of the BitConverter class" +
                "\ngenerates the following output.\n");
            Console.WriteLine(formatter, "argument", "byte array");
            Console.WriteLine(formatter, "--------", "----------");

            // Convert values to Byte arrays and display them.
            Console.WriteLine(formatter, aDoubl, BitConverter.ToString(BitConverter.GetBytes(aDoubl)));
            Console.WriteLine(formatter, aSingl, BitConverter.ToString(BitConverter.GetBytes(aSingl)));
            Console.WriteLine(formatter, aLong, BitConverter.ToString(BitConverter.GetBytes(aLong)));
            Console.WriteLine(formatter, anInt, BitConverter.ToString(BitConverter.GetBytes(anInt)));
            Console.WriteLine(formatter, aShort, BitConverter.ToString(BitConverter.GetBytes(aShort)));
            Console.WriteLine(formatter, aChar, BitConverter.ToString(BitConverter.GetBytes(aChar)));
            Console.WriteLine(formatter, aBool, BitConverter.ToString(BitConverter.GetBytes(aBool)));

            IsLittleEndian();
        }

        private static void IsLittleEndian()
        {
            Console.WriteLine("This example of the BitConverter.IsLittleEndian field generates \nthe following output when run on x86-class computers.\n");
            Console.WriteLine($"IsLittleEndian:  {BitConverter.IsLittleEndian}");
        }
    }
}
