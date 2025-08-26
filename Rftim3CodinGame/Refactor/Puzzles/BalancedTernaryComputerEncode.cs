namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class BalancedTernaryComputerEncode
    {
        public BalancedTernaryComputerEncode()
        {
            //int n = 8;
            int n = -15;

            Solve(n);
        }

        private static void Solve(int n)
        {
            int result = 0;
            int nrChars = 1;
            List<string> digits = new()
            {
                "T",
                "0",
                "1"
            };
            List<string> permutations = new();
            List<string> permutationsAdded = new()
            {
                "T",
                "0",
                "1"
            };

            while (result != n)
            {
                for (int i = nrChars - 1; i < nrChars; i++)
                {
                    permutations.Clear();
                    permutations.AddRange(permutationsAdded);

                    foreach (string permutation in permutations)
                    {
                        foreach (string digit in digits)
                        {
                            string newPermutation = permutation + digit;
                            if (!permutations.Contains(newPermutation)) permutationsAdded.Add(newPermutation);
                        }
                    }

                    foreach (string item in permutationsAdded)
                    {
                        for (int k = 0, j = item.Length - 1; k < item.Length; k++, j--)
                        {
                            if (item.Substring(j, 1) == "T") result += (int)(-1 * Math.Pow(3, k));
                            else result += (int)(Convert.ToInt32(item[j].ToString()) * Math.Pow(3, k));
                        }

                        if (result == n)
                        {
                            Console.WriteLine($"{item}");
                            return;
                        }

                        result = 0;
                    }
                }

                nrChars++;
            }

            Console.WriteLine($"{result}");
        }
    }
}
