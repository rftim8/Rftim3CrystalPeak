using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class GravityTumbler
    {
        /// <summary>
        /// The program must output the result of tumbling a landscape a certain number of times.
        /// 
        /// Tumbling entails:
        /// - rotating the landscape counterclockwise by 90°
        /// - letting the hash bits # fall down
        /// 
        /// The map is composed of.and #.
        /// </summary>
        public GravityTumbler()
        {
            List<string> a0 = GravityTumbler0(17, 5, 1,
                [
                    ".................",
                    ".................",
                    "...##...###..#...",
                    ".####..#####.###.",
                    "#################"
                ]);
            RftTerminal.RftReadResult(a0);
        }

        public static List<string> GravityTumbler0(int a0, int a1, int a2, List<string> a3) => RftGravityTumbler0(a0, a1, a2, a3);

        private static List<string> RftGravityTumbler0(int width, int height, int count, List<string> raster)
        {
            List<string> res = [];
            count %= 2;
            Dictionary<int, int> kvp = [];
            for (int i = 0; i < height; i++)
            {
                kvp[i] = raster[i].Count(o => o == '.'); // Count dots in each row
            }

            // If the stack is vertical
            if (count == 1)
            {
                for (int i = 0; i < width; i++)
                {
                    string t = "";
                    for (int j = 0; j < height; j++)
                    {
                        t += kvp[j] <= i ? '#' : '.'; // Compare current index with the number of dots
                    }
                    res.Add(t);
                }
            }
            // If the stack is horizontal
            else
            {
                for (int i = 0; i < height; i++)
                {
                    string t = "";
                    for (int j = 0; j < width; j++)
                    {
                        t += kvp[i] <= j ? '#' : '.'; // Compare current index with the number of dots
                    }
                    res.Add(t);
                }
            }

            return res;
        }
    }
}
