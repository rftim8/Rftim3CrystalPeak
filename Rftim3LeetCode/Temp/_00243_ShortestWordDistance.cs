namespace Rftim3LeetCode.Temp
{
    public class _00243_ShortestWordDistance
    {
        /// <summary>
        /// Given an array of strings wordsDict and two different strings that already exist in the array word1 and word2, 
        /// return the shortest distance between these two words in the list.
        /// </summary>
        public _00243_ShortestWordDistance()
        {
            Console.WriteLine(ShortestWordDistance0(["practice", "makes", "perfect", "coding", "makes"], "coding", "practice"));
            Console.WriteLine(ShortestWordDistance0(["practice", "makes", "perfect", "coding", "makes"], "makes", "coding"));
        }

        public static int ShortestWordDistance0(string[] a0, string a1, string a2) => RftShortestWordDistance0(a0, a1, a2);

        public static int ShortestWordDistance1(string[] a0, string a1, string a2) => RftShortestWordDistance1(a0, a1, a2);

        private static int RftShortestWordDistance0(string[] wordsDict, string word1, string word2)
        {
            int res = int.MaxValue;

            int a0 = int.MaxValue, a1 = int.MaxValue;
            for (int i = 0; i < wordsDict.Length; i++)
            {
                if (wordsDict[i] == word1)
                {
                    a0 = i;
                    res = Math.Min(res, Math.Abs(Math.Abs(a0) - Math.Abs(a1)));
                }
                if (wordsDict[i] == word2)
                {
                    a1 = i;
                    res = Math.Min(res, Math.Abs(Math.Abs(a0) - Math.Abs(a1)));
                }
            }

            return res;
        }

        private static int RftShortestWordDistance1(string[] wordsDict, string word1, string word2)
        {
            int position1 = -1;
            int position2 = -1;
            int shortest = int.MaxValue;
            for (int i = 0; i < wordsDict.Length; i++)
            {
                if (wordsDict[i] == word1)
                {
                    position1 = i;
                    if (position2 != -1) shortest = Math.Min(shortest, position1 - position2);
                }
                else if (wordsDict[i] == word2)
                {
                    position2 = i;
                    if (position1 != -1) shortest = Math.Min(shortest, position2 - position1);
                }
            }

            return shortest;
        }
    }
}
