using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02469_ConvertTheTemperature
    {
        /// <summary>
        /// You are given a non-negative floating point number rounded to two decimal places celsius, that denotes the temperature in Celsius.
        /// You should convert Celsius into Kelvin and Fahrenheit and return it as an array ans = [kelvin, fahrenheit].
        /// Return the array ans.Answers within 10-5 of the actual answer will be accepted.
        /// Note that:
        /// Kelvin = Celsius + 273.15
        /// Fahrenheit = Celsius * 1.80 + 32.00
        /// </summary>
        public _02469_ConvertTheTemperature()
        {
            double[] x = ConvertTemperature(36.50);
            RftTerminal.RftReadResult(x);
            double[] x0 = ConvertTemperature(122.11);
            RftTerminal.RftReadResult(x0);
        }

        private static double[] ConvertTemperature(double celsius)
        {
            return [celsius + 273.15, celsius * 1.80 + 32];
        }
    }
}
