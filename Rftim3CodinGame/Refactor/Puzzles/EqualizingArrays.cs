namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class EqualizingArrays
    {
        public EqualizingArrays()
        {
            //string[] x = { "1", "2", "0", "1" };
            //string[] y = { "0", "1", "3", "0" };

            int[] x = { 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 0 };
            int[] y = { 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1 };

            //string[] x = { "107", "96", "94", "95", "106", "95", "107", "86", "106", "108" };
            //string[] y = { "0", "0", "0", "0", "0", "1000", "0", "0", "0", "0" };

            //string[] x = { "187", "185", "218", "207", "201", "179", "200", "222", "220", "181" };
            //string[] y = { "1000", "0", "0", "0", "0", "0", "0", "0", "0", "1000" };

            //int[] x1 = x.Select(o => int.Parse(o)).ToArray();
            //int[] y1 = y.Select(o => int.Parse(o)).ToArray();

            Solve(x, y);
        }

        private static void Solve(int[] x, int[] y)
        {
            List<string> moves = new();

            int sumX = x[0];
            int sumY = y[0];

            bool dir = true;
            int i = 0;

            while (string.Join("", x.Select(o => o.ToString()).ToArray()) != string.Join("", y.Select(o => o.ToString()).ToArray()))
            {
                int temp;

                if (dir)
                {
                    if (sumX > sumY)
                    {
                        temp = x[i] - y[i];
                        x[i] -= temp;
                        x[i + 1] += temp;
                        sumX = x[i + 1];
                        sumY = y[i + 1];
                        moves.Add($"{i + 1} {1} {temp}");
                        i++;
                    }
                    else if (sumY == sumX)
                    {
                        sumX = x[i + 1];
                        sumY = y[i + 1];
                        i++;
                    }
                    else
                    {
                        if (sumX + x[i + 1] < sumY)
                        {
                            sumX += x[i + 1];
                            sumY += y[i + 1];
                            i++;
                        }
                        else if (sumX + x[i + 1] >= sumY)
                        {
                            temp = sumY - sumX;
                            x[i + 1] -= temp;
                            x[i] += temp;
                            sumX = x[i];
                            sumY = y[i];
                            moves.Add($"{i + 2} {-1} {temp}");
                            dir = false;
                        }
                    }
                }
                else
                {
                    if (sumX > sumY)
                    {
                        temp = x[i] - y[i];
                        x[i - 1] += temp;
                        x[i] -= temp;
                        sumX = x[i - 1];
                        sumY = y[i - 1];
                        moves.Add($"{i + 1} {-1} {temp}");
                        i--;
                    }
                    else if (sumX == sumY)
                    {
                        sumX = x[i + 1];
                        sumY = y[i + 1];
                        i++;
                        dir = true;
                    }

                }

                Console.WriteLine($"{string.Join("", x.Select(o => o.ToString()).ToArray())}");
                Console.WriteLine($"{string.Join("", y.Select(o => o.ToString()).ToArray())}");
            }

            Console.WriteLine($"{moves.Count}");
            foreach (string item in moves)
            {
                Console.WriteLine(item);
            }
        }
    }
}
