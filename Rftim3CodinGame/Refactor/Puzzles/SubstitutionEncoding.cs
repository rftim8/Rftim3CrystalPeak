namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class SubstitutionEncoding
    {
        public SubstitutionEncoding()
        {
            List<string> rows = new()
            {
                "A B",
                "C D"
            };
            string message = "CBA";

            Solve(rows, message);
        }

        private static void Solve(List<string> rows, string message)
        {
            List<Chars> chars = new();

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Split(' ').Length; j++)
                {
                    chars.Add(new Chars(rows[i].Split(' ')[j], $"{i}{j}"));
                }
            }

            for (int i = 0; i < message.Length; i++)
            {
                foreach (Chars item in chars)
                {
                    if (message[i].ToString() == item.name) Console.Write($"{item.value}");
                }
            }
            Console.WriteLine();
        }

        class Chars
        {
            public string name, value;

            public Chars(string name, string value)
            {
                this.name = name;
                this.value = value;
            }
        }
    }
}
