using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00506_RelativeRanks
    {
        /// <summary>
        /// You are given an integer array score of size n, where score[i] is the score of the ith athlete in a competition. 
        /// All the scores are guaranteed to be unique.
        /// The athletes are placed based on their scores, where the 1st place athlete has the highest score, the 2nd place athlete has the 2nd highest score, and so on.
        /// The placement of each athlete determines their rank:
        /// The 1st place athlete's rank is "Gold Medal".
        /// The 2nd place athlete's rank is "Silver Medal".
        /// The 3rd place athlete's rank is "Bronze Medal".
        /// For the 4th place to the nth place athlete, their rank is their placement number(i.e., the xth place athlete's rank is "x").
        /// Return an array answer of size n where answer[i] is the rank of the ith athlete.
        /// </summary>
        public _00506_RelativeRanks()
        {
            string[] x = FindRelativeRanks0([5, 4, 3, 2, 1]);
            RftTerminal.RftReadResult(x);

            string[] x0 = FindRelativeRanks0([10, 3, 8, 9, 4]);
            RftTerminal.RftReadResult(x0);
        }

        public static string[] FindRelativeRanks0(int[] a0) => RftFindRelativeRanks0(a0);

        public static string[] FindRelativeRanks1(int[] a0) => RftFindRelativeRanks1(a0);

        private static string[] RftFindRelativeRanks0(int[] score)
        {
            int n = score.Length;
            List<int> y = new(score);
            y.Sort((a, b) => b.CompareTo(a));

            string[] r = new string[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < y.Count; j++)
                {
                    if (score[i] == y[j])
                    {
                        if (j == 0) r[i] = "Gold Medal";
                        else if (j == 1) r[i] = "Silver Medal";
                        else if (j == 2) r[i] = "Bronze Medal";
                        else r[i] = (j + 1).ToString();
                    }
                }
            }

            return r;
        }

        private static string[] RftFindRelativeRanks1(int[] score)
        {
            string[] result = new string[score.Length];
            Dictionary<int, int> map = [];
            for (int i = 0; i < score.Length; i++)
            {
                map.Add(score[i], i);
            }

            Array.Sort(score);

            int place = 1;
            for (int i = score.Length - 1; i >= 0; i--)
            {
                int item = score[i];
                int index = map[item];
                result[index] = Rank(place);
                place++;
            }

            return result;
        }

        private static string Rank(int place)
        {
            if (place == 1) return "Gold Medal";
            if (place == 2) return "Silver Medal";
            if (place == 3) return "Bronze Medal";

            return place.ToString();
        }
    }
}
