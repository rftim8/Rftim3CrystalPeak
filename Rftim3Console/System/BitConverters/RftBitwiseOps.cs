using System.Collections;
using System.Text;

namespace Rftim3Console.System.BitConverters
{
    public class RftBitwiseOps
    {
        public RftBitwiseOps()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            int x = 0;
            int y = 1;

            Console.WriteLine($"AND: {x & y}");
            Console.WriteLine($"OR: {x | y}");
            Console.WriteLine($"XOR: {x ^ y}");
            Console.WriteLine($"NAND: {~(x & y)}");
            Console.WriteLine($"NOR: {~(x | y)}");
            Console.WriteLine($"NXOR: {~(x ^ y)}");
            Console.WriteLine();

            bool[] a = [true, false, false, true];
            bool[] a1 = [false, false, true, true];
            BitArray bitArray0 = new(a);
            BitArray bitArray1 = new(a1);

            Console.WriteLine($"AND: {GetString(bitArray0.And(bitArray1))}");
            Console.WriteLine($"OR: {GetString(bitArray0.Or(bitArray1))}");
            Console.WriteLine($"XOR: {GetString(bitArray0.Xor(bitArray1))}");
            Console.WriteLine($"NAND: {GetString(bitArray0.And(bitArray1).Not())}");
            Console.WriteLine($"NOR: {GetString(bitArray0.Or(bitArray1).Not())}");
            Console.WriteLine($"NXOR: {GetString(bitArray0.Xor(bitArray1).Not())}");
        }

        private static string GetString(BitArray bits)
        {
            StringBuilder sb = new();
            foreach (object? b in bits)
            {
                sb.Append((bool)b ? "1" : "0");
            }

            return sb.ToString();
        }
    }
}
