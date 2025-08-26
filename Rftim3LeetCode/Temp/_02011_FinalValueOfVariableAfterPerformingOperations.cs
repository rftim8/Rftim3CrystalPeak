namespace Rftim3LeetCode.Temp
{
    public class _02011_FinalValueOfVariableAfterPerformingOperations
    {
        /// <summary>
        /// There is a programming language with only four operations and one variable X:
        /// ++X and X++ increments the value of the variable X by 1.
        /// --X and X-- decrements the value of the variable X by 1.
        /// Initially, the value of X is 0.
        /// Given an array of strings operations containing a list of operations, return the final value of X after performing all the operations.
        /// </summary>
        public _02011_FinalValueOfVariableAfterPerformingOperations()
        {
            Console.WriteLine(FinalValueAfterOperations(["--X", "X++", "X++"]));
            Console.WriteLine(FinalValueAfterOperations(["++X", "++X", "X++"]));
            Console.WriteLine(FinalValueAfterOperations(["X++", "++X", "--X", "X--"]));
        }

        private static int FinalValueAfterOperations(string[] operations)
        {
            int r = 0;
            foreach (string item in operations)
            {
                if (item.Contains("++")) r++;
                if (item.Contains("--")) r--;
            }

            return r;
        }
    }
}
