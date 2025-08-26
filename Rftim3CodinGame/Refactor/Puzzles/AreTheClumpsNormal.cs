namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class AreTheClumpsNormal
    {
        public AreTheClumpsNormal()
        {
            //string n = "157285";
            //string n = "25747";
            string n = "10081803";

            Solve(n);
        }

        private static void Solve(string n)
        {
            List<int> clumps = [0];

            for (int i = 1; i < 10; i++)
            {
                clumps.Add(0);
                int remainder = Convert.ToInt32(n[..1]) % i;

                for (int j = 1; j < n.Length; j++)
                {
                    if (remainder != Convert.ToInt32(n[j].ToString()) % i) clumps[i]++;
                    remainder = Convert.ToInt32(n[j].ToString()) % i;
                }
            }

            int baseNr = 0;

            for (int i = 1; i < clumps.Count; i++)
            {
                if (clumps[i] < clumps[i - 1])
                {
                    baseNr = i;
                    break;
                }
            }

            Console.WriteLine(baseNr != 0 ? $"{baseNr}" : $"Normal");
        }
    }
}
