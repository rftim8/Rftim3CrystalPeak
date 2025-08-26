namespace Rftim3Console.System.Actions
{
    public class RftActionTT
    {
        public RftActionTT()
        {
            List<string> names = ["Ana", "John", "Maria", "Mark"];

            Action<string, string> x = Print;

            foreach (string item in names)
            {
                x(item, item);
            }
        }

        private static void Print(string s0, string s1)
        {
            Console.WriteLine($"{s0}-{s1}");
        }
    }
}
