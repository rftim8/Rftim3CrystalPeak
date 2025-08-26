namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class SimpleAwale
    {
        public SimpleAwale()
        {
            //string opBowls = "5 1 0 6 2 2 3";
            //string myBowls = "3 4 0 3 3 2 2";
            //int _num = 0;

            //string opBowls = "5 1 0 6 2 2 3";
            //string myBowls = "3 4 0 3 3 2 2";
            //int _num = 3;

            string opBowls = "4 2 1 7 0 6 2";
            string myBowls = "5 14 1 4 0 2 3";
            int num = 1;

            Solve(opBowls, myBowls, num);
        }

        private static void Solve(string opBowls, string myBowls, int num)
        {
            List<int> bowls = new();
            bowls.AddRange(myBowls.Split(' ').Select(o => int.Parse(o)));
            bowls.AddRange(opBowls.Split(' ').Select(o => int.Parse(o)));
            int qty = bowls[num];
            bowls[num] = 0;
            num++;

            while (qty > 0)
            {
                if (num != bowls.Count - 1)
                {
                    if (bowls.Count > num) bowls[num]++;
                }
                else
                {
                    num = 0;
                    bowls[num]++;
                }

                num++;
                qty--;
            }

            for (int i = 7; i < bowls.Count; i++)
            {
                Console.Write(i < bowls.Count - 1 ? $"{bowls[i]} " : $"[{bowls[i]}]");
            }
            Console.WriteLine();

            for (int i = 0; i < bowls.Count / 2; i++)
            {
                Console.Write(i < bowls.Count / 2 - 1 ? $"{bowls[i]} " : $"[{bowls[i]}]");
            }

            if (num == 7) Console.WriteLine($"\nREPLAY");
        }
    }
}
