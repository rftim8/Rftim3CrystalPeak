namespace Rftim3LeetCode.Temp
{
    public class _02140_SolvingQuestionsWithBrainpower
    {
        /// <summary>
        /// You are given a 0-indexed 2D integer array questions where questions[i] = [pointsi, brainpoweri].
        /// The array describes the questions of an exam, where you have to process the questions in order(i.e., starting from question 0) and make a decision whether to solve or skip each question.Solving question i will earn you pointsi points but you will be unable to solve each of the next brainpoweri questions.If you skip question i, you get to make the decision on the next question.
        /// For example, given questions = [[3, 2], [4, 3], [4, 4], [2, 5]]:
        /// If question 0 is solved, you will earn 3 points but you will be unable to solve questions 1 and 2.
        /// If instead, question 0 is skipped and question 1 is solved, you will earn 4 points but you will be unable to solve questions 2 and 3.
        /// Return the maximum points you can earn for the exam.
        /// /// </summary>
        public _02140_SolvingQuestionsWithBrainpower()
        {
            Console.WriteLine(MostPoints(
            [
                [3,2],
                [4,3],
                [4,4],
                [2,5]
            ]));

            Console.WriteLine(MostPoints(
            [
                [1,1],
                [2,2],
                [3,3],
                [4,4],
                [5,5]
            ]));

            Console.WriteLine(MostPoints(
            [
                [21,5],
                [92,3],
                [74,2],
                [39,4],
                [58,2],
                [5,5],
                [49,4],
                [65,3]
            ]));
        }

        private static long MostPoints(int[][] questions)
        {
            int n = questions.Length;
            long[] x = new long[n];
            x[n - 1] = questions[n - 1][0];

            for (int i = n - 2; i > -1; --i)
            {
                x[i] = questions[i][0];
                int y = questions[i][1];

                if (i + y + 1 < n) x[i] += x[i + y + 1];

                x[i] = Math.Max(x[i], x[i + 1]);
            }

            return x[0];
        }
    }
}
