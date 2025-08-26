namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class TheResistance
    {
        public TheResistance()
        {
            //string l = "......-...-..---.-----.-..-..-..";
            //HashSet<string> w = new()
            //{
            //    "HELL",
            //    "HELLO",
            //    "OWORLD",
            //    "WORLD",
            //    "TEST"
            //};

            string l = "-.-..---.-..---.-..--";
            HashSet<string> w = new()
            {
                "CAT",
                "KIM",
                "TEXT",
                "TREM",
                "CEM"
            };

            Solve(l, w);
        }

        private static void Solve(string l, HashSet<string> w)
        {
            long c = 0;

            Dictionary<char, string> morse = new()
            {
                { 'A', ".-"},
                { 'B', "-..."},
                { 'C', "-.-."},
                { 'D', "-.."},
                { 'E', "."},
                { 'F', "..-."},
                { 'G', "--."},
                { 'H', "...."},
                { 'I', ".."},
                { 'J', ".---"},
                { 'K', "-.-"},
                { 'L', ".-.."},
                { 'M', "--"},
                { 'N', "-."},
                { 'O', "---"},
                { 'P', ".--."},
                { 'Q', "--.-"},
                { 'R', ".-."},
                { 'S', "..."},
                { 'T', "-"},
                { 'U', "..-"},
                { 'V', "...-"},
                { 'W', ".--"},
                { 'X', "-..-"},
                { 'Y', "-.--"},
                { 'Z', "--.."},
            };

            List<string> possible = new();
            foreach (string item in w)
            {
                string x = "";
                for (int i = 0; i < item.Length; i++)
                {
                    x += morse[item[i]];
                }
                Console.WriteLine($"o: {l}");
                Console.WriteLine($"w: {x}");
                Console.WriteLine();
                if (l.Contains(x)) possible.Add(x);
            }

            Console.WriteLine(c);
        }
    }
}
