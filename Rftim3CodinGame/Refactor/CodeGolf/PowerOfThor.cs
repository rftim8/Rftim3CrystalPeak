namespace Rftim3CodinGame.Refactor.CodeGolf
{
    public class PowerOfThor
    {
        public PowerOfThor()
        {
            //Solve();
        }

        private static void Solve()
        {
            int[] i = (Console.ReadLine() ?? string.Empty).Split(' ').Select(o => int.Parse(o)).ToArray(); int a = i[0], c = i[1], b = i[2], d = i[3]; while (true) { string t = Console.ReadLine() ?? string.Empty; string e = "", f = ""; if (a > b) { e = "E"; b--; } else if (a < b) { e = "W"; b++; } if (c < d) { f = "N"; d--; } else if (c > d) { f = "S"; d++; } Console.WriteLine(f + e); }
        }
    }
}

