namespace Rftim3LeetCode.Temp
{
    public class _02451_OddStringDifference
    {
        /// <summary>
        /// You are given an array of equal-length strings words. Assume that the length of each string is n.
        /// Each string words[i] can be converted into a difference integer array difference[i] of length n - 1 where 
        /// difference[i][j] = words[i][j + 1] - words[i][j] where 0 <= j <= n - 2. 
        /// Note that the difference between two letters is the difference between their positions in the alphabet i.e.the position of 'a' is 0, 'b' is 1, and 'z' is 25.
        /// For example, for the string "acb", the difference integer array is [2 - 0, 1 - 2] = [2, -1].
        /// All the strings in words have the same difference integer array, except one.
        /// You should find that string.
        /// Return the string in words that has different difference integer array.
        /// </summary>
        public _02451_OddStringDifference()
        {
            Console.WriteLine(OddString(["adc", "wzy", "abc"]));
            Console.WriteLine(OddString(["aaa", "bob", "ccc", "ddd"]));
        }

        private static string OddString(string[] words)
        {
            int n = words.Length;
            List<(List<int>, List<string>)> x = [];
            List<(List<int>, List<string>)> x0 = [];

            for (int i = 0; i < n; i++)
            {
                List<int> t = [];

                for (int j = 0; j < words[i].Length - 1; j++)
                {
                    int l = words[i][j + 1] - words[i][j];
                    t.Add(l);
                }

                if (i == 0) x.Add((t, new List<string>() { words[i] }));
                else
                {
                    if (x[0].Item1.SequenceEqual(t)) x[0].Item2.Add(words[i]);
                    else
                    {
                        if (x0.Count == 0) x0.Add((t, new List<string>() { words[i] }));
                        else
                        {
                            if (x0[0].Item1.SequenceEqual(t)) x0[0].Item2.Add(words[i]);
                        }
                    }
                }
            }

            if (x[0].Item2.Count == 1) return x[0].Item2[0];
            if (x0[0].Item2.Count == 1) return x0[0].Item2[0];

            return "";
        }
    }
}
