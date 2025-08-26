namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class ShootEnemyAircraft
    {
        public ShootEnemyAircraft()
        {
            //int n = 6;
            //List<string> map = new()
            //{
            //    "....................",
            //    ".>..................",
            //    "...................<",
            //    "....................",
            //    "....................",
            //    "_________^__________"
            //};

            int n = 10;
            List<string> map = new()
            {
                "...........................<...........",
                ".......................................",
                ".......................................",
                ".......................................",
                "............<..<..<..<..<..<..<..<..<..",
                ".......................................",
                ".......................................",
                ".......................................",
                "..>......<..<..<..<..<..<..<..<..<..<..",
                "______^________________________________"
            };
            Solve(n, map);
        }

        private static void Solve(int n, List<string> map)
        {
            (int, int) me;
            me.Item1 = n - 1;
            me.Item2 = map[n - 1].IndexOf('^');

            List<int> shots = new();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == '>')
                    {
                        Console.WriteLine($"{i} : {j} -> {me.Item1} : {me.Item2}");
                        shots.Add(me.Item2 - j - (me.Item1 - i));
                    }
                    if (map[i][j] == '<')
                    {
                        Console.WriteLine($"{i} : {j} -> {me.Item1} : {me.Item2}");
                        shots.Add(j - me.Item2 - (me.Item1 - i));
                    }
                }
            }
            shots.Sort();

            int k = 0;
            for (int i = 1; i <= shots.Max(); i++)
            {
                if (i < shots[k])
                {
                    Console.WriteLine("WAIT");
                }
                else if (i == shots[k])
                {
                    Console.WriteLine("SHOOT");
                    k++;
                }
            }
        }
    }
}
