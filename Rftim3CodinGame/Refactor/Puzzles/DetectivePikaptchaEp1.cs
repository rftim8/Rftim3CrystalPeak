namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class DetectivePikaptchaEp1
    {
        public DetectivePikaptchaEp1()
        {
            int width = 5;
            int height = 3;

            string x = string.Concat(Enumerable.Repeat(".", width + 2));

            List<string> map = new()
            {
                ".0000#.",
                ".#0#00.",
                ".00#0#.",
            };
            map.Insert(0, x);
            map.Add(x);

            Solve(width, height, map);
        }

        private static void Solve(int width, int height, List<string> map)
        {
            width += 2;
            height += 2;

            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    if (map[i].Substring(j, 1) != "#")
                    {
                        string up = map[i - 1][j].ToString();
                        string right = map[i][j + 1].ToString();
                        string down = map[i + 1][j].ToString();
                        string left = map[i][j - 1].ToString();
                        int counter = 0;

                        if (up != "." && up != "#") counter++;
                        if (right != "." && right != "#") counter++;
                        if (down != "." && down != "#") counter++;
                        if (left != "." && left != "#") counter++;

                        map[i] = map[i][..j] + counter.ToString() + map[i][(j + 1)..];
                    }
                }
            }

            map.RemoveAt(0);
            map.RemoveAt(map.Count - 1);

            foreach (string line in map)
            {
                Console.WriteLine($"{line[1..^1]}");
            }
        }
    }
}
