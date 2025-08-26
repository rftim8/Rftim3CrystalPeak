namespace Rftim3Console.System.Chars
{
    public class RftChar
    {
        public RftChar()
        {
            Sample0();
            //RftCompositeFormatting();
            //RftProperties();
            //RftStringToCharArray();
            //RftUnicode();
            //RftVerbatim();
            //RftVerbatimInterpolation();
        }

        private static void Sample0()
        {
            char chA = 'A';
            char ch1 = '1';
            string str = "test string";

            Console.WriteLine(chA.CompareTo('B'));          //-----------  Output: "-1" (meaning 'A' is 1 less than 'B')
            Console.WriteLine(chA.Equals('A'));             //-----------  Output: "True"
            Console.WriteLine(char.GetNumericValue(ch1));   //-----------  Output: "1"
            Console.WriteLine(char.IsControl('\t'));        //-----------  Output: "True"
            Console.WriteLine(char.IsDigit(ch1));           //-----------  Output: "True"
            Console.WriteLine(char.IsLetter(','));          //-----------  Output: "False"
            Console.WriteLine(char.IsLower('u'));           //-----------  Output: "True"
            Console.WriteLine(char.IsNumber(ch1));          //-----------  Output: "True"
            Console.WriteLine(char.IsPunctuation('.'));     //-----------  Output: "True"
            Console.WriteLine(char.IsSeparator(str, 4));    //-----------  Output: "True"
            Console.WriteLine(char.IsSymbol('+'));          //-----------  Output: "True"
            Console.WriteLine(char.IsWhiteSpace(str, 4));   //-----------  Output: "True"
            Console.WriteLine(char.Parse("S"));             //-----------  Output: "S"
            Console.WriteLine(char.ToLower('M'));           //-----------  Output: "m"
            Console.WriteLine('x'.ToString());              //-----------  Output: "x"
            Console.WriteLine($"Test: {char.IsPunctuation('-')}");
            Console.WriteLine($"Test: {char.IsPunctuation('+')}");
        }

        public static string Test()
        {
            char[] x = ['H', 'e', 'l', 'l', 'o'];
            return string.Join("", x);
        }

        private static void RftCompositeFormatting()
        {
            string a = "Hello";
            string b = "there!";
            Console.WriteLine(string.Format("{0} {1} {0}", a, b));
            decimal c = 2.3442543354m;
            Console.WriteLine($"Value: {c}");
            Console.WriteLine($"Floating points: {c:f5}");
            Console.WriteLine($"Number: {c:N4}");
            Console.WriteLine($"Percentage: {c:P1}");
            Console.WriteLine($"Currency: {c:C3}");
            Console.WriteLine();
            string d = "Padding";
            Console.WriteLine(d.PadLeft(12, '-'));

            char[] e = ['(', '[', '{'];
            string e1 = "werwer( wergter{ qrwerwre[";
            Console.WriteLine(e1.IndexOfAny(e));
        }

        private static void RftProperties()
        {
            Console.WriteLine($"MinValue: {char.MinValue}");
            Console.WriteLine($"MaxValue: {char.MaxValue}");
            Console.WriteLine($"Bytes: {sizeof(char)}");
            Console.WriteLine($"Bits: {sizeof(char) * 8}");
        }

        private static void RftStringToCharArray()
        {
            string x = "This is a string";
            char[] y = x.ToCharArray();
            Array.Reverse(y);
            foreach (char item in y)
            {
                Console.Write(item);
            }
            Console.WriteLine($"\n{string.Join(",", y)}");
        }

        private static void RftUnicode()
        {
            // CMD does not display unicode
            // Kon'nichiwa World
            Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!"); // UTF-16
        }

        private static void RftVerbatim()
        {
            Console.WriteLine(@"This is a (verbatim) \string");
        }

        private static void RftVerbatimInterpolation()
        {
            string x = "Hello";
            Console.WriteLine($@"{x} \there!");
        }
    }
}
