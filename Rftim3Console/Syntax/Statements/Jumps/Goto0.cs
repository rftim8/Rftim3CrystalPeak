namespace Rftim3Console.Syntax.Statements.Jumps
{
    internal class Goto0
    {
        public Goto0()
        {
            Test();
        }

        private static void Test()
        {
            int i = 0;

            do
            {
            move:
                switch (i)
                {
                    case 0: Console.WriteLine($"case: {i}"); i++; goto move;
                    case 1: Console.WriteLine($"case: {i}"); i++; goto move;
                }

                i++;
            } while (i < 10);
        }
    }
}
