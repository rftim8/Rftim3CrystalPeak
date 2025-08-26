namespace Rftim3CodinGame.Refactor.Puzzles
{
    public class SnailRun
    {
        /// <summary>
        /// We have a snail race we will have to determine the winner !
        /// - The number of snails is given in the variable numberSnails.
        /// - Each snail has a speed given in the variable speedSnail
        /// - You have a map of the game with a height of mapHeight and a width of mapWidth.
        /// 
        /// On the map we have:
        /// number that represents a snail from 1 to numberSnails
        /// * which represents a place where the snail can go
        /// # which represents the destination
        /// 
        /// Snails can go right, left, up, down.Snails cannot go diagonally.
        /// The snail takes the path closest to it.
        /// 
        /// example of the game :
        /// 
        /// snail 1 speed 2
        /// snail 2 speed 1
        /// 
        /// start :
        /// 
        /// 1****#
        /// 2****#
        /// 
        /// time = 1
        ///         * *1 * *#
        /// *2 * **#
        /// 
        /// time = 2
        /// 
        /// * ***1#
        /// * *2 * *#
        /// 
        /// time = 3
        /// 
        /// * ****1
        /// * **2 *#
        /// 
        /// End :
        /// 
        /// return 1
        /// 
        /// For each race there is only one winner.
        /// </summary>
        public SnailRun()
        {

        }

        public static int RftSolve(Dictionary<int, int> speeds, string[] map)
        {
            List<(int x, int y)> dest = [];
            Dictionary<int, (int x, int y)> snails = [];

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (int.TryParse(map[i][j].ToString(), out int result)) snails.Add(result, (i, j));
                    if (map[i][j] == '#') dest.Add((i, j));
                }
            }

            Dictionary<int, double> results = [];
            foreach (var item in speeds)
            {
                results.Add(item.Key, int.MaxValue);
            }

            foreach ((int x, int y) in dest)
            {
                foreach (KeyValuePair<int, (int x, int y)> item1 in snails)
                {
                    int dist = Math.Abs(x - item1.Value.x) + Math.Abs(y - item1.Value.y);
                    double r = (double)dist / speeds[item1.Key];
                    results[item1.Key] = Math.Min(results[item1.Key], r);
                }
            }

            return results.MinBy(o => o.Value).Key;
        }
    }
}
