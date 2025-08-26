using System.Numerics;

namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftBigInteger
    {
        private static readonly string bi0 = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

        public RftBigInteger()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"BigInteger: {BigInteger.Parse(bi0)}");
            Console.WriteLine($"BigInteger 0: {BigInteger.Zero}");
            Console.WriteLine($"BigInteger 1: {BigInteger.One}");
            Console.WriteLine($"BigInteger -1: {BigInteger.MinusOne}");
        }
    }
}
