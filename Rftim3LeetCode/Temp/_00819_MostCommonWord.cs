namespace Rftim3LeetCode.Temp
{
    public class _00819_MostCommonWord
    {
        /// <summary>
        /// Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned.
        /// It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        /// The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        /// </summary>
        public _00819_MostCommonWord()
        {
            Console.WriteLine(MostCommonWord(
                "Bob hit a ball, the hit BALL flew far after it was hit.",
                ["hit"])
            );

            Console.WriteLine(MostCommonWord(
                "a.",
                [])
            );

            Console.WriteLine(MostCommonWord(
                "a, a, a, a, b,b,b,c, c",
                ["a"])
            );
        }

        private static string MostCommonWord(string paragraph, string[] banned)
        {
            paragraph = paragraph.ToLowerInvariant()
                .Replace(".", " ")
                .Replace(",", " ")
                .Replace(";", " ")
                .Replace("?", " ")
                .Replace("'", " ")
                .Replace("!", " ");
            List<string> x = [.. paragraph.Split(' ')];

            x.RemoveAll(string.IsNullOrEmpty);

            for (int i = 0; i < banned.Length; i++)
            {
                x.RemoveAll((o) => o.Equals(banned[i], StringComparison.InvariantCultureIgnoreCase));
            }

            Dictionary<string, int> y = [];

            int max = int.MinValue;
            string r = "";
            foreach (string item in x)
            {
                if (y.TryGetValue(item, out int value)) y[item] = ++value;
                else y[item] = 1;

                if (y[item] > max)
                {
                    max = y[item];
                    r = item;
                }
            }

            return r;
        }
    }
}
