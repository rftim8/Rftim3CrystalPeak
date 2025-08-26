namespace Rftim3LeetCode.Temp
{
    public class _00946_ValidateStackSequences
    {
        /// <summary>
        /// Given two integer arrays pushed and popped each with distinct values, return true if this could have been 
        /// the result of a sequence of push and pop operations on an initially empty stack, or false otherwise.
        /// </summary>
        public _00946_ValidateStackSequences()
        {
            Console.WriteLine(ValidateStackSequences([1, 2, 3, 4, 5], [4, 5, 3, 2, 1]));
            Console.WriteLine(ValidateStackSequences([1, 2, 3, 4, 5], [4, 3, 5, 1, 2]));
        }

        private static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            int n = pushed.Length;
            Stack<int> x = new();

            int c = 0;
            for (int i = 0; i < n; i++)
            {
                x.Push(pushed[i]);
                while (x.Count != 0 && c < n && x.Peek() == popped[c])
                {
                    x.Pop();
                    c++;
                }
            }

            return c == n;
        }
    }
}
