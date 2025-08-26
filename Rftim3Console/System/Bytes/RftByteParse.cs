using System.Globalization;

namespace Rftim3Console.System.Bytes
{
    public class RftByteParse
    {
        public RftByteParse()
        {
            Sample0();
            Sample1();
        }

        private static void Sample0()
        {
            NumberStyles style;
            CultureInfo culture;
            string value;
            byte number;

            // Parse number with decimals.
            // NumberStyles.Float includes NumberStyles.AllowDecimalPoint.
            style = NumberStyles.Float;
            culture = CultureInfo.CreateSpecificCulture("fr-FR");
            value = "12,000";

            number = byte.Parse(value, style, culture);
            Console.WriteLine($"Converted '{value}' to {number}.");

            culture = CultureInfo.CreateSpecificCulture("en-GB");
            try
            {
                number = byte.Parse(value, style, culture);
                Console.WriteLine($"Converted '{value}' to {number}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{value}'.");
            }

            value = "12.000";
            number = byte.Parse(value, style, culture);
            Console.WriteLine($"Converted '{value}' to {number}.");
        }

        private static void Sample1()
        {
            string stringToConvert;
            byte byteValue;

            stringToConvert = " 214 ";
            try
            {
                byteValue = byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
                Console.WriteLine($"Converted '{stringToConvert}' to {byteValue}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{stringToConvert}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"'{stringToConvert}' is greater than {byte.MaxValue} or less than {byte.MinValue}.");
            }

            stringToConvert = " + 214 ";
            try
            {
                byteValue = byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
                Console.WriteLine($"Converted '{stringToConvert}' to {byteValue}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{stringToConvert}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"'{stringToConvert}' is greater than {byte.MaxValue} or less than {byte.MinValue}.");
            }

            stringToConvert = " +214 ";
            try
            {
                byteValue = byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
                Console.WriteLine($"Converted '{stringToConvert}' to {byteValue}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{stringToConvert}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"'{stringToConvert}' is greater than {byte.MaxValue} or less than {byte.MinValue}.");
            }
        }
    }
}
