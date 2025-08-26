namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class War
    {
        private static int r = 0;
        private static readonly Queue<string> p1 = new();
        private static readonly Queue<string> p2 = new();
        private static bool p1win = false;
        private static bool p2win = false;
        private static readonly List<string> cards = new()
        {
            "2","3","4","5","6","7","8","9","10","J","Q","K","A"
        };
        private static readonly Queue<string> war1 = new();
        private static readonly Queue<string> war2 = new();
        private static string p1p = "";
        private static string p2p = "";
        private static string p1c = "";
        private static string p2c = "";

        public War()
        {
            //p1.Enqueue("AD");
            //p1.Enqueue("KC");
            //p1.Enqueue("QC");

            //p2.Enqueue("KH");
            //p2.Enqueue("QS");
            //p2.Enqueue("JC");

            //p1.Enqueue("8C");
            //p1.Enqueue("KD");
            //p1.Enqueue("AH");
            //p1.Enqueue("QH");
            //p1.Enqueue("2S");

            //p2.Enqueue("8D");
            //p2.Enqueue("2D");
            //p2.Enqueue("3H");
            //p2.Enqueue("4D");
            //p2.Enqueue("3S");

            //p1.Enqueue("6H");
            //p1.Enqueue("7H");
            //p1.Enqueue("6C");
            //p1.Enqueue("QS");
            //p1.Enqueue("7S");
            //p1.Enqueue("8D");
            //p1.Enqueue("6D");
            //p1.Enqueue("5S");
            //p1.Enqueue("6S");
            //p1.Enqueue("QH");
            //p1.Enqueue("4D");
            //p1.Enqueue("3S");
            //p1.Enqueue("7C");
            //p1.Enqueue("3C");
            //p1.Enqueue("4S");
            //p1.Enqueue("5H");
            //p1.Enqueue("QD");
            //p1.Enqueue("5C");
            //p1.Enqueue("3H");
            //p1.Enqueue("3D");
            //p1.Enqueue("8C");
            //p1.Enqueue("4H");
            //p1.Enqueue("4C");
            //p1.Enqueue("QC");
            //p1.Enqueue("5D");
            //p1.Enqueue("7D");

            //p2.Enqueue("JH");
            //p2.Enqueue("AH");
            //p2.Enqueue("KD");
            //p2.Enqueue("AD");
            //p2.Enqueue("9C");
            //p2.Enqueue("2D");
            //p2.Enqueue("2H");
            //p2.Enqueue("JC");
            //p2.Enqueue("10C");
            //p2.Enqueue("KC");
            //p2.Enqueue("10D");
            //p2.Enqueue("JS");
            //p2.Enqueue("JD");
            //p2.Enqueue("9D");
            //p2.Enqueue("9S");
            //p2.Enqueue("KS");
            //p2.Enqueue("AS");
            //p2.Enqueue("KH");
            //p2.Enqueue("10S");
            //p2.Enqueue("8S");
            //p2.Enqueue("2S");
            //p2.Enqueue("10H");
            //p2.Enqueue("8H");
            //p2.Enqueue("AC");
            //p2.Enqueue("2C");
            //p2.Enqueue("9H");

            p1.Enqueue("AH");
            p1.Enqueue("4H");
            p1.Enqueue("5D");
            p1.Enqueue("6D");
            p1.Enqueue("QC");
            p1.Enqueue("JS");
            p1.Enqueue("8S");
            p1.Enqueue("2D");
            p1.Enqueue("7D");
            p1.Enqueue("JD");
            p1.Enqueue("JC");
            p1.Enqueue("6C");
            p1.Enqueue("KS");
            p1.Enqueue("QS");
            p1.Enqueue("9D");
            p1.Enqueue("2C");
            p1.Enqueue("5S");
            p1.Enqueue("9S");
            p1.Enqueue("6S");
            p1.Enqueue("8H");
            p1.Enqueue("AD");
            p1.Enqueue("4D");
            p1.Enqueue("2H");
            p1.Enqueue("2S");
            p1.Enqueue("7S");
            p1.Enqueue("8C");

            p2.Enqueue("10H");
            p2.Enqueue("4C");
            p2.Enqueue("6H");
            p2.Enqueue("3C");
            p2.Enqueue("KC");
            p2.Enqueue("JH");
            p2.Enqueue("10C");
            p2.Enqueue("AS");
            p2.Enqueue("5H");
            p2.Enqueue("KH");
            p2.Enqueue("10S");
            p2.Enqueue("9H");
            p2.Enqueue("9C");
            p2.Enqueue("8D");
            p2.Enqueue("5C");
            p2.Enqueue("AC");
            p2.Enqueue("3H");
            p2.Enqueue("4S");
            p2.Enqueue("KD");
            p2.Enqueue("7C");
            p2.Enqueue("3S");
            p2.Enqueue("QH");
            p2.Enqueue("10D");
            p2.Enqueue("3D");
            p2.Enqueue("7H");
            p2.Enqueue("QD");

            //p1.Enqueue("10D");
            //p1.Enqueue("9S");
            //p1.Enqueue("8D");
            //p1.Enqueue("KH");
            //p1.Enqueue("7D");
            //p1.Enqueue("5H");
            //p1.Enqueue("6S");

            //p2.Enqueue("10H");
            //p2.Enqueue("7H");
            //p2.Enqueue("5C");
            //p2.Enqueue("QC");
            //p2.Enqueue("2C");
            //p2.Enqueue("4H");
            //p2.Enqueue("6D");

            Solve();
        }

        private static void Solve()
        {
            while (!p1win && !p2win)
            {
                r++;
                p1p = p1.Peek()[..^1];
                p2p = p2.Peek()[..^1];
                p1c = p1.Dequeue();
                p2c = p2.Dequeue();

                Console.WriteLine($"{p1p} : {p2p} -> {p1.Count} {p2.Count}");

                if (cards.IndexOf(p1p) > cards.IndexOf(p2p))
                {
                    p1.Enqueue(p1c);
                    p1.Enqueue(p2c);

                    if (p2.Count == 0) p1win = true;
                }
                else if (cards.IndexOf(p1p) < cards.IndexOf(p2p))
                {
                    p2.Enqueue(p1c);
                    p2.Enqueue(p2c);

                    if (p1.Count == 0) p2win = true;
                }
                else
                {
                    if (p1.Count < 4 && p2.Count > 3 || p2.Count < 4 && p1.Count > 3)
                    {
                        p1win = true;
                        p2win = true;
                    }
                    else
                    {
                        Waaar();
                    }
                }
            }

            if (p1win && p2win) Console.WriteLine("PAT");
            else if (p1win && !p2win) Console.WriteLine($"1 {r}");
            else Console.WriteLine($"2 {r}");

            foreach (string item in p1)
            {
                Console.WriteLine($"P1: {item}");
            }
            foreach (string item in p2)
            {
                Console.WriteLine($"P2: {item}");
            }
        }

        private static void Waaar()
        {
            war1.Enqueue(p1c);
            war2.Enqueue(p2c);

            for (int i = 0; i < 3; i++)
            {
                war1.Enqueue(p1.Dequeue());
                war2.Enqueue(p2.Dequeue());
            }

            foreach (string item in war1)
            {
                Console.WriteLine($"war1: {item}");
            }

            foreach (string item in war2)
            {
                Console.WriteLine($"war2: {item}");
            }

            p1p = p1.Peek()[..^1];
            p2p = p2.Peek()[..^1];
            p1c = p1.Dequeue();
            p2c = p2.Dequeue();

            Console.WriteLine($"battle: {p1c} : {p2c}");

            int c = 0;
            if (cards.IndexOf(p1p) > cards.IndexOf(p2p))
            {
                c = war1.Count;
                for (int i = 0; i < c; i++)
                {
                    p1.Enqueue(war1.Dequeue());
                }
                p1.Enqueue(p1c);
                c = war2.Count;
                for (int i = 0; i < c; i++)
                {
                    p1.Enqueue(war2.Dequeue());
                }
                p1.Enqueue(p2c);

                if (p2.Count == 0) p1win = true;
            }
            else if (cards.IndexOf(p1p) < cards.IndexOf(p2p))
            {
                c = war1.Count;
                for (int i = 0; i < c; i++)
                {
                    p2.Enqueue(war1.Dequeue());
                }
                p2.Enqueue(p1c);
                c = war2.Count;
                for (int i = 0; i < c; i++)
                {
                    p2.Enqueue(war2.Dequeue());
                }
                p2.Enqueue(p2c);

                if (p1.Count == 0) p2win = true;
            }
            else
            {
                Waaar();
            }
        }
    }
}
