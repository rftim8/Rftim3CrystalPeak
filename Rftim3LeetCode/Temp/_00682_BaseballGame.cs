namespace Rftim3LeetCode.Temp
{
    public class _00682_BaseballGame
    {
        /// <summary>
        /// You are keeping the scores for a baseball game with strange rules. 
        /// At the beginning of the game, you start with an empty record.
        /// You are given a list of strings operations, where operations[i] is the ith operation you must apply to the record and is one of the following:
        /// An integer x.
        /// Record a new score of x.
        /// '+'.
        /// Record a new score that is the sum of the previous two scores.
        /// 'D'.
        /// Record a new score that is the double of the previous score.
        /// 'C'.
        /// Invalidate the previous score, removing it from the record.
        /// Return the sum of all the scores on the record after applying all the operations.
        /// The test cases are generated such that the answer and all intermediate calculations fit in a 32-bit integer and that all operations are valid.
        /// </summary>
        public _00682_BaseballGame()
        {
            Console.WriteLine(CalPoints(["5", "2", "C", "D", "+"]));
            Console.WriteLine(CalPoints(["5", "-2", "4", "C", "D", "9", "+", "+"]));
            Console.WriteLine(CalPoints(["1", "C"]));
        }

        private static int CalPoints(string[] operations)
        {
            List<int> r = [];

            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i] == "C") r.RemoveAt(r.Count - 1);
                else if (operations[i] == "D") r.Add(r[^1] * 2);
                else if (operations[i] == "+") r.Add(r[^1] + r[^2]);
                else r.Add(int.Parse(operations[i]));
            }

            return r.Sum();
        }
    }
}
