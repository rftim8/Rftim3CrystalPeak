using System.Globalization;

namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftString
    {
        private static readonly string s0 = "Hello World!";
        private static readonly string? s1 = " ";

        public RftString()
        {
            RftProperties();
        }

        private static void RftProperties()
        {
            Console.WriteLine(string.IsNullOrEmpty(s0));
            Console.WriteLine(string.IsNullOrWhiteSpace(s0));

            Console.WriteLine(string.IsNullOrEmpty(s1));
            Console.WriteLine(string.IsNullOrWhiteSpace(s1));

            List<string> l0 = ["a", "b", "c", "d"];
            Console.WriteLine(string.Join(',', l0));

            string formatedString = string.Format(new CultureInfo("en-US"), "{0:c}  {1:00.00}  {2:#.00}  {3:0,0}", 1.55, 15.555, .55, 1000);
            Console.WriteLine(formatedString);

            Console.WriteLine("Padding:         {0:d4}", 11);
            Console.WriteLine("Decimals:        {0:f3}", 12.22222222);
            Console.WriteLine("Commas:          {0:n0}", 1233333333);
        }
    }
}
