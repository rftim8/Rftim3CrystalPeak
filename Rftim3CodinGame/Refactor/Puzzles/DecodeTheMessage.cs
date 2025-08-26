namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class DecodeTheMessage
    {
        public DecodeTheMessage()
        {
            //long P = 35;
            //string C = "abcdefghijklmnopqrstuvwxyz";

            //long P = 13484;
            //string C = "abcdefghijklmnopqrstuvwxyz";

            //long P = 132;
            //string C = "ABeDFC";

            long p = 34170657950616;
            string c = "H_eo: Wrld!";

            Solve(p, c);
        }

        private static void Solve(long p, string c)
        {
            string message = "";

            while (p >= 0)
            {
                int md = (int)(p % c.Length);
                message += c[md];
                p = p / c.Length - 1;
            }

            Console.WriteLine($"{message}");
        }
    }
}
