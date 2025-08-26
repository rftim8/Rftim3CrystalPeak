using System.Numerics;

namespace Rftim3Console.System.ValueTypes
{
    internal class RftBigInteger
    {
        private static readonly string bi0 = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";

        public RftBigInteger()
        {
            int func = 0;

            switch (func)
            {
                case 0:
                    Properties();
                    break;
                default:
                    break;
            }

            Properties();
        }

        private static void Properties()
        {
            Console.WriteLine($"BigInteger: {BigInteger.Parse(bi0)}");
            Console.WriteLine($"BigInteger 0: {BigInteger.Zero}");
            Console.WriteLine($"BigInteger 1: {BigInteger.One}");
            Console.WriteLine($"BigInteger -1: {BigInteger.MinusOne}");
        }
    }
}
