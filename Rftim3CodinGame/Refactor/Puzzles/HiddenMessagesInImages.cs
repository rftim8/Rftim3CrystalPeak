using System.Text;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class HiddenMessagesInImages
    {
        public HiddenMessagesInImages()
        {
            const int w = 8;
            const int h = 12;
            const int x = w * h;
            int[] pixel = new int[x] {
                220, 251, 30, 182, 233, 122, 150, 30,
                132, 101, 135, 212, 246, 201, 128, 203,
                62, 33, 39, 70, 73, 175, 218, 140,
                44, 165, 9, 140, 83, 67, 34, 100,
                142, 75, 125, 242, 49, 175, 209, 37,
                252, 26, 123, 6, 186, 72, 230, 94,
                218, 85, 228, 205, 146, 67, 219, 187,
                194, 159, 81, 190, 51, 235, 41, 121,
                208, 33, 245, 71, 172, 218, 97, 130,
                122, 31, 135, 198, 135, 249, 174, 28,
                162, 109, 149, 216, 156, 195, 140, 10,
                100, 252, 1, 164, 150, 22, 144, 109
            };

            Solve(x, pixel);
        }

        private static void Solve(int x, int[] pixel)
        {
            string temp = "";

            for (int i = 1; i <= x; i++)
            {
                var binStr = string.Join("", pixel[i - 1].ToString().Select(b => Convert.ToString(b, 2)));
                temp += binStr[binStr.Length - 1].ToString();
            }

            StringBuilder result = new();
            while (temp.Length > 0)
            {
                string character = temp[..8];
                temp = temp[8..];
                int value = 0;
                foreach (int item in character)
                {
                    int z = item - 48;
                    value = value << 1 | z;
                }
                result.Append(Convert.ToChar(value));
            }

            Console.WriteLine(result);
        }
    }
}
