namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TextFormatting
    {
        public TextFormatting()
        {
            //string intext = "one,two,three.";
            //string intext = "one,two,three.four,five, six.";
            //string intext = "one , two , three . four , five , six .";
            //string intext = "one , TWO  ,,  three  ..  four,fivE , six .";
            string intext = "when a father gives to his son,,, Both laugh; When a son gives to his father, , , Both cry...shakespeare";

            Solve(intext);
        }

        private static void Solve(string intext)
        {
            intext = intext.ToLower();
            intext = intext[..1].ToUpper() + intext[1..];

            for (int i = 1; i < intext.Length - 1; i++)
            {
                string pre = intext[i - 1].ToString();
                string crt = intext[i].ToString();
                string next = intext[i + 1].ToString();
                if (crt == " " && (next == " " || next == "," || next == "."))
                {
                    intext = $"{intext[..i]}{intext[(i + 1)..]}";
                    i--;
                }
                if (crt == " " && pre == ".") intext = $"{intext[..(i + 1)]}{intext[i + 1].ToString().ToUpper()}{intext[(i + 2)..]}";
                if (crt == " " && pre == "," && next == ",")
                {
                    intext = $"{intext[..i]}{intext[(i + 2)..]}";
                    i--;
                }
                if (crt == "," && next == ",")
                {
                    intext = $"{intext[..i]}{intext[(i + 1)..]}";
                    i--;
                }
                if (crt == "," && next != " ") intext = $"{intext[..(i + 1)]} {intext[(i + 1)..]}";
                if (crt == "." && next == ".")
                {
                    intext = $"{intext[..i]}{intext[(i + 1)..]}";
                    i--;
                }
                if (crt == "." && (next != "." || next != "," || next != " ")) intext = $"{intext[..(i + 1)]} {intext[i + 1].ToString().ToUpper()}{intext[(i + 2)..]}";
                if (crt == "." && next == " ") intext = $"{intext[..(i + 1)]} {intext[i + 3].ToString().ToUpper()}{intext[(i + 4)..]}";
            }

            Console.WriteLine(intext);
        }
    }
}
