using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02225_FindPlayersWithZeroOrOneLosses
    {
        /// <summary>
        /// You are given an integer array matches where matches[i] = [winneri, loseri] indicates that the player winneri defeated player 
        /// loseri in a match.
        /// 
        /// Return a list answer of size 2 where:
        /// 
        /// answer[0] is a list of all players that have not lost any matches.
        /// answer[1] is a list of all players that have lost exactly one match.
        /// The values in the two lists should be returned in increasing order.
        /// Note:
        /// 
        /// You should only consider the players that have played at least one match.
        /// The testcases will be generated such that no two matches will have the same outcome.
        /// </summary>
        public _02225_FindPlayersWithZeroOrOneLosses()
        {
            IList<IList<int>> x = FindWinners0([[1, 3], [2, 3], [3, 6], [5, 6], [5, 7], [4, 5], [4, 8], [4, 9], [10, 4], [10, 9]]);
            RftTerminal.RftReadResult(x);

            IList<IList<int>> x0 = FindWinners0([[2, 3], [1, 3], [5, 4], [6, 4]]);
            RftTerminal.RftReadResult(x0);
        }

        public static IList<IList<int>> FindWinners0(int[][] a0) => RftFindWinners0(a0);

        public static IList<IList<int>> FindWinners1(int[][] a0) => RftFindWinners1(a0);

        private static List<IList<int>> RftFindWinners0(int[][] matches)
        {
            int n = matches.Length;

            Dictionary<int, int[]> kvp = [];
            for (int i = 0; i < n; i++)
            {
                if (kvp.TryGetValue(matches[i][0], out int[]? value)) value[0]++;
                else kvp.Add(matches[i][0], [1, 0]);

                if (kvp.TryGetValue(matches[i][1], out int[]? value0)) value0[1]++;
                else kvp.Add(matches[i][1], [0, 1]);
            }

            List<int> wins = [], losses = [];
            List<IList<int>> r = [];

            foreach (KeyValuePair<int, int[]> item in kvp)
            {
                if (item.Value[1] == 0) wins.Add(item.Key);
                else if (item.Value[1] == 1) losses.Add(item.Key);
            }

            wins.Sort();
            losses.Sort();

            r.Add(wins);
            r.Add(losses);

            return r;
        }

        private static List<IList<int>> RftFindWinners1(int[][] matches)
        {
            List<IList<int>> answer = [];
            List<int> winList = [];
            List<int> loseList = [];

            answer.Add(winList);
            answer.Add(loseList);

            Dictionary<int, int> winDic = [];
            Dictionary<int, int> loseDic = [];

            for (int i = 0; i < matches.Length; i++)
            {
                winDic[matches[i][0]] = winDic.GetValueOrDefault(matches[i][0], 0) + 1;
                loseDic[matches[i][1]] = loseDic.GetValueOrDefault(matches[i][1], 0) + 1;
            }

            foreach (KeyValuePair<int, int> kvp in winDic)
            {
                if (!loseDic.ContainsKey(kvp.Key)) winList.Add(kvp.Key);
            }

            foreach (KeyValuePair<int, int> kvp in loseDic)
            {
                if (kvp.Value == 1) loseList.Add(kvp.Key);
            }

            winList.Sort();
            loseList.Sort();

            return answer;
        }
    }
}
