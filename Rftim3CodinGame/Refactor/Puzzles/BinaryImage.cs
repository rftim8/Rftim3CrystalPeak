using System.Text;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class BinaryImage
    {
        public BinaryImage()
        {

            //List<string> rows = new()
            //{
            //    "1 3 2 1",
            //    "1 3 2 1",
            //    "1 3 2 1",
            //    "1 3 2 1"
            //};

            List<string> rows = new()
            {
                "0 1 1 1 1",
                "0 1 1 1 1",
                "0 1 1 1 1",
                "0 1 1 1 1"
            };


            Solve(rows);
        }

        private static void Solve(List<string> rows)
        {
            bool pixel = true;
            List<string> pixels = new();

            foreach (string row in rows)
            {
                StringBuilder sb = new();

                for (int i = 0; i < row.Split(' ').Length; i++)
                {
                    int temp = int.Parse(row.Split(' ')[i]);

                    if (i == 0 && temp == 0) pixel = false;
                    else
                    {
                        if (pixel)
                        {
                            for (int j = 0; j < temp; j++) sb.Append('.');
                            pixel = false;
                        }
                        else
                        {
                            for (int j = 0; j < temp; j++) sb.Append('O');
                            pixel = true;
                        }
                    }
                }

                pixels.Add(sb.ToString());
                pixel = true;
            }

            if (pixels.Max(o => o.Length) == pixels.Min(o => o.Length))
            {
                foreach (string pixelRow in pixels) Console.WriteLine($"{pixelRow}");
            }
            else Console.WriteLine($"INVALID");
        }
    }
}
