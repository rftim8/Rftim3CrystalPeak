namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftFloat
    {
        /// <summary>
        /// 6-9 digits of precision
        /// </summary>
        public RftFloat()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {float.MinValue}");
            Console.WriteLine($"MaxValue: {float.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(float)}");
            Console.WriteLine($"Bits: {sizeof(float) * 8}");
            Console.WriteLine($"Constant pi: {float.Pi}");
            Console.WriteLine($"Constant e: {float.E}");
            Console.WriteLine($"Constant tau: {float.Tau}");
            Console.WriteLine($"Constant epsilon: {float.Epsilon}");
            Console.WriteLine($"Nan: {float.NaN}");
            Console.WriteLine($"Negative infinity: {float.NegativeInfinity}");
            Console.WriteLine($"Positive infinity: {float.PositiveInfinity}");
            Console.WriteLine($"Negative zero: {float.NegativeZero}");

            int x = (int)3.4f; // narrowing
            Console.WriteLine(x);
        }
    }
}
