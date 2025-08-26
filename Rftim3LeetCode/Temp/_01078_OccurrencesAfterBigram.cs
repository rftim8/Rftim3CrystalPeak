using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _01078_OccurrencesAfterBigram
    {
        /// <summary>
        /// Given two strings first and second, consider occurrences in some text of the form "first second third", 
        /// where second comes immediately after first, and third comes immediately after second.
        /// Return an array of all the words third for each occurrence of "first second third".
        /// </summary>
        public _01078_OccurrencesAfterBigram()
        {
            string[] x = FindOcurrences("alice is a good girl she is a good student", "a", "good");
            string[] x0 = FindOcurrences("we will we will rock you", "we", "will");

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static string[] FindOcurrences(string text, string first, string second)
        {
            List<string> x = [.. text.Split(' ')];

            List<string> r = [];
            for (int i = 1; i < x.Count; i++)
            {
                if (x[i - 1] == first && x[i] == second && i < x.Count - 1) r.Add(x[i + 1]);
            }

            return [.. r];
        }
    }
}
