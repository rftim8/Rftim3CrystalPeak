namespace Rftim3Console.System.Booleans
{
    public class RftBooleanParse
    {
        public RftBooleanParse()
        {
            bool val;
            string input;

            input = bool.TrueString;
            val = bool.Parse(input);
            Console.WriteLine($"'{input}' parsed as {val}");
        }
    }
}
