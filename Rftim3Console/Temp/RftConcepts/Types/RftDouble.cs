namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftDouble
    {
        private static readonly double d0 = 11.11;

        /// <summary>
        /// 15-17 digits of precision
        /// </summary>
        public RftDouble()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {double.MinValue}");
            Console.WriteLine($"MaxValue: {double.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(double)}");
            Console.WriteLine($"Bits: {sizeof(double) * 8}");
            Console.WriteLine($"Constant pi: {double.Pi}");
            Console.WriteLine($"Constant e: {double.E}");
            Console.WriteLine($"Constant tau: {double.Tau}");
            Console.WriteLine($"Constant epsilon: {double.Epsilon}");
            Console.WriteLine($"Nan: {double.NaN}");
            Console.WriteLine($"Negative infinity: {double.NegativeInfinity}");
            Console.WriteLine($"Positive infinity: {double.PositiveInfinity}");
            Console.WriteLine($"Negative zero: {double.NegativeZero}");
            Console.WriteLine($"Variable type: {d0.GetTypeCode()}");
        }
    }
}
