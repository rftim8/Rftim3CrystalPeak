namespace Rftim3LeetCode.Temp
{
    public class _00748_ShortestCompletingWord
    {
        /// <summary>
        /// Given a string licensePlate and an array of strings words, find the shortest completing word in words.
        /// A completing word is a word that contains all the letters in licensePlate.
        /// Ignore numbers and spaces in licensePlate, and treat letters as case insensitive.
        /// If a letter appears more than once in licensePlate, then it must appear in the word the same number of times or more.
        /// For example, if licensePlate = "aBc 12c", then it contains letters 'a', 'b' (ignoring case), and 'c' twice.
        /// Possible completing words are "abccdef", "caaacab", and "cbca".
        /// Return the shortest completing word in words.
        /// It is guaranteed an answer exists.If there are multiple shortest completing words, return the first one that occurs in words.
        /// </summary>
        public _00748_ShortestCompletingWord()
        {
            Console.WriteLine(ShortestCompletingWord(
                "1s3 PSt",
                ["step", "steps", "stripe", "stepple"]
            ));

            Console.WriteLine(ShortestCompletingWord(
                "1s3 456",
                ["looks", "pest", "stew", "show"]
            ));
        }

        private static string ShortestCompletingWord(string licensePlate, string[] words)
        {
            int n = licensePlate.Length;
            licensePlate = licensePlate.ToLower();

            Dictionary<char, int> x = [];

            for (int i = 0; i < n; i++)
            {
                if (char.IsLetter(licensePlate[i]))
                {
                    if (x.TryGetValue(licensePlate[i], out int value)) x[licensePlate[i]] = ++value;
                    else x[licensePlate[i]] = 1;
                }
            }

            List<(string, int)> r = [];

            for (int i = 0; i < words.Length; i++)
            {
                int y = 0;
                foreach (KeyValuePair<char, int> item in x)
                {
                    if (words[i].Contains(item.Key))
                    {
                        int nr = words[i].Count(o => o == item.Key);
                        y += nr > item.Value ? item.Value : nr;
                    }
                }

                r.Add((words[i], y));
            }

            foreach ((string, int) item in r)
            {
                Console.WriteLine($"{item.Item1}: {item.Item2}");
            }

            r = [.. r.OrderByDescending(o => o.Item2).ThenBy(o => o.Item1.Length)];

            return r[0].Item1;
        }
    }
}
