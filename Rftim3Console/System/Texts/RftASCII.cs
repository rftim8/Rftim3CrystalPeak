using System.Globalization;
using System.Text;

namespace Rftim3Console.System.Texts
{
    class RftASCII
    {
        private readonly string message = "Woa";
        private readonly byte[] decimals = [87, 111, 97];
        private readonly int[] binaries = [01010111, 01101111, 01100001];
        private readonly string[] hexValues = ["57", "6F", "61"];

        public RftASCII()
        {
            Console.WriteLine($"\tASCII\t\tDecimal\t\tBinary\t\tHEX\n");
            ASCII_Decimal_Binary_HEX(0, message);
            Console.WriteLine($"\n");

            Console.WriteLine($"\tDecimal\t\tASCII\t\tBinary\t\tHEX\n");
            ASCII_Decimal_Binary_HEX(1, decimals);
            Console.WriteLine($"\n");

            Console.WriteLine($"\tBinary\t\tASCII\t\tDecimal\t\tHEX\n");
            ASCII_Decimal_Binary_HEX(2, binaries);
            Console.WriteLine($"\n");

            Console.WriteLine($"\tHEX\t\tASCII\t\tDecimal\t\tBinary\n");
            ASCII_Decimal_Binary_HEX(3, hexValues);
            Console.WriteLine($"\n");
        }

        public static void ASCII_Decimal_Binary_HEX(int operationNr, object value)
        {
            switch (operationNr)
            {
                case 0:
                    ASCII_Decimal_Binary_Hex(value);
                    break;
                case 1:
                    Decimal_ASCII_Binary_Hex(value);
                    break;
                case 2:
                    Binary_ASCII_Decimal_Hex(value);
                    break;
                case 3:
                    Hex_ASCII_Decimal_Binary(value);
                    break;
                default:
                    break;
            }
        }

        static void ASCII_Decimal_Binary_Hex(object value)
        {
            string? message = value.ToString();

            if (message is not null)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    string c = message.Substring(i, 1);

                    // ASCII -> Decimal
                    byte[] d = Encoding.ASCII.GetBytes(c);
                    string d0 = "";

                    for (int j = 0; j < d.Length; j++)
                    {
                        d0 += d[j];
                    }

                    // ASCII -> Binary
                    string b = string.Join("", c.Select(o => Convert.ToString(o, 2)));

                    // ASCII -> HEX
                    int h = 0;
                    char[] h1 = c.ToCharArray();
                    foreach (char item in h1)
                    {
                        h = Convert.ToInt32(item);
                    }

                    Console.WriteLine($"\t{c}\t\t{d0}\t\t{b}\t\t{h:X}");
                }
            }
        }

        static void Decimal_ASCII_Binary_Hex(object value)
        {
            byte[] d1 = (byte[])value;

            for (int i = 0; i < d1.Length; i++)
            {
                // Decimal -> ASCII
                string c1s = char.ConvertFromUtf32(d1[i]);
                char c1 = (char)d1[i];

                // Decimal -> Binary
                string b1 = string.Join("", c1s.Select(o => Convert.ToString(o, 2)));

                // Decimal -> HEX
                string d1h = $"{d1[i]:X}";

                Console.WriteLine($"\t{d1[i]}\t\t{c1}\t\t{b1}\t\t{d1h}");
            }
        }

        static void Binary_ASCII_Decimal_Hex(object value)
        {
            int[] b2 = (int[])value;

            for (int i = 0; i < b2.Length; i++)
            {
                // Binary -> Decimal
                int d2 = Convert.ToInt32(b2[i].ToString(), 2);

                // Binary -> HEX
                string h2 = $"{d2:X}";

                // Binary -> ASCII
                char c2 = (char)d2;

                Console.WriteLine($"\t{b2[i]}\t\t{c2}\t\t{d2}\t\t{h2}");
            }
        }

        static void Hex_ASCII_Decimal_Binary(object value)
        {
            string[] h3 = (string[])value;

            for (int i = 0; i < h3.Length; i++)
            {
                // HEX -> Decimal
                //int h31 = Convert.ToInt32(h3[i], 16);
                int h31 = int.Parse(h3[i], NumberStyles.HexNumber);

                // HEX -> ASCII
                string c3s = char.ConvertFromUtf32(h31);
                char c3 = (char)h31;

                // HEX -> Binary
                string b3 = string.Join("", c3s.Select(o => Convert.ToString(o, 2)));

                Console.WriteLine($"\t{h3[i]}\t\t{c3}\t\t{h31}\t\t{b3}");
            }
        }
    }
}
