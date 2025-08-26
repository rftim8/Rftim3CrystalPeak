namespace Rftim3LeetCode.Temp
{
    public class _01496_PathCrossing
    {
        /// <summary>
        /// Given a string path, where path[i] = 'N', 'S', 'E' or 'W', each representing moving one unit north, south, east, or west, respectively. 
        /// You start at the origin (0, 0) on a 2D plane and walk on the path specified by path.
        /// Return true if the path crosses itself at any point, that is, if at any time you are on a location you have previously visited.
        /// Return false otherwise.
        /// </summary>
        public _01496_PathCrossing()
        {
            Console.WriteLine(IsPathCrossing("NES"));
            Console.WriteLine(IsPathCrossing("NESWW"));
        }

        private static bool IsPathCrossing(string path)
        {
            int n = path.Length;

            List<(int, int)> x = new() { (0, 0) };
            int l = 0, r = 0;
            for (int i = 0; i < n; i++)
            {
                switch (path[i])
                {
                    case 'N':
                        r++;
                        break;
                    case 'S':
                        r--;
                        break;
                    case 'E':
                        l++;
                        break;
                    case 'W':
                        l--;
                        break;
                    default:
                        break;
                }
                if (!x.Contains((l, r))) x.Add((l, r));
                else return true;
            }

            return false;
        }
    }
}
